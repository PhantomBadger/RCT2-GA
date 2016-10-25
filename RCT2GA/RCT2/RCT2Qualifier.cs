﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RCT2
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
                                            Pos180,
                                            Pos225,
                                            Pos270,
                                            Pos315,
                                            Pos360,
                                            Pos405,
                                            Pos450,
                                            Pos495};

        public short TrackColourSchemeNumber { get; set; }
        public RCT2QualifierRotation TrackRotation { get; set; }
        public bool AtTerminalStation { get; set; }
        public short StationNumber { get; set; }
    }
}
