using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2TrackData
    {
        public enum InvalidityCode { Intersection, NegativeVelocity, DoesntConnectToPrior, ExceedMaxHeight, ExceedMinHeight, NoTrack, TwoRidePhotos, Valid }
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
        bool hasRidePhoto = false;

        //Wooden Roller Coaster Min Data
        //Move to a Ride Structure eventually
        const int PTCT2MinDropHeight = 12;
        const int PTCT2MinMaxSpeed = 0xA;
        const float PTCT2MinNegG = 0.1f;
        const int PTCT2MinLength = 370;
        const int PTCT2MinNumDrops = 2;

        public RCT2TrackData()
        {
            TrackData = new List<RCT2TrackPiece>();
        }

        public RCT2TrackData(RCT2TrackData trackData)
        {
            TrackData = new List<RCT2TrackPiece>();
            TrackData.AddRange(trackData.TrackData);
            MaxPositiveG = trackData.MaxPositiveG;
            MaxNegativeG = trackData.MaxNegativeG;
            MaxLateralG = trackData.MaxLateralG;
            AirTimeInSeconds = trackData.AirTimeInSeconds;
            NumOfInversions = trackData.NumOfInversions;
            NumOfDrops = trackData.NumOfDrops;
            HighestDrop = trackData.HighestDrop;
            AverageSpeed = trackData.AverageSpeed;
            MaxSpeed = trackData.MaxSpeed;
            Excitement = trackData.Excitement;
            Intensity = trackData.Intensity;
            Nausea = trackData.Nausea;
        }

        public InvalidityCode CheckValidity()
        {
            //Following Validity Checks:
            // - All Track Pieces connect to the one before it
            // - Track doesn't intersect with itself
            // - Track doesn't exceed max height
            // - Track doesn't go underground (Go lower than the station height)
            // - Track's velocity doesn't go negative
            // - Track has more than one OnRidePhoto

            if (TrackData.Count <= 0)
            {
                return InvalidityCode.NoTrack;
            }

            //Negative Velocity
            if (!velocityChecked)
            {
                PopulateRideStatistics();
            }

            if (velocityGoesNegative)
            {
                return InvalidityCode.NegativeVelocity;
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

                // OnRidePhoto Checks
                if (currentElement == RCT2TrackElements.RCT2TrackElement.OnRidePhoto)
                {
                    if (hasRidePhoto)
                    {
                        return InvalidityCode.TwoRidePhotos;
                    }
                    else
                    {
                        hasRidePhoto = true;
                    }
                }

                // Height Checks
                currentYDisplacement += property.Displacement.Y;
                if (currentYDisplacement >= MaxUnitsOfDisplacement)
                {
                    return InvalidityCode.ExceedMaxHeight;
                }
                if (currentYDisplacement < 0)
                {
                    return InvalidityCode.ExceedMinHeight;
                }

                //Prev Element Matching Test
                if (i > 0 &&
                    (prevElementProperty.OutputTrackBank != property.InputTrackBank ||
                     prevElementProperty.OutputTrackDegree != property.InputTrackDegree))
                {
                    return InvalidityCode.DoesntConnectToPrior;
                }

                //Intersection Tests
                //Get the world version of our property displacement
                //ie, if the segment moves 1 forward, but is already rotated to the left
                //    by 90°, then it actually moves right by 1
                Vector3 worldDisplacement = LocalDisplacementToWorld(property.Displacement, worldDirectionChange);
                Vector3 testCell = prevWorldPos;
                //Check every tile used in this segment
                //Code is so gross Im so sorry
                for (int x = 1; x <= Math.Abs(worldDisplacement.X); x++)
                {
                    testCell = prevWorldPos + new Vector3(Math.Sign(worldDisplacement.X) * (x), 0, 0);
                    if (!UsedCells.Contains(testCell))
                    {
                        UsedCells.Add(testCell);
                    }
                    else
                    {
                        return InvalidityCode.Intersection;
                    }
                }
                prevWorldPos = testCell;
                for (int y = 1; y <= Math.Abs(worldDisplacement.Y); y++)
                {
                    testCell = prevWorldPos + new Vector3(0, Math.Sign(worldDisplacement.Y) * (y), 0);
                    if (!UsedCells.Contains(testCell))
                    {
                        UsedCells.Add(testCell);
                    }
                    else
                    {
                        return InvalidityCode.Intersection;
                    }
                }
                prevWorldPos = testCell;
                for (int z = 1; z <= Math.Abs(worldDisplacement.Z); z++)
                {
                    testCell = prevWorldPos + new Vector3(0, 0, Math.Sign(worldDisplacement.Z) * (z));
                    if (!UsedCells.Contains(testCell))
                    {
                        UsedCells.Add(testCell);
                    }
                    else
                    {
                        return InvalidityCode.Intersection;
                    }
                }
                prevWorldPos = testCell;

                //Update World Direction Changes
                worldDirectionChange = UpdateRotation(worldDirectionChange, property.DirectionChange);

                //Update variables
                prevElementProperty = property;
            }

            return InvalidityCode.Valid;
        }

        //public void AutoComplete()
        //{
        //    //Find the end rotation & world position
        //    Vector3 prevWorldPos = new Vector3(0.0f, 0.0f, 0.0f);
        //    List<RCT2TrackElements.RCT2TrackElement> additionalElements = new List<RCT2TrackElements.RCT2TrackElement>();
        //    int worldDirectionChange = 0;
        //    for (int i = 0; i < TrackData.Count; i++)
        //    {
        //        RCT2TrackElements.RCT2TrackElement currentElement = TrackData[i].TrackElement;
        //        RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[currentElement];

        //        Vector3 worldDisplacement = LocalDisplacementToWorld(property.Displacement, worldDirectionChange);

        //        //Update World Position Changes
        //        prevWorldPos += worldDisplacement;

        //        //Update World Direction Changes
        //        worldDirectionChange = UpdateRotation(worldDirectionChange, property.DirectionChange);
        //    }

        //    //We now have the end of track position, and the start of the track position (0, 0, 0) As well as the rotation
        //    //Flat out whatever track piece we're on
        //    //TODO - change to add qualifiers too
        //    switch (TrackData[TrackData.Count - 2].TrackElement)
        //    {
        //        case RCT2TrackElements.RCT2TrackElement.Decline25:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Decline25ToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.Decline60:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Decline60To25);
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Decline25ToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.Incline25:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Incline25ToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.Incline60:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Incline60To25);
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Incline25ToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.Incline25LeftBanked:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.LeftBankIncline25ToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.Incline25RightBanked:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.RightBankIncline25ToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.Decline25LeftBanked:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.LeftBankDecline25ToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.Decline25RightBanked:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.RightBankDecline25ToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.LeftBank:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.LeftBankToFlat);
        //            break;
        //        case RCT2TrackElements.RCT2TrackElement.RightBank:
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.RightBankToFlat);
        //            break;
        //    }

        //    //Get to ground level
        //    if (prevWorldPos.Y > 0)
        //    {
        //        int groundDistance = (int)prevWorldPos.Y;

        //        additionalElements.Add(RCT2TrackElements.RCT2TrackElement.FlatToDecline25);
        //        for (int i = 0; i < groundDistance - 2; i++)
        //        {
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Decline25);
        //        }
        //        additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Decline25ToFlat);
        //    }


        //    additionalElements.AddRange(ConnectTracks2D(prevWorldPos, new Vector3(0, 0, 0), worldDirectionChange));
        //}

        //private List<RCT2TrackElements.RCT2TrackElement> ConnectTracks2D(Vector3 startPosition, Vector3 endPosition, float currentRotation)
        //{
        //    List<RCT2TrackElements.RCT2TrackElement> additionalElements = new List<RCT2TrackElements.RCT2TrackElement>();
        //    Vector3 prevWorldPos = new Vector3(startPosition);

        //    //It is now a 2D connection problem as opposed to a 3D
        //    //So now let's connect along a 2D axis
        //    switch ((int)currentRotation)
        //    {
        //        case 0:
        //            //Same direction as the station
        //            SameDirectionConnect2D(prevWorldPos, new Vector3(0, 0, 0));
        //            break;
        //        case -90:
        //            //Left Facing, Rotate to right
        //            LeftDirectionConnect2D(prevWorldPos, new Vector3(0, 0, 0));
        //            break;
        //        case 180:
        //            //Opposite Direction
        //            OppositeDirectionConnect2D(prevWorldPos, new Vector3(0, 0, 0));
        //            break;
        //        case 90:
        //            //Right Facing, Rotate to left
        //            RightDirectionConnect2D(prevWorldPos, new Vector3(0, 0, 0));
        //            break;
        //    }

        //    return additionalElements;
        //}

        //private List<RCT2TrackElements.RCT2TrackElement> SameDirectionConnect2D(Vector3 startPosition, Vector3 endPosition)
        //{
        //    List<RCT2TrackElements.RCT2TrackElement> additionalElements = new List<RCT2TrackElements.RCT2TrackElement>();
        //    Vector3 prevWorldPos = new Vector3(startPosition);

        //    //If theyre the same value we're at the end so we're good
        //    if (startPosition == endPosition)
        //    {
        //        return additionalElements;
        //    }

        //    Vector3 difference = endPosition - startPosition;

        //    //If the X values are the same
        //    if (startPosition.X == endPosition.X)
        //    {
        //        for (int i = 0; i < Math.Abs(difference.Z); i++)
        //        {
        //            additionalElements.Add(RCT2TrackElements.RCT2TrackElement.Flat);
        //        }
        //    }
        //    else if (Math.Abs(difference.Z) / 3 >= Math.Abs(difference.X))
        //    {
        //        RCT2TrackElements.RCT2TrackElement element = difference.X < 0 ? RCT2TrackElements.RCT2TrackElement.RightSBend : RCT2TrackElements.RCT2TrackElement.LeftSBend;
        //        additionalElements.Add(element);
        //        prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, 0);
        //        additionalElements.AddRange(SameDirectionConnect2D(prevWorldPos, endPosition));
        //    }
        //    else if (Math.Abs(difference.X) > 3)
        //    {
        //        if (difference.Z < 0)
        //        {
        //            RCT2TrackElements.RCT2TrackElement element = RCT2TrackElements.RCT2TrackElement.RightQuarterTurnAcross3;
        //            additionalElements.Add(element);
        //            prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, 0);
        //            additionalElements.AddRange(SameDirectionConnect2D(prevWorldPos, endPosition));
        //        }
        //        else
        //        {
        //            RCT2TrackElements.RCT2TrackElement element = RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross3;
        //            additionalElements.Add(element);
        //            prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, 0);
        //            additionalElements.AddRange(SameDirectionConnect2D(prevWorldPos, endPosition));
        //        }
        //    }
        //    else
        //    {
        //        //we're too close to solve it with this rudimentry system
        //        //ie - if we'd need to go back out to come back in
        //        Console.WriteLine("ERROR: Autocomplete failed to match up with rudimentry check");
        //    }

        //    return additionalElements;
        //}

        //private List<RCT2TrackElements.RCT2TrackElement> LeftDirectionConnect2D(Vector3 startPosition, Vector3 endPosition)
        //{
        //    List<RCT2TrackElements.RCT2TrackElement> additionalElements = new List<RCT2TrackElements.RCT2TrackElement>();
        //    Vector3 prevWorldPos = new Vector3(startPosition);
        //    Vector3 difference = endPosition - prevWorldPos;
        //    if ((difference.Z >= 0 && difference.X < -2) || difference.X > 0)
        //    {
        //        //We're ahead of the start point, turn left so we're moving away from it
        //        //Or we're facing away from the track, so let's orient away from it also
        //        RCT2TrackElements.RCT2TrackElement element = RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross3;
        //        additionalElements.Add(element);
        //        prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, -90);
        //        additionalElements.AddRange(OppositeDirectionConnect2D(prevWorldPos, endPosition));

        //    }
        //    else if (difference.X == -3 || difference.X < -5)
        //    {
        //        RCT2TrackElements.RCT2TrackElement element = RCT2TrackElements.RCT2TrackElement.RightQuarterTurnAcross5;
        //        additionalElements.Add(element);
        //        prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, -90);
        //        additionalElements.AddRange(SameDirectionConnect2D(prevWorldPos, endPosition));
        //    }
        //    else if (difference.X == -5)
        //    {
        //        RCT2TrackElements.RCT2TrackElement element = RCT2TrackElements.RCT2TrackElement.RightQuarterTurnAcross5;
        //        additionalElements.Add(element);
        //        prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, -90);
        //        additionalElements.AddRange(SameDirectionConnect2D(prevWorldPos, endPosition));
        //    }
        //    else
        //    {
        //        //we're too close to solve it with this rudimentry system
        //        //ie - if we'd need to go back out to come back in
        //        Console.WriteLine("ERROR: Autocomplete failed to match up with rudimentry check");
        //    }

        //    return additionalElements;
        //}

        //private List<RCT2TrackElements.RCT2TrackElement> OppositeDirectionConnect2D(Vector3 startPosition, Vector3 endPosition)
        //{
        //    List<RCT2TrackElements.RCT2TrackElement> additionalElements = new List<RCT2TrackElements.RCT2TrackElement>();
        //    Vector3 prevWorldPos = new Vector3(startPosition);



        //    return additionalElements;
        //}

        //private List<RCT2TrackElements.RCT2TrackElement> RightDirectionConnect2D(Vector3 startPosition, Vector3 endPosition)
        //{
        //    List<RCT2TrackElements.RCT2TrackElement> additionalElements = new List<RCT2TrackElements.RCT2TrackElement>();
        //    Vector3 prevWorldPos = new Vector3(startPosition);
        //    Vector3 difference = endPosition - prevWorldPos;
        //    if ((difference.Z >= 0 && difference.X < 2) || difference.X > 0)
        //    {
        //        //We're ahead of the start point, turn left so we're moving away from it
        //        //Or we're facing away from the track, so let's orient away from it also
        //        RCT2TrackElements.RCT2TrackElement element = RCT2TrackElements.RCT2TrackElement.RightQuarterTurnAcross3;
        //        additionalElements.Add(element);
        //        prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, 90);
        //        additionalElements.AddRange(OppositeDirectionConnect2D(prevWorldPos, endPosition));

        //    }
        //    else if (difference.X == 3 || difference.X < 5)
        //    {
        //        RCT2TrackElements.RCT2TrackElement element = RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross5;
        //        additionalElements.Add(element);
        //        prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, 90);
        //        additionalElements.AddRange(SameDirectionConnect2D(prevWorldPos, endPosition));
        //    }
        //    else if (difference.X == 5)
        //    {
        //        RCT2TrackElements.RCT2TrackElement element = RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross5;
        //        additionalElements.Add(element);
        //        prevWorldPos += LocalDisplacementToWorld(RCT2TrackElements.TrackElementPropertyMap[element].Displacement, 90);
        //        additionalElements.AddRange(SameDirectionConnect2D(prevWorldPos, endPosition));
        //    }
        //    else
        //    {
        //        //we're too close to solve it with this rudimentry system
        //        //ie - if we'd need to go back out to come back in
        //        Console.WriteLine("ERROR: Autocomplete failed to match up with rudimentry check");
        //    }

        //    return additionalElements;
        //}

        private float CalculateExcitement()
        {
            float tempExcitement = 0;
            //G Force
            //(0.08 * max pos g) + (0.24 * clamp(-2.5, max neg g, 0)) + (0.4 * min(1.5, max lat g))
            float clampedNeg = (MaxNegativeG < -2.5f) ? -2.5f : (MaxNegativeG > 0) ? 0 : MaxNegativeG;
            float gForceComponent = (0.08f * MaxPositiveG) + (0.24f * clampedNeg) + (0.4f * Math.Min(1.5f, MaxLateralG));

            //Drops
            //(0.11 * min(9, num of drops)) + (0.0049 * highest drop)
            float dropComponent = (0.11f * Math.Min(0, NumOfDrops)) + (0.0049f * HighestDrop);

            //Inversions
            //(0.27 * min(6, num inversions))
            float inversionComponent = (0.27f * Math.Min(6, NumOfInversions));

            //Track Length
            //track length * ride constant
            //Ride specific cap for length also
            float trackLengthComponent = TrackData.Count;

            //Speed
            //Max speed * ride specific constant
            //Avg Speed * ride specific constant
            float maxSpeedComponent = MaxSpeed;
            float avgSpeedComponent = AverageSpeed;


            tempExcitement = gForceComponent + dropComponent + inversionComponent + maxSpeedComponent + avgSpeedComponent + trackLengthComponent;

            return tempExcitement;
        }

        private float CalculateIntensity()
        {
            float tempIntensity = 0;
            //G-Force Ride Rating
            //(0.8 * max positive G) + (0.8 * 1- max negative g) + max lateral g
            float gForceComponent = (0.8f * MaxPositiveG) + (0.8f * (1 - MaxNegativeG)) + MaxLateralG;
            if (MaxLateralG > 2.8f)
            {
                gForceComponent += 3.75f;
                if (MaxLateralG > 3.1f)
                {
                    gForceComponent += 8.5f;
                }
            }

            //Ride Drops
            float rideDropComponent = (0.14f * NumOfDrops) + (0.0098f * HighestDrop);

            //Inversions
            float inversionComponent = (0.5f * NumOfInversions);

            //Speed
            //Max speed multiplied by three ride specific constants and then added to each rating
            //Average rating multiplied by 2 constants and applied to excitement/intensity
            float maxSpeedComponent = MaxSpeed;
            float avgSpeedComponent = AverageSpeed;

            tempIntensity = gForceComponent + rideDropComponent + inversionComponent + maxSpeedComponent + avgSpeedComponent;

            return tempIntensity;
        }

        private float CalculateNausea()
        {
            float tempNausea = 0;
            //G Force
            //(0.26 * max positive g) + (0.22 * 1-max neg g) + 0.33 * max lat g
            float gForceComponent = (0.26f * MaxPositiveG) + (0.22f * (1 - MaxNegativeG)) + (0.33f * MaxLateralG);
            if (MaxLateralG > 2.8f)
            {
                gForceComponent += 2;
                if (MaxLateralG > 3.1f)
                {
                    gForceComponent += 4;
                }
            }

            //Drops
            // (0.1 * num of drops) + (0.0016 * highest drop)
            //Calculated by ride specific constant
            float dropComponent = (0.1f * NumOfDrops) + (0.0016f * HighestDrop);

            //Inversions
            //0.22 * num of inversions
            float inversionComponent = (0.22f * NumOfInversions);

            //Speed
            //Max speed multiplied by ride specific constant
            //Avg speed isnt used
            float maxSpeedComponent = MaxSpeed; //TODO

            tempNausea = gForceComponent + dropComponent + inversionComponent + maxSpeedComponent;

            return tempNausea;
        }

        private void ApplyPenalties(ref float excitement, ref float intensity, ref float nausea)
        {
            //Too high Lateral G
            //If lat g is above 3.1, excitement rating is halved
            if (MaxLateralG > 3.1f)
            {
                excitement /= 2;
            }

            //If lat g is above 2.8, a value of 3.75 is added to intensity
            if (MaxLateralG > 2.8f)
            {
                intensity += 3.75f;
            }

            //If lat g also exceeds 3.1 then 8.5 added to intensity
            if (MaxLateralG > 3.1f)
            {
                intensity += 8.5f;
            }

            //if lat g above 2.8, then 2 added to nausea
            if (MaxLateralG > 2.8f)
            {
                nausea += 2;
            }

            //If lat g also above 3.1, 4 added to nausea
            if (MaxLateralG > 3.1f)
            {
                nausea += 4;
            }

            //Too High Intensity
            //If Intensity > 10 excitement is decreased by 25%
            if (intensity > 10)
            {
                excitement *= 0.75f;
            }
            //If Intensity > 11 excitement is decreased by 25% again
            if (intensity > 11)
            {
                excitement *= 0.75f;
            }
            //If Intensity > 12 excitement is decreased by 25% again
            if (intensity > 12)
            {
                excitement *= 0.75f;
            }
            //If Intensity > 13.2 excitement is decreased by 25% again
            if (intensity > 13.2f)
            {
                excitement *= 0.75f;
            }
            //If Intensity > 14.5 excitement is decreased by 25% again
            if (intensity > 14.5f)
            {
                excitement *= 0.75f;
            }

            //Penalties for low stats
            //Each ride has it's own min threshold for
            //Drop height
            if (HighestDrop < PTCT2MinDropHeight)
            {
                excitement /= 2;
                intensity /= 2;
                nausea /= 2;
            }

            //Max Speed
            if (MaxSpeed < PTCT2MinMaxSpeed)
            {
                excitement /= 2;
                intensity /= 2;
                nausea /= 2;
            }

            //Number of Drops
            if (NumOfDrops < PTCT2MinNumDrops)
            {
                excitement /= 2;
                intensity /= 2;
                nausea /= 2;
            }

            //Max Neg Gs
            if (MaxNegativeG < PTCT2MinNegG)
            {
                excitement /= 2;
                intensity /= 2;
                nausea /= 2;
            }

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
                vertG /= 2;
                previousVertG = vertG;

                latG += previousLatG;
                latG /= 2;
                previousLatG = latG;

                latG = Math.Abs(latG);

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

            float localExcitement = CalculateExcitement();
            float localIntensity = CalculateIntensity();
            float localNausea = CalculateNausea();

            ApplyPenalties(ref localExcitement, ref localIntensity, ref localNausea);

            Excitement = localExcitement;
            Intensity = localIntensity;
            Nausea = localNausea;
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

        public Vector3 LocalDisplacementToWorld(Vector3 localDisplacement, int currentRotation)
        {
            //Get the world version of our property displacement
            //ie, if the segment moves 1 forward, but is already rotated to the left
            //    by 90°, then it actually moves right by 1

            //TODO
            //Doesn't work with Diagonals
            Vector3 worldDisplacement = new Vector3(localDisplacement);

            switch (currentRotation)
            {
                case -45:
                    //Not supported - TODO
                    goto default;
                case -90:
                    float left90z = worldDisplacement.X;
                    float left90x = -worldDisplacement.Z;

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
                    float right90z = -worldDisplacement.X;
                    float right90x = worldDisplacement.Z;

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

        public int UpdateRotation(int currentRotation, RCT2TrackElementProperty.RCT2TrackDirectionChange directionChange)
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

        //public void Parse(string rawData)
        //{
        //    //TODO
        //}
    }
}
