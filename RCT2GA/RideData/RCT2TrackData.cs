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
        public float MaxPositiveG { get; }
        public float MaxNegativeG { get; }
        public float MaxLateralG { get; }
        public float AvgPositiveG { get; }
        public float AvgNegativeG { get; }
        public float AvgLateralG { get; }


        public RCT2TrackData()
        {
            TrackData = new List<RCT2TrackPiece>();
        }

        public bool CheckValidity()
        {
            //TODO
            return true;
        }

        public float CalculateExcitement()
        {
            //G Force
            //(0.08 * max pos g) + (0.24 * clamp(-2.5, max neg g, 0)) + (0.4 * min(1.5, max lat g))
            //If lat g is above 3.1, rating is halved
            //Multiplied by ride constant

            //Drops
            //(0.11 * min(9, num of drops)) + (0.0049 * highest drop)
            //Multiplied by ride constant

            //Inversions
            //(0.27 * min(6, num inversions))

            //Scenery
            //Ignore

            //Proximity
            //Ignore

            //Synchronized Stations
            //A fixed constant is added

            //Track Length
            //track length * ride constant
            //Ride specific cap for length also

            //Train Length
            //Each additional car after 1 adds a fixed ride specific quantity to excitement

            //Speed
            //Max speed * ride specific constant
            //Avg Speed * ride specific constant

            //Penalties for low stats
            //Each ride has it's own min threshold for
                //Drop height
                //Max Speed
                //Number of Drops
                //Max Neg Gs
                //Max Lat Gs
            //Failing to meet these causes all 3 ratings to be divided by a ride-specific constant


            //Too High Intensity
            //If Intensity > 10 excitement is decreased by 25%
            //If Intensity > 11 excitement is decreased by 25% again
            //If Intensity > 12 excitement is decreased by 25% again
            //If Intensity > 13.2 excitement is decreased by 25% again
            //If Intensity > 14.5 excitement is decreased by 25% again


            return 0;
        }

        public float CalculateIntensity()
        {
            //G-Force Ride Rating
            //(0.8 * max positive G) + (0.8 * 1- max negative g) + max lateral g
            //If lat g is above 2.8, a value of 3.75 is added to intensity
            //If lat g also exceeds 3.1 then 8.5 added to intensity
            //Multiplied by ride constant

            //Ride Drops
            //(0.14 * num of drops) + (0.0098 * highest drop)
            //Multiplied by ride specific constant

            //Inversions
            //(0.5 * num of inversions)

            //Scenery
            //Changes based on placement Ignore (minimum between number of scenery items surrounding, and 47) * 5

            //Proximity
            //Changes based on placement Ignore

            //Synchronized Stations
            //Constant is added based on ride type

            //Speed
            //Max speed multiplied by three ride specific constants and then added to each rating
            //Average rating multiplied by 2 constants and applied to excitement/intensity

            //Penalties for low stats
            //Each ride has it's own min threshold for
                //Drop height
                //Max Speed
                //Number of Drops
                //Max Neg Gs
                //Max Lat Gs
            //Failing to meet these causes all 3 ratings to be divided by a ride-specific constant

            return 0;
        }

        public float CalculateNausea()
        {
            //G Force
            //(0.26 * max positive g) + (0.22 * 1-max neg g) + 0.33 * max lat g
            //if lat g above 2.8, then 2 added to nausea
            //If lat g also above 3.1, 4 added to nausea
            //Multiplied by constant dependint on ride type

            //Drops
            // (0.1 * num of drops) + (0.0016 * highest drop)
            //Valculated by ride specific constant

            //Inversions
            //0.22 * num of inversions

            //Scenery
            //Ignore

            //Proximity
            //Ignore

            //Speed
            //Max speed multiplied by ride specific constant
            //Avg speed isnt used

            //Penalties for low stats
            //Each ride has it's own min threshold for
                //Drop height
                //Max Speed
                //Number of Drops
                //Max Neg Gs
                //Max Lat Gs
            //Failing to meet these causes all 3 ratings to be divided by a ride-specific constant

            return 0;
        }

        public int CalculateNumOfInversions()
        {
            //TODO
            return 0;
        }

        public int CalculateNumOfDrops()
        {
            //TODO
            return 0;
        }

        public float CalculateHighestDrop()
        {
            //TODO
            return 0;
        }

        public int CalculateAirTimeInSecsOverFour()
        {
            //TODO
            return 0;
        }

        public float CalculateAverageSpeedOfRide()
        {
            //TODO
            return 0;
        }

        public int CalculateRideLength()
        {
            //TODO
            return TrackData.Count();
        }

        public float CalculatePosGForce()
        {
            //TODO
            return 0;
        }

        public float CalculateNegGForce()
        {
            //TODO
            return 0;
        }

        public float CalculateLatGForce()
        {
            //TODO
            //https://github.com/OpenRCT2/OpenRCT2/blob/3da10b7d7db8fe60ca6cb1e277f39abe532e956b/src/ride/vehicle.c#L4960
            

            
            

            return 0;
        }

        private void GetTrackGForces(RCT2TrackElements.RCT2TrackElement track, out float posG, out float negG, out float latG)
        {

        }

        public void Parse(string rawData)
        {
            //TODO
        }
    }
}
