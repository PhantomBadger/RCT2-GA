using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2RideFeatures
    {
        //Byte 0   
        public bool StraightFlat { get; set; }
        public bool StationPlatform { get; set; }
        public bool LiftChain { get; set; }
        public bool SteepLiftChain { get; set; }
        public bool CurveLiftChain { get; set; }
        public bool Banking { get; set; }
        public bool VerticalLoop { get; set; }

        //Byte 1
        public bool NormalSlope { get; set; }
        public bool SteepSlope { get; set; }
        public bool FlatToSteep { get; set; }
        public bool SlopedCurves { get; set; }
        public bool SteepTwist { get; set; }
        public bool SBends { get; set; }
        public bool SmallRadiusCurves { get; set; }
        public bool SmallRadiusBanked { get; set; }

        //Byte 2
        public bool MediumRadiusCurves { get; set; }
        public bool InlineTwist { get; set; }
        public bool HalfLoop { get; set; }
        public bool HalfCorkscrew { get; set; }
        public bool TowerBaseVertical { get; set; }
        public bool HelixBanked { get; set; }
        public bool HelixUnbanked { get; set; }
    
        //Byte 3
        public bool Brakes { get; set; }
        public bool Booster { get; set; }
        public bool OnRidePhoto { get; set; }
        public bool WaterSplash { get; set; }
        public bool VerticalTrack { get; set; }
        public bool BarrelRoll { get; set; }
        public bool LaunchedLiftHill { get; set; }
        public bool LargeHalfLoop { get; set; }

        public RCT2RideFeatures(RCT2RideFeatures copy)
        {
            StraightFlat = copy.StraightFlat;
            StationPlatform = copy.StationPlatform;
            LiftChain = copy.LiftChain;
            SteepLiftChain = copy.SteepLiftChain;
            CurveLiftChain = copy.CurveLiftChain;
            Banking = copy.Banking;
            VerticalLoop = copy.VerticalLoop;

            NormalSlope = copy.NormalSlope;
            SteepSlope = copy.SteepSlope;
            FlatToSteep = copy.FlatToSteep;
            SlopedCurves = copy.SlopedCurves;
            SteepTwist = copy.SteepTwist;
            SBends = copy.SBends;
            SmallRadiusCurves = copy.SmallRadiusCurves;
            SmallRadiusBanked = copy.SmallRadiusBanked;

            MediumRadiusCurves = copy.MediumRadiusCurves;
            InlineTwist = copy.InlineTwist;
            HalfLoop = copy.HalfLoop;
            HalfCorkscrew = copy.HalfCorkscrew;
            TowerBaseVertical = copy.TowerBaseVertical;
            HelixBanked = copy.HelixBanked;
            HelixUnbanked = copy.HelixUnbanked;

            Brakes = copy.Brakes;
            Booster = copy.Booster;
            OnRidePhoto = copy.OnRidePhoto;
            WaterSplash = copy.WaterSplash;
            VerticalTrack = copy.VerticalTrack;
            BarrelRoll = copy.BarrelRoll;
            LaunchedLiftHill = copy.LaunchedLiftHill;
            LargeHalfLoop = copy.LargeHalfLoop;
        }

        public RCT2RideFeatures()
        {

        }

        public void Populate(RCT2TrackData track)
        {
            //If the track is empty, return
            if (track == null || track.TrackData == null || track.TrackData.Count <= 0)
            {
                return;
            }

            //Give all our bytes an initial value
            StraightFlat = false;
            StationPlatform = false;
            LiftChain = false;
            SteepLiftChain = false;
            CurveLiftChain = false;
            Banking = false;
            VerticalLoop = false;

            NormalSlope = false;
            SteepSlope = false;
            FlatToSteep = false;
            SlopedCurves = false;
            SteepTwist = false;
            SBends = false;
            SmallRadiusCurves = false;
            SmallRadiusBanked = false;

            MediumRadiusCurves = false;
            InlineTwist = false;
            HalfLoop = false;
            HalfCorkscrew = false;
            TowerBaseVertical = false;
            HelixBanked = false;
            HelixUnbanked = false;

            Brakes = false;
            Booster = false;
            OnRidePhoto = false;
            WaterSplash = false;
            VerticalTrack = false;
            BarrelRoll = false;
            LaunchedLiftHill = false;
            LargeHalfLoop = false;


            //Go through every track piece and populate our bytes
            RCT2TrackElements.RCT2TrackElement prevTrackPiece = track.TrackData[0].TrackElement;
            for (int i = 0; i < track.TrackData.Count; i++)
            {
                RCT2TrackElements.RCT2TrackElement currentTrack = track.TrackData[i].TrackElement;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.Flat)
                    StraightFlat = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.BeginStation ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.MiddleStation ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.EndStation)
                    StationPlatform = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.CableLiftHill ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.LeftCurvedLiftHill ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.PoweredLift ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.RightCurvedLiftHill)
                    LiftChain = true;

                //Steep Lift Chain not needed for our chosen problem space

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.LeftCurvedLiftHill ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.RightCurvedLiftHill)
                    CurveLiftChain = true;

                if (RCT2TrackElements.TrackElementPropertyMap[currentTrack].InputTrackBank != RCT2TrackElementProperty.RCT2TrackBank.None ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].OutputTrackBank != RCT2TrackElementProperty.RCT2TrackBank.None)
                    Banking = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.LeftVerticalLoop ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.RightVerticalLoop)
                    VerticalLoop = true;

                if (RCT2TrackElements.TrackElementPropertyMap[currentTrack].InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up25 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].OutputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up25 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Down25 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].OutputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Down25)
                    NormalSlope = true;

                if (RCT2TrackElements.TrackElementPropertyMap[currentTrack].InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up60 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].OutputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up60 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Down60 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].OutputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Down60)
                    SteepSlope = true;

                if (RCT2TrackElements.TrackElementPropertyMap[currentTrack].InputTrackBank == RCT2TrackElementProperty.RCT2TrackBank.Flipped ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].OutputTrackBank == RCT2TrackElementProperty.RCT2TrackBank.Flipped)
                    SteepTwist = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.LeftSBend ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.LeftSBendCovered ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.RightSBend ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.RightSBendCovered)
                    SBends = true;

                if (currentTrack.ToString().ToLower().Contains("across1"))
                    SmallRadiusCurves = true;

                if (currentTrack.ToString().ToLower().Contains("bank"))
                    SmallRadiusBanked = true;

                if (currentTrack.ToString().ToLower().Contains("across3"))
                    MediumRadiusCurves = true;

                if (currentTrack.ToString().ToLower().Contains("twist"))
                    InlineTwist = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.HalfLoopUp ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.HalfLoopDown ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.FlyerHalfLoopUp ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.FlyerHalfLoopDown)
                    HalfLoop = true;

                if (currentTrack.ToString().ToLower().Contains("corkscrew"))
                    HalfCorkscrew = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.TowerBase ||
                    currentTrack == RCT2TrackElements.RCT2TrackElement.TowerSection)
                    TowerBaseVertical = true;

                if (currentTrack.ToString().ToLower().Contains("bankedhelix"))
                    HelixBanked = true;
                else if (currentTrack.ToString().ToLower().Contains("helix"))
                    HelixUnbanked = true;

                if (currentTrack.ToString().ToLower().Contains("brake"))
                    Brakes = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.OnRidePhoto)
                    OnRidePhoto = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.Watersplash)
                    WaterSplash = true;

                if (RCT2TrackElements.TrackElementPropertyMap[currentTrack].InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Down90 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].OutputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Down90 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up90 ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrack].OutputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up90)
                    VerticalTrack = true;

                if (currentTrack.ToString().ToLower().Contains("barrelroll"))
                    BarrelRoll = true;

                if (currentTrack == RCT2TrackElements.RCT2TrackElement.PoweredLift)
                    LaunchedLiftHill = true;

                if (currentTrack.ToString().ToLower().Contains("largehalfloop"))
                    LargeHalfLoop = true;

                prevTrackPiece = currentTrack;
            }
        }
    }
}
