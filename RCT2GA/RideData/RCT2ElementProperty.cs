﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2ElementProperty
    {
        public enum RCT2TrackDegree {   None,
                                        Up25,
                                        Up60,
                                        Down25,
                                        Down60,
                                        Up90,
                                        Down90  };

        public enum RCT2TrackBank {     None,
                                        Left,
                                        Right,
                                        Flipped };

        public enum RCT2TrackDirectionChange {   Straight,
                                                    Left45,
                                                    Right45,
                                                    Left90,
                                                    Right90,
                                                    Reverse180,
                                                    DiagonalStraight,
                                                    DiagonalLeft,
                                                    DiagonalRight };

        //Static dictionary to keep track of what the enums mean numerically, will reference in validation
        public static Dictionary<RCT2TrackDirectionChange, float> TrackDirectionChangeMap = new Dictionary<RCT2TrackDirectionChange, float>()
        {
            { RCT2TrackDirectionChange.Straight, 0 },
            { RCT2TrackDirectionChange.Left45, -45 },
            { RCT2TrackDirectionChange.Right45, 45 },
            { RCT2TrackDirectionChange.Left90, -90 },
            { RCT2TrackDirectionChange.Right90, 90 },
            { RCT2TrackDirectionChange.Reverse180, 180 },
            { RCT2TrackDirectionChange.DiagonalStraight, 0 },
            { RCT2TrackDirectionChange.DiagonalLeft, -45 },
            { RCT2TrackDirectionChange.DiagonalRight, 45 }
        };

        //Acceleration Map
        //Data extracted from https://github.com/kevinburke/rct/blob/master/physics/physics.go#L24
        public static Dictionary<int, float> TrackAccelerationMap = new Dictionary<int, float>()
        {
            { 8, 7 },
            { 4, 2.37f },   //Hack value, average between 7 and 1.4
            { 2, 1.4f },
            { 1, 0.7f },
            { 0, -0.1f },
            { -1, -0.75f }, //Neg numbers have higher coefficient
            { -2, -1.45f },
            { -4, -2.40f },
            { -8, -7 }
        };

        public RCT2TrackDegree InputTrackDegree { get; set; }
        public RCT2TrackDegree OutputTrackDegree { get; set; }
        public RCT2TrackBank InputTrackBank { get; set; }
        public RCT2TrackBank OutputTrackBank { get; set; }
        public RCT2TrackDirectionChange DirectionChange { get; set; }
        //X = Sideways, Y = Height, Z = Forward
        public Vector3 Displacement { get; set; }
    }
}