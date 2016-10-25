using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RCT2
{
    class RCT2TrackData
    {
        public List<RCT2TrackPiece> TrackData { get; set; }

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
            //TODO
            return 0;
        }

        public float CalculateIntensity()
        {
            //TODO
            return 0;
        }

        public float CalculateNausea()
        {
            //TODO
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
            return 0;
        }

        public void Parse(string rawData)
        {
            //TODO
        }
    }
}
