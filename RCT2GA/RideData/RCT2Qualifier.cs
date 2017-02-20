using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2Qualifier
    {
        public enum RCT2QualifierRotation { Neg180,
                                            Neg135,
                                            Neg90,
                                            Neg45,
                                            Zero,
                                            Pos45,
                                            Pos90,
                                            Pos135,
                                            Pos180 };

        public short TrackColourSchemeNumber { get; set; }
        public RCT2QualifierRotation TrackRotation { get; set; }
        public bool AtTerminalStation { get; set; }
        public short StationNumber { get; set; }
    }
}
