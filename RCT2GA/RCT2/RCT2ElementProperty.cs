using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RCT2
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

        public RCT2TrackDegree InputTrackDegree { get; set; }
        public RCT2TrackDegree OutputTrackDegree { get; set; }
        public RCT2TrackBank InputTrackBank { get; set; }
        public RCT2TrackBank OutputTrackBank { get; set; }
        public RCT2TrackDirectionChange DirectionChange { get; set; }
        //X = Sideways, Y = Height, Z = Forward
        // - Left + Right
        // - Down + Up
        // - Forward + Back
        public Vector3 SHFChange { get; set; }
    }
}
