using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2TrackPiece
    {
        public RCT2TrackElements.RCT2TrackElement TrackElement { get; set; }
        public RCT2Qualifier Qualifier { get; set; }

        public void GetGForces(float velocity, out float lateralG, out float verticalG)
        {
            //Get the G force factors for this piece
            RCT2TrackElements.GForceFactors gForceFactors = RCT2TrackElements.TrackElementGForceFactorMap[TrackElement];

            //Init our G force vars
            float latG = 0;
            float vertG = 0;

            //If the vertical isnt 0
            if (gForceFactors.VerticalGFactor != 0)
            {
                //Apply the vehicle velocity
                vertG += (Math.Abs(velocity) * 98 / gForceFactors.VerticalGFactor);
            }

            //If the lateral isnt 0
            if (gForceFactors.LateralGFactor != 0)
            {
                //Apply the vehicle velocity
                latG += (Math.Abs(velocity) * 98 / gForceFactors.LateralGFactor);
            }

            //Apply other modifications
            vertG *= 10;
            latG *= 10;

            //Trim them down to short length
            vertG /= 32;
            latG /= 32;

            lateralG = latG;
            verticalG = vertG;

            /* - I think this is done to shove it into the first 4 bits and trim the rest, we'll just trim at the end
            */
            //verticalG  >>= 16;
            //lateralG >>= 16;

            ////Trim them down to short length
            //verticalG &= 0xFFFF;
            //lateralG &= 0xFFFF;

            //Divide by 8 and clamp to -127 +127
            //lateralG /= 8;
            //verticalG /= 8;
            //lateralG = (lateralG < -127) ? -127 : (lateralG > 127) ? 127 : lateralG;
            //verticalG = (verticalG < -127) ? -127 : (verticalG > 127) ? 127 : verticalG;
        }
    }
}
