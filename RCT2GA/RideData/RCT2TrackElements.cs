using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2TrackElements
    {
        public enum RCT2TrackElement{   Flat,
                                        EndStation,
                                        BeginStation,
                                        MiddleStation,
                                        Incline25,
                                        Incline60,
                                        FlatToIncline25,
                                        Incline25To60,
                                        Incline60To25,
                                        Incline25ToFlat,
                                        Decline25,
                                        Decline60,
                                        FlatToDecline25,
                                        Decline25To60,
                                        Decline60To25,
                                        Decline25ToFlat,
                                        LeftQuarterTurnAcross5,
                                        RightQuarterTurnAcross5,
                                        FlatToLeftBank,
                                        FlatToRightBank,
                                        LeftBankToFlat,
                                        RightBankToFlat,
                                        LeftQuarterTurnBankAcross5,
                                        RightQuarterTurnBankAcross5,
                                        LeftBankToIncline25,
                                        RightBankToIncline25,
                                        Incline25ToLeftBank,
                                        Incline25ToRightBank,
                                        LeftBankToDecline25,
                                        RightBankToDecline25,
                                        Decline25ToLeftBank,
                                        Decline25ToRightBank,
                                        LeftBank,
                                        RightBank,
                                        LeftQuarterTurnIncline25Across5,
                                        RightQuarterTurnIncline25Across5,
                                        LeftQuarterTurnDecline25Across5,
                                        RightQuarterTurnDecline25Across5,
                                        LeftSBend,
                                        RightSBend,
                                        LeftVerticalLoop,
                                        RightVerticalLoop,
                                        LeftQuarterTurnAcross3,
                                        RightQuarterTurnAcross3,
                                        LeftQuarterTurnBankAcross3,
                                        RightQuarterTurnBankAcross3,
                                        LeftQuarterTurnIncline25Across3,
                                        RightQuarterTurnIncline25Across3,
                                        LeftQuarterTurnDecline25Across3,
                                        RightQuarterTurnDecline25Across3,
                                        LeftQuarterTurnAcross1,
                                        RightQuarterTurnAcross1,
                                        LeftTwistDownToUp,
                                        RightTwistDownToUp,
                                        LeftTwistUpToDown,
                                        RightTwistUpToDown,
                                        HalfLoopUp,
                                        HalfLoopDown,
                                        LeftCorkscrewUp,
                                        RightCorkscrewUp,
                                        LeftCorkscrewDown,
                                        RightCorkscrewDown,
                                        FlatToIncline60,
                                        Incline60ToFlat,
                                        FlatToDecline60,
                                        Decline60ToFlat,
                                        TowerBase,
                                        TowerSection,
                                        FlatCovered,
                                        Incline25Covered,
                                        Incline60Covered,
                                        FlatToIncline25Covered,
                                        Incline25To60Covered,
                                        Incline60To25Covered,
                                        Incline25ToFlatCovered,
                                        Decline25Covered,
                                        Decline60Covered,
                                        FlatToDecline25Covered,
                                        Decline25To60Covered,
                                        Decline60To25Covered,
                                        Decline25ToFlatCovered,
                                        LeftQuarterTurnCoveredAcross5,
                                        RightQuarterTurnCoveredAcross5,
                                        LeftSBendCovered,
                                        RightSBendCovered,
                                        LeftQuarterTurnCoveredAcross3,
                                        RightQuarterTurnCoveredAcross3,
                                        LeftHalfBankedHelixInclineSmall,
                                        RightHalfBankedHelixInclineSmall,
                                        LeftHalfBankedHelixDeclineSmall,
                                        RightHalfBankedHelixDeclineSmall,
                                        LeftHalfBankedHelixInclineLarge,
                                        RightHalfBankedHelixInclineLarge,
                                        LeftHalfBankedHelixDeclineLarge,
                                        RightHalfBankedHelixDeclineLarge,
                                        LeftQuarterTurnIncline60Across1,
                                        RightQuarterTurnIncline60Across1,
                                        LeftQuarterTurnDecline60Across1,
                                        RightQuarterTurnDecline60Across1,
                                        Brakes,
                                        RotationControlToggle_SpinningWildMouse,
                                        InvertedIncline90ToFlatQuarterLoop_Multidim,
                                        LeftQuarterTurnBankedHelixLargeIncline,
                                        RightQuarterTurnBankedHelixLargeIncline,
                                        LeftQuarterTurnBankedHelixLargeDecline,
                                        RightQuarterTurnBankedHelixLargeDecline,
                                        LeftQuarterTurnHelixLargeIncline,
                                        RightQuarterTurnHelixLargeIncline,
                                        LeftQuarterTurnHelixLargeDecline,
                                        RightQuarterTurnHelixLargeDecline,
                                        Incline25LeftBanked,
                                        Incline25RightBanked,
                                        Waterfall,
                                        Rapids,
                                        OnRidePhoto,
                                        Decline25LeftBanked,
                                        Decline25RightBanked,
                                        Watersplash,
                                        FlatToIncline60LongBase,
                                        Incline60ToFlatLongBase,
                                        Whirlpool,
                                        Decline60ToFlatLongBase,
                                        FlatToDecline60LongBase,
                                        CableLiftHill,
                                        ReverseWhoaBellySlope,
                                        ReverseWhoaBellyVertical,
                                        Incline90,
                                        Decline90,
                                        Incline60To90,
                                        Decline90To60,
                                        Incline90To60,
                                        Decline60To90,
                                        BrakeforDrop,
                                        LeftOneEighthTurnOTD,
                                        RightOneEighthTurnOTD,
                                        LeftOneEighthTurnDTO,
                                        RightOneEighthTurnDTO,
                                        LeftOneEighthBankOTD,
                                        RightOneEighthBankOTD,
                                        LeftOneEighthBankDTO,
                                        RightOneEighthBankDTO,
                                        DiagFlat,
                                        DiagIncline25,
                                        DiagIncline60,
                                        DiagFlatToIncline25,
                                        DiagIncline25To60,
                                        DiagIncline60To25,
                                        DiagIncline25ToFlat,
                                        DiagDecline25,
                                        DiagDecline60,
                                        DiagFlatToDecline25,
                                        DiagDecline25To60,
                                        DiagDecline60To25,
                                        DiagDecline25ToFlat,
                                        DiagFlatToIncline60,
                                        DiagIncline60ToFlat,
                                        DiagFlatToDecline60,
                                        DiagDecline60ToFlat,
                                        DiagFlatToLeftBank,
                                        DiagFlatToRightBank,
                                        DiagLeftBankToFlat,
                                        DiagRightBankToFlat,
                                        DiagLeftBankToIncline25,
                                        DiagRightBankToIncline25,
                                        DiagIncline25ToLeftBank,
                                        DiagIncline25ToRightBank,
                                        DiagLeftBankToDecline25,
                                        DiagRightBankToDecline25,
                                        DiagDecline25ToLeftBank,
                                        DiagDecline25ToRightBank,
                                        DiagLeftBank,
                                        DiagRightBank,
                                        LogFlumeReverser,
                                        SpinningTunnel,
                                        LeftBarrelRollUpToDown,
                                        RightBarrelRollUpToDown,
                                        LeftBarrelRollDownToUp,
                                        RightBarrelRollDownToUp,
                                        LeftBankToLeftQuarterTurnIncline25Across3,
                                        RightBankToRightQuarterTurnIncline25Across3,
                                        LeftQuarterTurnDecline25ToLeftBankAcross3,
                                        RightQuarterTurnDecline25ToRightBankAcross3,
                                        PoweredLift,
                                        LeftLargeHalfLoopUp,
                                        RightLargeHalfLoopUp,
                                        RightLargeHalfLoopDown,
                                        LeftLargeHalfLoopDown,
                                        LeftFlyerTwistUpToDown,
                                        RightFlyerTwistUpToDown,
                                        LeftFlyerTwistDownToUp,
                                        RightFlyerTwistDownToUp,
                                        FlyerHalfLoopUp,
                                        FlyerHalfLoopDown,
                                        LeftFlyCorkscrewUpToDown,
                                        RightFlyCorkscrewUpToDown,
                                        LeftFlyCorkscrewDownToUp,
                                        RightFlyCorkscrewDownToUp,
                                        HeartlineTransferUp,
                                        HeartlineTransferDown,
                                        LeftHeartlineRoll,
                                        RightHeartlineRoll,
                                        MinigolfHoleA,
                                        MinigolfHoleB,
                                        MinigolfHoleC,
                                        MinigolfHoleD,
                                        MinigolfHoleE,
                                        InvertedFlatToDecline90QuarterLoop_Multidim,
                                        QuarterLoopIncline90ToInvert,
                                        QuarterLoopInvertToDecline90,
                                        LeftCurvedLiftHill,
                                        RightCurvedLiftHill,
                                        LeftReverser,
                                        RightReverser,
                                        AirThrustTopCap,
                                        AirThrustVerticalDown,
                                        AirThrustVerticalDownToLevel,
                                        BlockBrakes,
                                        LeftQuarterTurnIncline25BankedAcross3,
                                        RightQuarterTurnIncline25BankedAcross3,
                                        LeftQuarterTurnDecline25BankedAcross3,
                                        RightQuarterTurnDecline25BankedAcross3,
                                        LeftQuarterTurnIncline25BankedAcross5,
                                        RightQuarterTurnIncline25BankedAcross5,
                                        LeftQuarterTurnDecline25BankedAcross5,
                                        RightQuarterTurnDecline25BankedAcross5,
                                        Incline25ToLeftBankIncline25,
                                        Incline25ToRightBankIncline25,
                                        LeftBankIncline25ToIncline25,
                                        RightBankIncline25ToIncline25,
                                        Decline25ToLeftBankDecline25,
                                        Decline25ToRightBankDecline25,
                                        LeftBankDecline25ToDecline25,
                                        RightBankDecline25ToDecline25,
                                        LeftBankFlatToLeftBankIncline25,
                                        RightBankFlatToRightBankIncline25,
                                        LeftBankIncline25ToLeftBankFlat,
                                        RightBankIncline25ToRightBankFlat,
                                        LeftBankFlatToLeftBankDecline25,
                                        RightBankFlatToRightBankDecline25,
                                        LeftBankDecline25ToLeftBankFlat,
                                        RightBankDecline25ToRightBankFlat,
                                        FlatToLeftBankIncline25,
                                        FlatToRightBankIncline25,
                                        LeftBankIncline25ToFlat,
                                        RightBankIncline25ToFlat,
                                        FlatToLeftBankDecline25,
                                        FlatToRightBankDecline25,
                                        LeftBankDecline25ToFlat,
                                        RightBankDecline25ToFlat,
                                        LeftQuarterTurnIncline90Across1,
                                        RightQuarterTurnIncline90Across1,
                                        LeftQuarterTurnDecline90Across1,
                                        RightQuarterTurnDecline90Across1,
                                        Incline90ToInvertedFlatQuarterLoop_Multidim,
                                        FlatToDecline90QuarterLoop_Multidim,
                                        EndOfTrack  };

        public struct GForceFactors
        {
            public float LateralGFactor;
            public float VerticalGFactor;

            public GForceFactors(float lat, float vert)
            {
                LateralGFactor = lat;
                VerticalGFactor = vert;
            }
        }

        //Property map to link the enum to the relevent property
        //Location Change data adapted from the information found by Kevin Burke and showcased
        //on his github //https://github.com/kevinburke/rct/blob/master/tracks/segment.go

        //Seems some values are incorrect, could cause issues with collisions
        public static Dictionary<RCT2TrackElement, RCT2ElementProperty> TrackElementPropertyMap = new Dictionary<RCT2TrackElement, RCT2ElementProperty>
        {
            { 
                RCT2TrackElement.Flat, new RCT2ElementProperty()
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.EndStation, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.BeginStation, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.MiddleStation, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1)
                }
            },
            { 
				RCT2TrackElement.Incline60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 8, 1)
                }
            },
            { 
				RCT2TrackElement.FlatToIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25To60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 4, 1)
                }
            },
            { 
				RCT2TrackElement.Incline60To25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 4, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 1)
                }
            },
            { 
				RCT2TrackElement.Decline60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -8, 1)
                }
            },
            { 
				RCT2TrackElement.FlatToDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25To60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -4, 1)
                }
            },
            { 
				RCT2TrackElement.Decline60To25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -4, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, 0, 3)
                }
            },
            { 
				RCT2TrackElement.FlatToLeftBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.FlatToRightBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.LeftBankToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.RightBankToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnBankAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnBankAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(3, 0, 3)
                }
            },
            { 
				RCT2TrackElement.LeftBankToIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            { 
				RCT2TrackElement.RightBankToIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25ToLeftBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25ToRightBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            { 
				RCT2TrackElement.LeftBankToDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            { 
				RCT2TrackElement.RightBankToDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25ToLeftBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25ToRightBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            { 
				RCT2TrackElement.LeftBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.RightBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnIncline25Across5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, 8, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnIncline25Across5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, 8, 3)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnDecline25Across5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, -8, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnDecline25Across5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, -8, 3)
                }
            },
            { 
				RCT2TrackElement.LeftSBend, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(-2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightSBend, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.LeftVerticalLoop, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(-2, 0, 2)
                }
            },
            { 
				RCT2TrackElement.RightVerticalLoop, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(2, 0, 2)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 0, 2)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 0, 2)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnBankAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 0, 2)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnBankAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 0, 2)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnIncline25Across3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 4, 2)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnIncline25Across3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 4, 2)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnDecline25Across3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, -4, 2)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnDecline25Across3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, -4, 2)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnAcross1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnAcross1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.LeftTwistDownToUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 3)
                }
            },
            { 
				RCT2TrackElement.RightTwistDownToUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 3)
                }
            },
            { 
				RCT2TrackElement.LeftTwistUpToDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 3)
                }
            },
            { 
				RCT2TrackElement.RightTwistUpToDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 3)
                }
            },
            { 
				RCT2TrackElement.HalfLoopUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, 19, 2)
                }
            },
            { 
				RCT2TrackElement.HalfLoopDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, -13, 0)
                }
            },
            { 
				RCT2TrackElement.LeftCorkscrewUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 10, 2)
                }
            },
            { 
				RCT2TrackElement.RightCorkscrewUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 10, 2)
                }
            },
            { 
				RCT2TrackElement.LeftCorkscrewDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, -10, 2)
                }
            },
            { 
				RCT2TrackElement.RightCorkscrewDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, -10, 2)
                }
            },
            { 
				RCT2TrackElement.FlatToIncline60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 3, 1)
                }
            },
            { 
				RCT2TrackElement.Incline60ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 3, 1)
                }
            },
            { 
				RCT2TrackElement.FlatToDecline60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -3, 1)
                }
            },
            { 
				RCT2TrackElement.Decline60ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -3, 1)
                }
            },
            { 
				RCT2TrackElement.TowerBase, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 12, 0)
                }
            },
            { 
				RCT2TrackElement.TowerSection, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 4, 0)
                }
            },
            { 
				RCT2TrackElement.FlatCovered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1)
                }
            },
            { 
				RCT2TrackElement.Incline60Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 8, 1)
                }
            },
            { 
				RCT2TrackElement.FlatToIncline25Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25To60Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 4, 1)
                }
            },
            { 
				RCT2TrackElement.Incline60To25Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 4, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25ToFlatCovered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 1)
                }
            },
            { 
				RCT2TrackElement.Decline60Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -8, 1)
                }
            },
            { 
				RCT2TrackElement.FlatToDecline25Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25To60Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -4, 1)
                }
            },
            { 
				RCT2TrackElement.Decline60To25Covered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -4, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25ToFlatCovered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnCoveredAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnCoveredAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, 0, 3)
                }
            },
            { 
				RCT2TrackElement.LeftSBendCovered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(-2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightSBendCovered, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnCoveredAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 0, 2)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnCoveredAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 0, 2)
                }
            },
            { 
				RCT2TrackElement.LeftHalfBankedHelixInclineSmall, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(-4, 2, 1)
                }
            },
            { 
				RCT2TrackElement.RightHalfBankedHelixInclineSmall, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(4, 2, 1)
                }
            },
            { 
				RCT2TrackElement.LeftHalfBankedHelixDeclineSmall, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(-4, -2, 1)
                }
            },
            { 
				RCT2TrackElement.RightHalfBankedHelixDeclineSmall, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(4, -2, 1)
                }
            },
            { 
				RCT2TrackElement.LeftHalfBankedHelixInclineLarge, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(-4, 2, 1)
                }
            },
            { 
				RCT2TrackElement.RightHalfBankedHelixInclineLarge, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(4, 2, 1)
                }
            },
            { 
				RCT2TrackElement.LeftHalfBankedHelixDeclineLarge, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(-4, -2, 1)
                }
            },
            { 
				RCT2TrackElement.RightHalfBankedHelixDeclineLarge, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(4, -2, 1)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnIncline60Across1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(0, 8, 1)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnIncline60Across1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(0, 8, 1)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnDecline60Across1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(0, -8, 1)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnDecline60Across1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(0, -8, 1)
                }
            },
            { 
				RCT2TrackElement.Brakes, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.RotationControlToggle_SpinningWildMouse, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.InvertedIncline90ToFlatQuarterLoop_Multidim, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnBankedHelixLargeIncline, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, 2, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnBankedHelixLargeIncline, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, 2, 3)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnBankedHelixLargeDecline, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, -2, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnBankedHelixLargeDecline, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, -2, 3)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnHelixLargeIncline, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, 2, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnHelixLargeIncline, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, 2, 3)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnHelixLargeDecline, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, -2, 3)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnHelixLargeDecline, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, -2, 3)
                }
            },
            { 
				RCT2TrackElement.Incline25LeftBanked, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1)
                }
            },
            { 
				RCT2TrackElement.Incline25RightBanked, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1)
                }
            },
            { 
				RCT2TrackElement.Waterfall, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.Rapids, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.OnRidePhoto, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25LeftBanked, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 1)
                }
            },
            { 
				RCT2TrackElement.Decline25RightBanked, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 1)
                }
            },
            { 
				RCT2TrackElement.Watersplash, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 5)
                }
            },
            { 
				RCT2TrackElement.FlatToIncline60LongBase, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 11, 4)
                }
            },
            { 
				RCT2TrackElement.Incline60ToFlatLongBase, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 11, 4)
                }
            },
            { 
				RCT2TrackElement.Whirlpool, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.Decline60ToFlatLongBase, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -11, 4)
                }
            },
            { 
				RCT2TrackElement.FlatToDecline60LongBase, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -11, 4)
                }
            },
            { 
				RCT2TrackElement.CableLiftHill, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 20, 4)
                }
            },
            { 
				RCT2TrackElement.ReverseWhoaBellySlope, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 6)
                }
            },
            { 
				RCT2TrackElement.ReverseWhoaBellyVertical, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 10, 0)
                }
            },
            { 
				RCT2TrackElement.Incline90, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 4, 0)
                }
            },
            { 
				RCT2TrackElement.Decline90, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -4, 0)
                }
            },
            { 
				RCT2TrackElement.Incline60To90, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 7, 0)
                }
            },
            { 
				RCT2TrackElement.Decline90To60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -7, 1)
                }
            },
            { 
				RCT2TrackElement.Incline90To60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 7, 1)
                }
            },
            { 
				RCT2TrackElement.Decline60To90, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -7, 0)
                }
            },
            { 
				RCT2TrackElement.BrakeforDrop, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -3, 1)
                }
            },
            { 
				RCT2TrackElement.LeftOneEighthTurnOTD, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalLeft,
                    Displacement = new Vector3(-2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightOneEighthTurnOTD, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalRight,
                    Displacement = new Vector3(2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.LeftOneEighthTurnDTO, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalLeft,
                    Displacement = new Vector3(-2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightOneEighthTurnDTO, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalRight,
                    Displacement = new Vector3(2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.LeftOneEighthBankOTD, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalLeft,
                    Displacement = new Vector3(-2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightOneEighthBankOTD, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalRight,
                    Displacement = new Vector3(2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.LeftOneEighthBankDTO, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalLeft,
                    Displacement = new Vector3(-2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.RightOneEighthBankDTO, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalRight,
                    Displacement = new Vector3(2, 0, 3)
                }
            },
            { 
				RCT2TrackElement.DiagFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            { 
				RCT2TrackElement.DiagIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 2, 2)
                }
            },
            { 
				RCT2TrackElement.DiagIncline60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 8, 2)
                }
            },
            { 
				RCT2TrackElement.DiagFlatToIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagIncline25To60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 4, 2)
                }
            },
            { 
				RCT2TrackElement.DiagIncline60To25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 4, 2)
                }
            },
            { 
				RCT2TrackElement.DiagIncline25ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -2, 2)
                }
            },
            { 
				RCT2TrackElement.DiagDecline60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -8, 2)
                }
            },
            { 
				RCT2TrackElement.DiagFlatToDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagDecline25To60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -4, 2)
                }
            },
            { 
				RCT2TrackElement.DiagDecline60To25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -4, 2)
                }
            },
            { 
				RCT2TrackElement.DiagDecline25ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagFlatToIncline60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 3, 2)
                }
            },
            { 
				RCT2TrackElement.DiagIncline60ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 3, 2)
                }
            },
            { 
				RCT2TrackElement.DiagFlatToDecline60, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -3, 2)
                }
            },
            { 
				RCT2TrackElement.DiagDecline60ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down60,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -3, 2)
                }
            },
            { 
				RCT2TrackElement.DiagFlatToLeftBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            { 
				RCT2TrackElement.DiagFlatToRightBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            { 
				RCT2TrackElement.DiagLeftBankToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            { 
				RCT2TrackElement.DiagRightBankToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            { 
				RCT2TrackElement.DiagLeftBankToIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagRightBankToIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagIncline25ToLeftBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagIncline25ToRightBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagLeftBankToDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagRightBankToDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagDecline25ToLeftBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagDecline25ToRightBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, -1, 2)
                }
            },
            { 
				RCT2TrackElement.DiagLeftBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            { 
				RCT2TrackElement.DiagRightBank, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.DiagonalStraight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            { 
				RCT2TrackElement.LogFlumeReverser, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.SpinningTunnel, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            { 
				RCT2TrackElement.LeftBarrelRollUpToDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 4, 3)
                }
            },
            { 
				RCT2TrackElement.RightBarrelRollUpToDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 4, 3)
                }
            },
            { 
				RCT2TrackElement.LeftBarrelRollDownToUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -4, 3)
                }
            },
            { 
				RCT2TrackElement.RightBarrelRollDownToUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -4, 3)
                }
            },
            { 
				RCT2TrackElement.LeftBankToLeftQuarterTurnIncline25Across3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 3, 2)
                }
            },
            { 
				RCT2TrackElement.RightBankToRightQuarterTurnIncline25Across3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 3, 2)
                }
            },
            { 
				RCT2TrackElement.LeftQuarterTurnDecline25ToLeftBankAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, -3, 2)
                }
            },
            { 
				RCT2TrackElement.RightQuarterTurnDecline25ToRightBankAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, -3, 2)
                }
            },
            { 
				RCT2TrackElement.PoweredLift, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1)
                }
            },
            { 
				RCT2TrackElement.LeftLargeHalfLoopUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(-2, 3, 3)
                }
            },
            { 
				RCT2TrackElement.RightLargeHalfLoopUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(2, 3, 3)
                }
            },
            { 
				RCT2TrackElement.RightLargeHalfLoopDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(-2, -3, -1)
                }
            },
            { 
				RCT2TrackElement.LeftLargeHalfLoopDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(2, -3, -1)
                }
            },
            { 
				RCT2TrackElement.LeftFlyerTwistUpToDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 3)
                }
            },
            { 
				RCT2TrackElement.RightFlyerTwistUpToDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 3)
                }
            },
            { 
				RCT2TrackElement.LeftFlyerTwistDownToUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 3)
                }
            },
            { 
				RCT2TrackElement.RightFlyerTwistDownToUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 3)
                }
            },
            { 
				RCT2TrackElement.FlyerHalfLoopUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, 15, 2)
                }
            },
            { 
				RCT2TrackElement.FlyerHalfLoopDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, -15, 2)
                }
            },
            { 
				RCT2TrackElement.LeftFlyCorkscrewUpToDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 6, 2)
                }
            },
            { 
				RCT2TrackElement.RightFlyCorkscrewUpToDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 6, 2)
                }
            },
            { 
				RCT2TrackElement.LeftFlyCorkscrewDownToUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, -6, 2)
                }
            },
            { 
				RCT2TrackElement.RightFlyCorkscrewDownToUp, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, -6, 2)
                }
            },
            { 
				RCT2TrackElement.HeartlineTransferUp, new RCT2ElementProperty //TODO: Check
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, 4, 0)
                }
            },
            { 
				RCT2TrackElement.HeartlineTransferDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, -4, 0)
                }
            },
            { 
				RCT2TrackElement.LeftHeartlineRoll, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 6)
                }
            },
            { 
				RCT2TrackElement.RightHeartlineRoll, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 6)
                }
            },
            { 
				RCT2TrackElement.MinigolfHoleA, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            { 
				RCT2TrackElement.MinigolfHoleB, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            {
                RCT2TrackElement.MinigolfHoleC, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            {
                RCT2TrackElement.MinigolfHoleD, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 0, 2)
                }
            },
            {
                RCT2TrackElement.MinigolfHoleE, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 0, 2)
                }
            },
            {
                RCT2TrackElement.InvertedFlatToDecline90QuarterLoop_Multidim, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, -12, 4)
                }
            },
            {
                RCT2TrackElement.QuarterLoopIncline90ToInvert, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, 16, -1)
                }
            },
            {
                RCT2TrackElement.QuarterLoopInvertToDecline90, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Reverse180,
                    Displacement = new Vector3(0, -16, 4)
                }
            },
            {
                RCT2TrackElement.LeftCurvedLiftHill, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 2, 2)
                }
            },
            {
                RCT2TrackElement.RightCurvedLiftHill, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 2, 2)
                }
            },
            {
                RCT2TrackElement.LeftReverser, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight, //TODO: Check
                    Displacement = new Vector3(0, 0, 3)
                }
            },
            {
                RCT2TrackElement.RightReverser, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 3)
                }
            },
            {
                RCT2TrackElement.AirThrustTopCap, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 2)
                }
            },
            {
                RCT2TrackElement.AirThrustVerticalDown, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -10, 0)
                }
            },
            {
                RCT2TrackElement.AirThrustVerticalDownToLevel, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -30, 6)
                }
            },
            {
                RCT2TrackElement.BlockBrakes, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 1)
                }
            },
            {
                RCT2TrackElement.LeftQuarterTurnIncline25BankedAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, 4, 2)
                }
            },
            {
                RCT2TrackElement.RightQuarterTurnIncline25BankedAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, 4, 2)
                }
            },
            {
                RCT2TrackElement.LeftQuarterTurnDecline25BankedAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-2, -4, 2)
                }
            },
            {
                RCT2TrackElement.RightQuarterTurnDecline25BankedAcross3, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(2, -4, 2)
                }
            },
            {
                RCT2TrackElement.LeftQuarterTurnIncline25BankedAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, 4, 3)
                }
            },
            {
                RCT2TrackElement.RightQuarterTurnIncline25BankedAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, 4, 3)
                }
            },
            {
                RCT2TrackElement.LeftQuarterTurnDecline25BankedAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(-3, -4, 3)
                }
            },
            {
                RCT2TrackElement.RightQuarterTurnDecline25BankedAcross5, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(3, -4, 3)
                }
            },
            {
                RCT2TrackElement.Incline25ToLeftBankIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1)
                }
            },
            {
                RCT2TrackElement.Incline25ToRightBankIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1)
                }
            },
            {
                RCT2TrackElement.LeftBankIncline25ToIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1) //TODO: Add accurate values
                }
            },
            {
                RCT2TrackElement.RightBankIncline25ToIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 2, 1)
                }
            },
            {
                RCT2TrackElement.Decline25ToLeftBankDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 1)
                }
            },
            {
                RCT2TrackElement.Decline25ToRightBankDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 1)
                }
            },
            {
                RCT2TrackElement.LeftBankDecline25ToDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 1)
                }
            },
            {
                RCT2TrackElement.RightBankDecline25ToDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -2, 1)
                }
            },
            {
                RCT2TrackElement.LeftBankFlatToLeftBankIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            {
                RCT2TrackElement.RightBankFlatToRightBankIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            {
                RCT2TrackElement.LeftBankIncline25ToLeftBankFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            {
                RCT2TrackElement.RightBankIncline25ToRightBankFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            {
                RCT2TrackElement.LeftBankFlatToLeftBankDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            {
                RCT2TrackElement.RightBankFlatToRightBankDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            {
                RCT2TrackElement.LeftBankDecline25ToLeftBankFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            {
                RCT2TrackElement.RightBankDecline25ToRightBankFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            {
                RCT2TrackElement.FlatToLeftBankIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            {
                RCT2TrackElement.FlatToRightBankIncline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            {
                RCT2TrackElement.LeftBankIncline25ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            {
                RCT2TrackElement.RightBankIncline25ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 1, 1)
                }
            },
            {
                RCT2TrackElement.FlatToLeftBankDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            {
                RCT2TrackElement.FlatToRightBankDecline25, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            {
                RCT2TrackElement.LeftBankDecline25ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Left,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            {
                RCT2TrackElement.RightBankDecline25ToFlat, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down25,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.Right,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -1, 1)
                }
            },
            {
                RCT2TrackElement.LeftQuarterTurnIncline90Across1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(0, 12, 0)
                }
            },
            {
                RCT2TrackElement.RightQuarterTurnIncline90Across1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(0, 12, 0)
                }
            },
            {
                RCT2TrackElement.LeftQuarterTurnDecline90Across1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Left90,
                    Displacement = new Vector3(0, -12, 0)
                }
            },
            {
                RCT2TrackElement.RightQuarterTurnDecline90Across1, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Right90,
                    Displacement = new Vector3(0, -12, 0)
                }
            },
            {
                RCT2TrackElement.Incline90ToInvertedFlatQuarterLoop_Multidim, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Up90,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.Flipped,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 12, 0)
                }
            },
            {
                RCT2TrackElement.FlatToDecline90QuarterLoop_Multidim, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.Down90,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, -16, 4)
                }
            },
            {
                RCT2TrackElement.EndOfTrack, new RCT2ElementProperty
                {
                    InputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    OutputTrackDegree = RCT2ElementProperty.RCT2TrackDegree.None,
                    InputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    OutputTrackBank = RCT2ElementProperty.RCT2TrackBank.None,
                    DirectionChange = RCT2ElementProperty.RCT2TrackDirectionChange.Straight,
                    Displacement = new Vector3(0, 0, 0)
                }
            },
        };

        //Collection of the Vertical and Lateral G Force Factors
        //Tuple is LAteral , Vertical
        //Data extracted from https://github.com/OpenRCT2/OpenRCT2/blob/3da10b7d7db8fe60ca6cb1e277f39abe532e956b/src/ride/vehicle.c#L4968
        //We can approximate some values, as the G force values and ride ratings are recalculated
        //During the game, we approximate it for the fitness value
        //Will need to redesign how to incorporate these values for more accurate calculations
        //Large Switch statement?
        public static Dictionary<RCT2TrackElement, GForceFactors> TrackElementGForceFactorMap = new Dictionary<RCT2TrackElement, GForceFactors>
        {
            //No Lateral or Vertical G Forces
            { RCT2TrackElement.Flat, new GForceFactors(0, 0) },
            { RCT2TrackElement.EndStation, new GForceFactors(0, 0) },
            { RCT2TrackElement.BeginStation, new GForceFactors(0, 0) },
            { RCT2TrackElement.MiddleStation, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline60, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline60, new GForceFactors(0, 0) },
            { RCT2TrackElement.FlatToLeftBank, new GForceFactors(0, 0) },
            { RCT2TrackElement.FlatToRightBank, new GForceFactors(0, 0) },
            { RCT2TrackElement.LeftBankToFlat, new GForceFactors(0, 0) },
            { RCT2TrackElement.RightBankToFlat, new GForceFactors(0, 0) },
            { RCT2TrackElement.LeftBank, new GForceFactors(0, 0) },
            { RCT2TrackElement.RightBank, new GForceFactors(0, 0) },
            { RCT2TrackElement.TowerBase, new GForceFactors(0, 0) },
            { RCT2TrackElement.TowerSection, new GForceFactors(0, 0) },
            { RCT2TrackElement.FlatCovered, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline25Covered, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline60Covered, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline25Covered, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline60Covered, new GForceFactors(0, 0) },
            { RCT2TrackElement.Brakes, new GForceFactors(0, 0) },
            { RCT2TrackElement.RotationControlToggle_SpinningWildMouse, new GForceFactors(0, 0) },
            { RCT2TrackElement.InvertedIncline90ToFlatQuarterLoop_Multidim, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline25LeftBanked, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline25RightBanked, new GForceFactors(0, 0) },
            { RCT2TrackElement.Waterfall, new GForceFactors(0, 0) },
            { RCT2TrackElement.Rapids, new GForceFactors(0, 0) },
            { RCT2TrackElement.OnRidePhoto, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline25LeftBanked, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline25RightBanked, new GForceFactors(0, 0) },
            { RCT2TrackElement.Whirlpool, new GForceFactors(0, 0) },
            { RCT2TrackElement.ReverseWhoaBellyVertical, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline90, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline90, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagFlat, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagIncline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagIncline60, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagDecline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagDecline60, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagFlatToLeftBank, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagFlatToRightBank, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagLeftBankToFlat, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagRightBankToFlat, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagLeftBank, new GForceFactors(0, 0) },
            { RCT2TrackElement.DiagRightBank, new GForceFactors(0, 0) },
            { RCT2TrackElement.LogFlumeReverser, new GForceFactors(0, 0) },
            { RCT2TrackElement.SpinningTunnel, new GForceFactors(0, 0) },
            { RCT2TrackElement.PoweredLift, new GForceFactors(0, 0) },
            { RCT2TrackElement.MinigolfHoleA, new GForceFactors(0, 0) },
            { RCT2TrackElement.MinigolfHoleB, new GForceFactors(0, 0) },
            { RCT2TrackElement.MinigolfHoleC, new GForceFactors(0, 0) },
            { RCT2TrackElement.MinigolfHoleD, new GForceFactors(0, 0) },
            { RCT2TrackElement.MinigolfHoleE, new GForceFactors(0, 0) },
            { RCT2TrackElement.LeftReverser, new GForceFactors(0, 0) },
            { RCT2TrackElement.RightReverser, new GForceFactors(0, 0) },
            { RCT2TrackElement.AirThrustVerticalDown, new GForceFactors(0, 0) },
            { RCT2TrackElement.BlockBrakes, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline25ToLeftBankIncline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.Incline25ToRightBankIncline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.LeftBankIncline25ToIncline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.RightBankIncline25ToIncline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline25ToLeftBankDecline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.Decline25ToRightBankDecline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.LeftBankDecline25ToDecline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.RightBankDecline25ToDecline25, new GForceFactors(0, 0) },
            { RCT2TrackElement.LeftQuarterTurnIncline90Across1, new GForceFactors(0, 0) },
            { RCT2TrackElement.RightQuarterTurnIncline90Across1, new GForceFactors(0, 0) },
            { RCT2TrackElement.LeftQuarterTurnDecline90Across1, new GForceFactors(0, 0) },
            { RCT2TrackElement.RightQuarterTurnDecline90Across1, new GForceFactors(0, 0) },
            //Vertical Factor of 103
            { RCT2TrackElement.FlatToIncline25, new GForceFactors(0, 103) },
            { RCT2TrackElement.Decline25ToFlat, new GForceFactors(0, 103) },
            { RCT2TrackElement.LeftBankToIncline25, new GForceFactors(0, 103) },
            { RCT2TrackElement.RightBankToIncline25, new GForceFactors(0, 103) },
            { RCT2TrackElement.Decline25ToLeftBank, new GForceFactors(0, 103) },
            { RCT2TrackElement.Decline25ToRightBank, new GForceFactors(0, 103) },
            { RCT2TrackElement.FlatToIncline25Covered, new GForceFactors(0, 103) },
            { RCT2TrackElement.Decline25ToFlatCovered, new GForceFactors(0, 103) },
            { RCT2TrackElement.LeftBankFlatToLeftBankIncline25, new GForceFactors(0, 103) },
            { RCT2TrackElement.RightBankFlatToRightBankIncline25, new GForceFactors(0, 103) },
            { RCT2TrackElement.LeftBankDecline25ToLeftBankFlat, new GForceFactors(0, 103) },
            { RCT2TrackElement.RightBankDecline25ToRightBankFlat, new GForceFactors(0, 103) },
            { RCT2TrackElement.FlatToLeftBankIncline25, new GForceFactors(0, 103) },
            { RCT2TrackElement.FlatToRightBankIncline25, new GForceFactors(0, 103) },
            { RCT2TrackElement.LeftBankDecline25ToFlat, new GForceFactors(0, 103) },
            { RCT2TrackElement.RightBankDecline25ToFlat, new GForceFactors(0, 103) },
            //Vertical Factor of -103
            { RCT2TrackElement.Incline25ToFlat, new GForceFactors(0, -103) },
            { RCT2TrackElement.FlatToDecline25, new GForceFactors(0, -103) },
            { RCT2TrackElement.Incline25ToLeftBank, new GForceFactors(0, -103) },
            { RCT2TrackElement.Incline25ToRightBank, new GForceFactors(0, -103) },
            { RCT2TrackElement.LeftBankToDecline25, new GForceFactors(0, -103) },
            { RCT2TrackElement.RightBankToDecline25, new GForceFactors(0, -103) },
            { RCT2TrackElement.Incline25ToFlatCovered, new GForceFactors(0, -103) },
            { RCT2TrackElement.FlatToDecline25Covered, new GForceFactors(0, -103) },
            { RCT2TrackElement.CableLiftHill, new GForceFactors(0, -103) },
            { RCT2TrackElement.LeftBankIncline25ToLeftBankFlat, new GForceFactors(0, -103) },
            { RCT2TrackElement.RightBankIncline25ToRightBankFlat, new GForceFactors(0, -103) },
            { RCT2TrackElement.LeftBankFlatToLeftBankDecline25, new GForceFactors(0, -103) },
            { RCT2TrackElement.RightBankFlatToRightBankDecline25, new GForceFactors(0, -103) },
            { RCT2TrackElement.LeftBankIncline25ToFlat, new GForceFactors(0, -103) },
            { RCT2TrackElement.RightBankIncline25ToFlat, new GForceFactors(0, -103) },
            { RCT2TrackElement.FlatToLeftBankDecline25, new GForceFactors(0, -103) },
            { RCT2TrackElement.FlatToRightBankDecline25, new GForceFactors(0, -103) },
            //Vertical Factor of 82
            { RCT2TrackElement.Incline25To60, new GForceFactors(0, 82) },
            { RCT2TrackElement.Decline60To25, new GForceFactors(0, 82) },
            { RCT2TrackElement.Incline25To60Covered, new GForceFactors(0, 82) },
            { RCT2TrackElement.Decline60To25Covered, new GForceFactors(0, 82) },
            //Vertical Factor of -82
            { RCT2TrackElement.Incline60To25, new GForceFactors(0, -82) },
            { RCT2TrackElement.Decline25To60, new GForceFactors(0, -82) },
            { RCT2TrackElement.Incline60To25Covered, new GForceFactors(0, -82) },
            { RCT2TrackElement.Decline25To60Covered, new GForceFactors(0, -82) },
            //Lateral Factor of 98
            { RCT2TrackElement.LeftQuarterTurnAcross5, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftQuarterTurnIncline25Across5, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftQuarterTurnDecline25Across5, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftTwistDownToUp, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftTwistUpToDown, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftQuarterTurnCoveredAcross5, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftQuarterTurnHelixLargeIncline, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftQuarterTurnHelixLargeDecline, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftFlyerTwistDownToUp, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftFlyerTwistUpToDown, new GForceFactors(98, 0) },
            { RCT2TrackElement.LeftHeartlineRoll, new GForceFactors(98, 0) },
            //Lateral Factor of -98
            { RCT2TrackElement.RightQuarterTurnAcross5, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightQuarterTurnIncline25Across5, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightQuarterTurnDecline25Across5, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightTwistDownToUp, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightTwistUpToDown, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightQuarterTurnCoveredAcross5, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightQuarterTurnHelixLargeIncline, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightQuarterTurnHelixLargeDecline, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightFlyerTwistDownToUp, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightFlyerTwistUpToDown, new GForceFactors(-98, 0) },
            { RCT2TrackElement.RightHeartlineRoll, new GForceFactors(-98, 0) },
            //Lateral Factor of 160, Vertical Factor of 200
            { RCT2TrackElement.LeftQuarterTurnBankAcross5, new GForceFactors(160, 200) },
            { RCT2TrackElement.LeftHalfBankedHelixInclineLarge, new GForceFactors(160, 200) },
            { RCT2TrackElement.LeftHalfBankedHelixDeclineLarge, new GForceFactors(160, 200) },
            { RCT2TrackElement.LeftQuarterTurnBankedHelixLargeIncline, new GForceFactors(160, 200) },
            { RCT2TrackElement.LeftQuarterTurnBankedHelixLargeDecline, new GForceFactors(160, 200) },
            //Lateral Factor of -160, Vertical Factor of 200
            { RCT2TrackElement.RightQuarterTurnBankAcross5, new GForceFactors(-160, 200) },
            { RCT2TrackElement.RightHalfBankedHelixInclineLarge, new GForceFactors(-160, 200) },
            { RCT2TrackElement.RightHalfBankedHelixDeclineLarge, new GForceFactors(-160, 200) },
            { RCT2TrackElement.RightQuarterTurnBankedHelixLargeIncline, new GForceFactors(-160, 200) },
            { RCT2TrackElement.RightQuarterTurnBankedHelixLargeDecline, new GForceFactors(-160, 200) },
            //If Track Progress < 48 Lateral Factor 98, else -98
            { RCT2TrackElement.LeftSBend, new GForceFactors(98, 0) },           //Inaccurate, should be neg during the right component
            { RCT2TrackElement.LeftSBendCovered, new GForceFactors(98, 0) },    // ^
            //If Track Progress < 48 Lateral Factor -98, else 98
            { RCT2TrackElement.RightSBend, new GForceFactors(-98, 0) },         //Inaccurate, should be pos during the left components
            { RCT2TrackElement.RightSBendCovered, new GForceFactors(-98, 0) },  // ^
            //Vertical Factor is the track progress - 155 / 2 + 28
            { RCT2TrackElement.LeftVerticalLoop, new GForceFactors(0, 28) },    //Inaccurate, no way of doing track progress
            { RCT2TrackElement.RightVerticalLoop, new GForceFactors(0, 28) },   // ^
            //Lateral Factor is 59
            { RCT2TrackElement.LeftQuarterTurnAcross3, new GForceFactors(0, 59) },
            { RCT2TrackElement.LeftQuarterTurnIncline25Across3, new GForceFactors(0, 59) },
            { RCT2TrackElement.LeftQuarterTurnDecline25Across3, new GForceFactors(0, 59) },
            { RCT2TrackElement.LeftQuarterTurnCoveredAcross3, new GForceFactors(0, 59) },
            { RCT2TrackElement.LeftCurvedLiftHill, new GForceFactors(0, 59) },
            //Lateral Factor is -59
            { RCT2TrackElement.RightQuarterTurnAcross3, new GForceFactors(0, -59) },
            { RCT2TrackElement.RightQuarterTurnIncline25Across3, new GForceFactors(0, -59) },
            { RCT2TrackElement.RightQuarterTurnDecline25Across3, new GForceFactors(0, -59) },
            { RCT2TrackElement.RightQuarterTurnCoveredAcross3, new GForceFactors(0, -59) },
            { RCT2TrackElement.RightCurvedLiftHill, new GForceFactors(0, -59) },
            //Lateral Factor is 100, Vertical Factor is 100
            { RCT2TrackElement.LeftQuarterTurnBankAcross3, new GForceFactors(100, 100) },
            { RCT2TrackElement.LeftHalfBankedHelixInclineSmall, new GForceFactors(100, 100) },
            { RCT2TrackElement.LeftHalfBankedHelixDeclineSmall, new GForceFactors(100, 100) },
            //Lateral Factor is -100, Vertical Factor is 100
            { RCT2TrackElement.RightQuarterTurnBankAcross3, new GForceFactors(-100, 100) },
            { RCT2TrackElement.RightHalfBankedHelixInclineSmall, new GForceFactors(-100, 100) },
            { RCT2TrackElement.RightHalfBankedHelixDeclineSmall, new GForceFactors(-100, 100) },
            //Lateral Factor 45
            { RCT2TrackElement.LeftQuarterTurnAcross1, new GForceFactors(45, 0) },
            //Lateral Factor -45
            { RCT2TrackElement.RightQuarterTurnAcross1, new GForceFactors(-45, 0) },
            //Vertical Factor of Track Progress - 155 / 2 + 28
            { RCT2TrackElement.HalfLoopUp, new GForceFactors(28, 0) },          //Inaccurate, no way of doing track progress
            { RCT2TrackElement.FlyerHalfLoopUp, new GForceFactors(28, 0) },     // ^
            //Vertical Factor of Track Progress / 2 + 28
            { RCT2TrackElement.HalfLoopDown, new GForceFactors(-28, 0) },       //Inaccurate, no way of doing track progress
            { RCT2TrackElement.FlyerHalfLoopDown, new GForceFactors(-28, 0) },  // ^
            //Lateral Factor of 70, Vertical Factor of 52
            { RCT2TrackElement.LeftCorkscrewUp, new GForceFactors(70, 52) },
            { RCT2TrackElement.RightCorkscrewDown, new GForceFactors(70, 52) },
            { RCT2TrackElement.LeftFlyCorkscrewDownToUp, new GForceFactors(70, 52) },
            { RCT2TrackElement.RightFlyCorkscrewUpToDown, new GForceFactors(70, 52) },
            //Lateral Factor of -70, Vertical Factor of 52
            { RCT2TrackElement.RightCorkscrewUp, new GForceFactors(-70, 52) },
            { RCT2TrackElement.LeftCorkscrewDown, new GForceFactors(-70, 52) },
            { RCT2TrackElement.RightFlyCorkscrewDownToUp, new GForceFactors(-70, 52) },
            { RCT2TrackElement.LeftFlyCorkscrewUpToDown, new GForceFactors(-70, 52) },
            //Vertical Factor of 56
            { RCT2TrackElement.FlatToIncline60, new GForceFactors(0, 56) },
            { RCT2TrackElement.Decline60ToFlat, new GForceFactors(0, 56) },
            //Vertical Factor of -56
            { RCT2TrackElement.Incline60ToFlat, new GForceFactors(0, -56) },
            { RCT2TrackElement.FlatToDecline60, new GForceFactors(0, -56) },
            { RCT2TrackElement.BrakeforDrop, new GForceFactors(0, -56) },
            //Lateral Factor of 88
            { RCT2TrackElement.LeftQuarterTurnIncline60Across1, new GForceFactors(88, 0) },
            { RCT2TrackElement.LeftQuarterTurnDecline60Across1, new GForceFactors(88, 0) },
            //Lateral Factor of -88
            { RCT2TrackElement.RightQuarterTurnIncline60Across1, new GForceFactors(-88, 0) },
            { RCT2TrackElement.RightQuarterTurnDecline60Across1, new GForceFactors(-88, 0) },
            //Vertical Factor varies from -150 to 0 to 150 depending on track progress
            { RCT2TrackElement.Watersplash, new GForceFactors(0, -150) },   //Inaccurate, no way of doing track progress
            //Vertical Factor of 160
            { RCT2TrackElement.FlatToIncline60LongBase, new GForceFactors(0, 160) },
            { RCT2TrackElement.FlatToDecline60LongBase, new GForceFactors(0, 160) },
            //Vertical Factor of -160
            { RCT2TrackElement.Incline60ToFlatLongBase, new GForceFactors(0, -160) },
            //Vertical Factor of 120
            { RCT2TrackElement.ReverseWhoaBellySlope, new GForceFactors(0, 120) },
            { RCT2TrackElement.AirThrustVerticalDownToLevel, new GForceFactors(0, 120) },
            //Vertical Factor of 110
            { RCT2TrackElement.Incline60To90, new GForceFactors(0, 110) },
            { RCT2TrackElement.Decline90To60, new GForceFactors(0, 110) },
            //Vertical Factor of -110
            { RCT2TrackElement.Incline90To60, new GForceFactors(0, -110) },
            { RCT2TrackElement.Decline60To90, new GForceFactors(0, -110) },
            //Lateral Factor of 137
            { RCT2TrackElement.LeftOneEighthTurnOTD, new GForceFactors(137, 0) },
            { RCT2TrackElement.LeftOneEighthTurnDTO, new GForceFactors(137, 0) },
            //Lateral Factor of -137
            { RCT2TrackElement.RightOneEighthTurnOTD, new GForceFactors(-137, 0) },
            { RCT2TrackElement.RightOneEighthTurnDTO, new GForceFactors(-137, 0) },
            //Lateral Factor of 200, Vertical of 270
            { RCT2TrackElement.LeftOneEighthBankOTD, new GForceFactors(200, 270) },
            { RCT2TrackElement.LeftOneEighthBankDTO, new GForceFactors(200, 270) },
            //Lateral Factor of -200, Vertical of 270
            { RCT2TrackElement.RightOneEighthBankOTD, new GForceFactors(-200, 270) },
            { RCT2TrackElement.RightOneEighthBankDTO, new GForceFactors(-200, 270) },
            //Vertical Factor of 113
            { RCT2TrackElement.DiagFlatToIncline25, new GForceFactors(0, 113) },
            { RCT2TrackElement.DiagDecline25ToFlat, new GForceFactors(0, 113) },
            { RCT2TrackElement.DiagLeftBankToIncline25, new GForceFactors(0, 113) },
            { RCT2TrackElement.DiagRightBankToIncline25, new GForceFactors(0, 113) },
            { RCT2TrackElement.DiagDecline25ToLeftBank, new GForceFactors(0, 113) },
            { RCT2TrackElement.DiagDecline25ToRightBank, new GForceFactors(0, 113) },
            //Vertical Factor of -113
            { RCT2TrackElement.DiagIncline25ToFlat, new GForceFactors(0, -113) },
            { RCT2TrackElement.DiagFlatToDecline25, new GForceFactors(0, -113) },
            { RCT2TrackElement.DiagIncline25ToLeftBank, new GForceFactors(0, -113) },
            { RCT2TrackElement.DiagIncline25ToRightBank, new GForceFactors(0, -113) },
            { RCT2TrackElement.DiagLeftBankToDecline25, new GForceFactors(0, -113) },
            { RCT2TrackElement.DiagRightBankToDecline25, new GForceFactors(0, -113) },
            //Vertical Factor of 95
            { RCT2TrackElement.DiagIncline25To60, new GForceFactors(0, 95) },
            { RCT2TrackElement.DiagDecline60To25, new GForceFactors(0, 95) },
            //Vertical Factor of -95
            { RCT2TrackElement.DiagIncline60To25, new GForceFactors(0, -95) },
            { RCT2TrackElement.DiagDecline25To60, new GForceFactors(0, -95) },
            //Vertical Factor of 60
            { RCT2TrackElement.DiagFlatToIncline60, new GForceFactors(0, 60) },
            { RCT2TrackElement.DiagDecline60ToFlat, new GForceFactors(0, 60) },
            //Vertical Factor of -60
            { RCT2TrackElement.DiagIncline60ToFlat, new GForceFactors(0, -60) },
            { RCT2TrackElement.DiagFlatToDecline60, new GForceFactors(0, -60) },
            //Vertical Factor of 170, Lateral Factor of 115
            { RCT2TrackElement.LeftBarrelRollUpToDown, new GForceFactors(115, 170) },
            { RCT2TrackElement.LeftBarrelRollDownToUp, new GForceFactors(115, 170) },
            //Vertical Factor of 170, Lateral Factor of -115
            { RCT2TrackElement.RightBarrelRollUpToDown, new GForceFactors(-115, 170) },
            { RCT2TrackElement.RightBarrelRollDownToUp, new GForceFactors(-115, 170) },
            //Lateral Factor of 90, Vertical Factor of track progress / 2 + 134
        };
    }
}
