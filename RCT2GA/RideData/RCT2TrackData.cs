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

        public float MaxPositiveG { get { return maxPositiveG; } }
        public float MaxNegativeG { get { return maxNegativeG; } }
        public float MaxLateralG { get { return maxLateralG; } }
        public float AvgPositiveG { get { return avgPositiveG; } }
        public float AvgNegativeG { get { return avgNegativeG; } }
        public float AvgLateralG { get { return avgLateralG; } }
        
        public int AirTimeInSeconds { get { return airTimeInSeconds; } }

        public int NumOfInversions { get { return numOfInversions; } }

        public int NumOfDrops { get { return numOfDrops; } }
        public int HighestDrop { get { return highestDrop; } }

        public int AverageSpeed { get { return avgSpeed; } }
        public int MaxSpeed { get { return maxSpeed; } }

        public float Excitement { get { return Excitement; } }
        public float Intensity { get { return Intensity; } }
        public float Nausea { get { return Nausea; } }

        const int ChainLiftSpeed = 6;

        private float maxPositiveG = 0;
        private float maxNegativeG = 0;
        private float maxLateralG = 0;
        private float avgPositiveG = 0;
        private float avgNegativeG = 0;
        private float avgLateralG = 0;

        private int airTimeInSeconds = 0;

        private int numOfInversions = 0;

        private int numOfDrops = 0;
        private int highestDrop = 0;

        private int avgSpeed = 0;
        private int maxSpeed = 0;

        private float excitement = 0;
        private float intensity = 0;
        private float nausea = 0;

        public RCT2TrackData()
        {
            TrackData = new List<RCT2TrackPiece>();
        }

        public bool CheckValidity()
        {
            //TODO
            return true;
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

        public int CalculateRideLength()
        {
            //TODO
            return TrackData.Count();
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
            float totalLatG = 0;
            float totalPosG = 0;
            float totalNegG = 0;

            float maxLatG = 0;
            float maxPosG = 0;
            float maxNegG = 0;

            for (int i = 0; i < TrackData.Count - 1; i++)
            {
                RCT2ElementProperty property = RCT2TrackElements.TrackElementPropertyMap[TrackData[i].TrackElement];
                RCT2TrackElements.RCT2TrackElement element = TrackData[i].TrackElement;

                //----Check for ride inversions----
                if (CheckInversion(property))
                {
                    tempInvCount++;
                }

                //----Velocity Calculations----
                float tempVel = CalcVelocity(vehicleVelocity, element, property);
                vehicleVelocity = tempVel;
                totalVelocity = tempVel;
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
                    curDropHeight += property.Displacement.Y;
                }
                //If we're still in a drop
                else if (property.Displacement.Y < 0)
                {
                    //Add to our measurement of this drop
                    curDropHeight += property.Displacement.Y;
                }
                //If we end the drop
                else if (property.Displacement.Y >= 0 && inDrop)
                {
                    //Reset our values
                    inDrop = false;
                    if (curDropHeight > tempHighestDrop)
                    {
                        tempHighestDrop = curDropHeight;
                    }
                    curDropHeight = 0;
                }

                //----G Forces----
                float latG = 0;
                float vertG = 0;
                TrackData[i].GetGForces(vehicleVelocity, out latG, out vertG);

                //Calc air time
                if (vertG == 0)
                {
                    //TODO: Translate into seconds, not sure how to do that really!
                    tempAirTimeInSeconds++;
                }

                //Add to our running totals & max values
                //Lateral Gs
                totalLatG += latG;
                //See if it's more than our current maX
                if (latG > maxLatG)
                {
                    maxLatG = latG;
                }
                //Vertical Gs
                if (vertG < 0)
                {
                    //Keep track of total & Max
                    totalNegG += Math.Abs(vertG);
                    if (Math.Abs(vertG) > maxNegG)
                    {
                        maxNegG = Math.Abs(vertG);
                    }
                }
                else
                {
                    //Keep track of total & Max
                    totalPosG += vertG;
                    if (vertG > maxPosG)
                    {
                        maxPosG = vertG;
                    }
                }
            }

            //Apply the new values to our global vars
            numOfInversions = tempInvCount;

            numOfDrops = dropCount;
            highestDrop = (int)tempHighestDrop;

            avgSpeed = (int)(totalVelocity / TrackData.Count);
            maxSpeed = (int)tempMaxSpeed;

            avgLateralG = totalLatG / TrackData.Count;
            avgPositiveG = totalPosG / TrackData.Count;
            avgNegativeG = totalNegG / TrackData.Count;

            maxLateralG = maxLatG;
            maxPositiveG = maxPosG;
            maxNegativeG = maxNegG;

            airTimeInSeconds = tempAirTimeInSeconds;

            excitement = CalculateExcitement();
            intensity = CalculateIntensity();
            nausea = CalculateNausea();
        }

        private bool CheckInversion(RCT2ElementProperty property)
        {
            //Check for ride inversions
            if ((property.InputTrackBank != RCT2ElementProperty.RCT2TrackBank.Flipped && property.OutputTrackBank == RCT2ElementProperty.RCT2TrackBank.Flipped) ||
                (property.InputTrackBank == RCT2ElementProperty.RCT2TrackBank.Flipped && property.OutputTrackBank != RCT2ElementProperty.RCT2TrackBank.Flipped))
            {
                return true;
            }

            return false;
        }

        private float CalcVelocity(float currentVelocity, RCT2TrackElements.RCT2TrackElement element, RCT2ElementProperty property)
        {
            //Check if it's a Chain lift or a station
            if (element == RCT2TrackElements.RCT2TrackElement.PoweredLift ||
                element == RCT2TrackElements.RCT2TrackElement.CableLiftHill ||
                element == RCT2TrackElements.RCT2TrackElement.LeftCurvedLiftHill ||
                element == RCT2TrackElements.RCT2TrackElement.RightCurvedLiftHill ||
                element == RCT2TrackElements.RCT2TrackElement.BeginStation ||
                element == RCT2TrackElements.RCT2TrackElement.MiddleStation ||
                element == RCT2TrackElements.RCT2TrackElement.EndStation)
            {
                return Math.Max(currentVelocity, ChainLiftSpeed);
            }

            float acceleration = 0;

            //Try to get current acceleration from the map
            try
            {
                acceleration = RCT2ElementProperty.TrackAccelerationMap[(int)property.Displacement.Y];
            }
            catch
            {
                Console.WriteLine($"Unable to find acceleration value for track piece {element.ToString()}");
            }

            return currentVelocity + acceleration;
        }

        public void Parse(string rawData)
        {
            //TODO
        }
    }
}
