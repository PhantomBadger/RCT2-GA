using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2TrackData
    {
        public List<RCT2TrackPiece> TrackData { get; set; }

        public float MaxPositiveG { get; private set; }
        public float MaxNegativeG { get; private set; }
        public float MaxLateralG { get; private set; }

        public int AirTimeInSeconds { get; private set; }

        public int NumOfInversions { get; private set; }

        public int NumOfDrops { get; private set; }
        public int HighestDrop { get; private set; }

        public int AverageSpeed { get; private set; }
        public int MaxSpeed { get; private set; }

        public float Excitement { get; private set; }
        public float Intensity { get; private set; }
        public float Nausea { get; private set; }

        const int ChainLiftSpeed = 5;
        const int StationSpeed = 4;
        const int HorizontalUnitsToMeters = 5;
        const float VerticalUnitsToMeters = 1.31234f;

        const float MaxUnitsOfDisplacement = 80.0f;
        const float MinUnitsOfDisplacement = -80.0f;

        bool velocityChecked = false;
        bool velocityGoesNegative = false;

        public RCT2TrackData()
        {
            TrackData = new List<RCT2TrackPiece>();
        }

        public bool CheckValidity()
        {
            //Following Validity Checks:
            // - All Track Pieces connect to the one before it
            // - Track doesn't intersect with itself
            // - Track doesn't exceed max height
            // - Track doesn't go underground (Go lower than the station height)
            // - Track's velocity doesn't go negative

            if (TrackData.Count <= 0)
            {
                return true;
            }

            //Negative Velocity
            if (!velocityChecked)
            {
                PopulateRideStatistics();
            }

            if (velocityGoesNegative)
            {
                return false;
            }

            float currentYDisplacement = 0;
            RCT2TrackElementProperty prevElementProperty = RCT2TrackElements.TrackElementPropertyMap[TrackData[0].TrackElement];
            List<Vector3> UsedCells = new List<Vector3>();
            Vector3 prevWorldPos = new Vector3(0.0f, 0.0f, 0.0f);
            int worldDirectionChange = 0;
            for (int i = 0; i < TrackData.Count; i++)
            {
                RCT2TrackElements.RCT2TrackElement currentElement = TrackData[i].TrackElement;
                RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[currentElement];

                // Height Checks
                currentYDisplacement += property.Displacement.Y;
                if (currentYDisplacement >= MaxUnitsOfDisplacement || currentYDisplacement < 0)
                {
                    return false;
                }

                //Prev Element Matching Test
                if (i > 0 &&
                    (prevElementProperty.OutputTrackBank != property.InputTrackBank ||
                     prevElementProperty.OutputTrackDegree != property.InputTrackDegree))
                {
                    return false;
                }

                //Intersection Tests
                //Get the world version of our property displacement
                //ie, if the segment moves 1 forward, but is already rotated to the left
                //    by 90°, then it actually moves right by 1
                Vector3 worldDisplacement = LocalDisplacementToWorld(property.Displacement, worldDirectionChange);

                //Check every tile used in this segment
                for (int j = 0; j <= worldDisplacement.X; j++)
                {
                    for (int k = 0; k <= worldDisplacement.Y; k++)
                    {
                        for (int l = 1; l <= worldDisplacement.Z; l++)
                        {
                            Vector3 testCell = prevWorldPos + new Vector3(j, k, l);
                            if (!UsedCells.Contains(testCell))
                            {
                                UsedCells.Add(testCell);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }

                //Update World Direction Changes
                worldDirectionChange = UpdateRotation(worldDirectionChange, property.DirectionChange);

                //Update variables
                prevWorldPos += worldDisplacement;
                prevElementProperty = property;
            }

            return true;
        }

        public void AutoComplete()
        {

        }

        private float CalculateExcitement()
        {
            float tempExcitement = 0;
            //G Force
            //(0.08 * max pos g) + (0.24 * clamp(-2.5, max neg g, 0)) + (0.4 * min(1.5, max lat g))
            //If lat g is above 3.1, rating is halved
            //Multiplied by ride constant
            float clampedNeg = (MaxNegativeG < -2.5f) ? -2.5f : (MaxNegativeG > 0) ? 0 : MaxNegativeG;
            float gForceComponent = (0.08f * MaxPositiveG) + (0.24f * clampedNeg) + (0.4f * Math.Min(1.5f, MaxLateralG));
            //TODO: GET RIDE CONSTANT

            //Drops
            //(0.11 * min(9, num of drops)) + (0.0049 * highest drop)
            //Multiplied by ride constant
            float dropComponent = (0.11f * Math.Min(0, NumOfDrops)) + (0.0049f * HighestDrop);
            //TODO: GET RIDE CONSTANT

            //Inversions
            //(0.27 * min(6, num inversions))
            float inversionComponent = (0.27f * Math.Min(6, NumOfInversions));

            //Scenery
            //Ignore

            //Proximity
            //Ignore

            //Synchronized Stations
            //A fixed constant is added
            //TODO

            //Track Length
            //track length * ride constant
            //Ride specific cap for length also
            //TODO

            //Train Length
            //Each additional car after 1 adds a fixed ride specific quantity to excitement
            //TODO

            //Speed
            //Max speed * ride specific constant
            //Avg Speed * ride specific constant
            float maxSpeedComponent = MaxSpeed; //TODO
            float avgSpeedComponent = AverageSpeed; //TODO

            //Penalties for low stats
            //Each ride has it's own min threshold for
            //Drop height
            //Max Speed
            //Number of Drops
            //Max Neg Gs
            //Max Lat Gs
            //Failing to meet these causes all 3 ratings to be divided by a ride-specific constant
            //TODO


            //Too High Intensity
            //If Intensity > 10 excitement is decreased by 25%
            //If Intensity > 11 excitement is decreased by 25% again
            //If Intensity > 12 excitement is decreased by 25% again
            //If Intensity > 13.2 excitement is decreased by 25% again
            //If Intensity > 14.5 excitement is decreased by 25% again
            //TODO


            tempExcitement = gForceComponent + dropComponent + inversionComponent + maxSpeedComponent + avgSpeedComponent;

            return tempExcitement;
        }

        private float CalculateIntensity()
        {
            float tempIntensity = 0;
            //G-Force Ride Rating
            //(0.8 * max positive G) + (0.8 * 1- max negative g) + max lateral g
            //If lat g is above 2.8, a value of 3.75 is added to intensity
            //If lat g also exceeds 3.1 then 8.5 added to intensity
            //Multiplied by ride constant
            float gForceComponent = (0.8f * MaxPositiveG) + (0.8f * (1 - MaxNegativeG)) + MaxLateralG;
            if (MaxLateralG > 2.8f)
            {
                gForceComponent += 3.75f;
                if (MaxLateralG > 3.1f)
                {
                    gForceComponent += 8.5f;
                }
            }
            //TODO: FIND RIDE CONSTANT

            //Ride Drops
            float rideDropComponent = (0.14f * NumOfDrops) + (0.0098f * HighestDrop);
            //Multiplied by ride specific constant
            //TODO: FIND RIDE CONSTANT

            //Inversions
            float inversionComponent = (0.5f * NumOfInversions);

            //Scenery
            //Changes based on placement Ignore (minimum between number of scenery items surrounding, and 47) * 5

            //Proximity
            //Changes based on placement Ignore

            //Synchronized Stations
            //Constant is added based on ride type
            //TODO: FIND RIDE CONSTANT

            //Speed
            //Max speed multiplied by three ride specific constants and then added to each rating
            //Average rating multiplied by 2 constants and applied to excitement/intensity
            float maxSpeedComponent = MaxSpeed; //TODO: Multiply by ride constant
            float avgSpeedComponent = AverageSpeed; //TODO: Multiply by ride constant

            //Penalties for low stats
            //Each ride has it's own min threshold for
            //Drop height
            //Max Speed
            //Number of Drops
            //Max Neg Gs
            //Max Lat Gs
            //Failing to meet these causes all 3 ratings to be divided by a ride-specific constant
            //TODO: Thresholds

            tempIntensity = gForceComponent + rideDropComponent + inversionComponent + maxSpeedComponent + avgSpeedComponent;

            return tempIntensity;
        }

        private float CalculateNausea()
        {
            float tempNausea = 0;
            //G Force
            //(0.26 * max positive g) + (0.22 * 1-max neg g) + 0.33 * max lat g
            //if lat g above 2.8, then 2 added to nausea
            //If lat g also above 3.1, 4 added to nausea
            //Multiplied by constant dependint on ride type
            float gForceComponent = (0.26f * MaxPositiveG) + (0.22f * (1 - MaxNegativeG)) + (0.33f * MaxLateralG);
            if (MaxLateralG > 2.8f)
            {
                gForceComponent += 2;
                if (MaxLateralG > 3.1f)
                {
                    gForceComponent += 4;
                }
            }
            //TODO: GET RIDE CONSTANT

            //Drops
            // (0.1 * num of drops) + (0.0016 * highest drop)
            //Calculated by ride specific constant
            float dropComponent = (0.1f * NumOfDrops) + (0.0016f * HighestDrop);
            //TODO: GET RIDE CONSTANT

            //Inversions
            //0.22 * num of inversions
            float inversionComponent = (0.22f * NumOfInversions);

            //Scenery
            //Ignore

            //Proximity
            //Ignore

            //Speed
            //Max speed multiplied by ride specific constant
            //Avg speed isnt used
            float maxSpeedComponent = MaxSpeed; //TODO

            //Penalties for low stats
            //Each ride has it's own min threshold for
            //Drop height
            //Max Speed
            //Number of Drops
            //Max Neg Gs
            //Max Lat Gs
            //Failing to meet these causes all 3 ratings to be divided by a ride-specific constant

            tempNausea = gForceComponent + dropComponent + inversionComponent + maxSpeedComponent;

            return tempNausea;
        }

        public int CalculateRideLengthInMeters()
        {
            //Approximate
            int rideLength = 0;

            for (int i = 0; i < TrackData.Count; i++)
            {
                RCT2TrackElements.RCT2TrackElement element = TrackData[i].TrackElement;
                RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[element];

                int curLength = 0;
                int counter = 0;

                if (property.Displacement.X != 0)
                {
                    curLength += (int)Math.Abs(property.Displacement.X * HorizontalUnitsToMeters);
                    counter++;
                }

                if (property.Displacement.Y != 0)
                {
                    curLength += (int)Math.Abs(property.Displacement.Y * VerticalUnitsToMeters);
                    counter++;
                }

                if (property.Displacement.Z != 0)
                {
                    curLength += (int)Math.Abs(property.Displacement.Z * HorizontalUnitsToMeters);
                    counter++;
                }

                if (counter > 0)
                {
                    rideLength += (curLength / counter);
                }
            }

            return rideLength;
        }

        public Vector2 CalculateRequiredMapSpace()
        {
            Vector2 requiredMapSpace = new Vector2(0.0f, 0.0f);
            Vector2 posDisplacementCounter = new Vector2(0.0f, 0.0f);

            int currentDirectionOffset = 0;
            List<Vector3> usedCells = new List<Vector3>();
            Vector3 prevWorldDisplacement = new Vector3(0.0f, 0.0f, 0.0f);

            for (int i = 0; i < TrackData.Count; i++)
            {
                RCT2TrackElements.RCT2TrackElement element = TrackData[i].TrackElement;
                RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[element];
                Vector3 worldDisplacement = LocalDisplacementToWorld(property.Displacement, currentDirectionOffset);

                prevWorldDisplacement += worldDisplacement;
                usedCells.Add(prevWorldDisplacement);

                currentDirectionOffset = UpdateRotation(currentDirectionOffset, property.DirectionChange);
            }

            //Find max X and Y distance of cells in list
            List<float> xVals = new List<float>();
            List<float> yVals = new List<float>();
            usedCells.ForEach(v =>
            {
                xVals.Add(v.X);
                yVals.Add(v.Z);
            });
            xVals.Sort();
            yVals.Sort();

            requiredMapSpace.X = Math.Abs(xVals.Last() - xVals.First());
            requiredMapSpace.Y = Math.Abs(yVals.Last() - yVals.First());

            return requiredMapSpace;
        }

        public void PopulateRideStatistics()
        {
            //Inversion Data
            int tempInvCount = 0;

            //Velocity Data
            float totalVelocity = 0;
            float vehicleVelocity = 0;
            float tempMaxSpeed = 0;

            //Drop Data
            int dropCount = 0;
            bool inDrop = false;
            float tempHighestDrop = 0;
            float curDropHeight = 0;
            int tempAirTimeInSeconds = 0;

            //G Forces
            float maxLatG = 0;
            float maxPosG = 0;
            float maxNegG = 0;

            float previousLatG = 0;
            float previousVertG = 0;

            for (int i = 0; i < TrackData.Count - 1; i++)
            {
                RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[TrackData[i].TrackElement];
                RCT2TrackElements.RCT2TrackElement element = TrackData[i].TrackElement;

                //----Check for ride inversions----
                if (CheckInversion(property))
                {
                    tempInvCount++;
                }

                //----Velocity Calculations----
                float tempVel = CalcVelocity(vehicleVelocity, element, TrackData[i].Qualifier, property);
                vehicleVelocity = tempVel;
                totalVelocity += tempVel;

                if (tempVel > tempMaxSpeed)
                {
                    tempMaxSpeed = tempVel;
                }

                //----Drop Calculations----
                //We've entered a drop
                if (property.Displacement.Y < 0 && !inDrop)
                {
                    //Increment our counters
                    inDrop = true;
                    dropCount++;
                    curDropHeight += property.Displacement.Y * VerticalUnitsToMeters;
                }
                //If we're still in a drop
                else if (property.Displacement.Y < 0)
                {
                    //Add to our measurement of this drop
                    curDropHeight += property.Displacement.Y * VerticalUnitsToMeters;
                }
                //If we end the drop
                else if (property.Displacement.Y >= 0 && inDrop)
                {
                    //Reset our values
                    inDrop = false;
                    if (Math.Abs(curDropHeight) > tempHighestDrop)
                    {
                        tempHighestDrop = Math.Abs(curDropHeight);
                    }
                    curDropHeight = 0;
                }

                //----G Forces----
                float latG = 0;
                float vertG = 0;
                TrackData[i].GetGForces(vehicleVelocity, out latG, out vertG);

                //Calc air time
                if (vertG < 0)
                {
                    //TODO: Translate into seconds, not sure how to do that really!
                    tempAirTimeInSeconds++;
                }

                //Get current G forces by averaging with previous ones
                vertG += previousVertG;
                latG += previousLatG;
                vertG /= 2;
                latG /= 2;
                previousLatG = latG;
                previousVertG = vertG;

                //See if it's more than our current maX
                if (latG > maxLatG)
                {
                    maxLatG = latG;
                }
                //Vertical Gs
                if (vertG < 0)
                {
                    //Keep track of Max
                    if (Math.Abs(vertG) > maxNegG)
                    {
                        maxNegG = Math.Abs(vertG);
                    }
                }
                else
                {
                    //Keep track of Max
                    if (vertG > maxPosG)
                    {
                        maxPosG = vertG;
                    }
                }
            }

            //Apply the new values to our global vars
            NumOfInversions = tempInvCount;

            NumOfDrops = dropCount;
            HighestDrop = (int)tempHighestDrop;

            AverageSpeed = (int)(totalVelocity / TrackData.Count);
            MaxSpeed = (int)tempMaxSpeed;
            velocityChecked = true;

            MaxLateralG = maxLatG;
            MaxPositiveG = maxPosG;
            MaxNegativeG = maxNegG;

            AirTimeInSeconds = tempAirTimeInSeconds;

            Excitement = CalculateExcitement();
            Intensity = CalculateIntensity();
            Nausea = CalculateNausea();
        }

        private bool CheckInversion(RCT2TrackElementProperty property)
        {
            //Check for ride inversions
            if ((property.InputTrackBank != RCT2TrackElementProperty.RCT2TrackBank.Flipped && property.OutputTrackBank == RCT2TrackElementProperty.RCT2TrackBank.Flipped) ||
                (property.InputTrackBank == RCT2TrackElementProperty.RCT2TrackBank.Flipped && property.OutputTrackBank != RCT2TrackElementProperty.RCT2TrackBank.Flipped))
            {
                return true;
            }

            return false;
        }

        private float CalcVelocity(float currentVelocity, RCT2TrackElements.RCT2TrackElement element, RCT2Qualifier qualifier, RCT2TrackElementProperty property)
        {
            //Check if it's a Chain lift or a station
            if (qualifier.IsChainLift)
            {
                return Math.Max(currentVelocity, ChainLiftSpeed);
            }
            else if (element == RCT2TrackElements.RCT2TrackElement.BeginStation ||
                     element == RCT2TrackElements.RCT2TrackElement.MiddleStation ||
                     element == RCT2TrackElements.RCT2TrackElement.EndStation)
            {
                return Math.Max(currentVelocity, StationSpeed);
            }

            float acceleration = 0;

            //Try to get current acceleration from the map
            try
            {
                acceleration = RCT2TrackElementProperty.TrackAccelerationMap[(int)-property.Displacement.Y];
            }
            catch
            {
                Console.WriteLine($"Unable to find acceleration value for track piece {element.ToString()}");
            }

            float newVelocity = currentVelocity + acceleration;
            if (newVelocity <= 0)
            {
                velocityGoesNegative = true;
            }

            return newVelocity;
        }

        private Vector3 LocalDisplacementToWorld(Vector3 localDisplacement, int currentRotation)
        {
            //Get the world version of our property displacement
            //ie, if the segment moves 1 forward, but is already rotated to the left
            //    by 90°, then it actually moves right by 1

            //TODO
            //Doesn't work with Diagonals
            Vector3 worldDisplacement = localDisplacement;

            switch (currentRotation)
            {
                case -45:
                    //Not supported - TODO
                    goto default;
                case -90:
                    float left90z = -worldDisplacement.X;
                    float left90x = worldDisplacement.Z;

                    worldDisplacement.X = left90x;
                    worldDisplacement.Z = left90z;
                    break;
                case -135:
                    //Not Supported - TODO
                    goto default;
                case 180:
                    //Flip the X and Z
                    worldDisplacement.X *= -1;
                    worldDisplacement.Z *= -1;
                    break;
                case 45:
                    //Not Supported - TODO
                    goto default;
                case 90:
                    float right90z = worldDisplacement.X;
                    float right90x = -worldDisplacement.Z;

                    worldDisplacement.X = right90x;
                    worldDisplacement.Z = right90z;
                    break;
                case 135:
                    //Not Supported - TODO
                    goto default;
                case 0:
                    //Do Nothing
                    goto default;
                default:
                    break;
            }

            return worldDisplacement;
        }

        private int UpdateRotation(int currentRotation, RCT2TrackElementProperty.RCT2TrackDirectionChange directionChange)
        {
            //Update World Direction Changes
            int worldDirectionChange = currentRotation;
            worldDirectionChange+= (int)RCT2TrackElementProperty.TrackDirectionChangeMap[directionChange];

            if (worldDirectionChange < -180)
            {
                worldDirectionChange = 180 + (worldDirectionChange + 180);
            }
            else if (worldDirectionChange > 180)
            {
                worldDirectionChange = -180 + (worldDirectionChange - 180);
            }
            else if (worldDirectionChange == -180)
            {
                worldDirectionChange = 180;
            }

            return worldDirectionChange;
        }

        public void Parse(string rawData)
        {
            //TODO
        }
    }
}
