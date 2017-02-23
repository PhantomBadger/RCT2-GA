using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class RCT2RideData
    {
        public enum RCT2OperatingModes {    Normal,
                                            ContinuousCircuit,
                                            ReverseInclineLaunchedShuttle,
                                            PoweredLaunch,
                                            Shuttle,
                                            BoatHire,
                                            UpwardLaunch,
                                            RotatingLift,
                                            StationToStation,
                                            SingleRidePerAdmission,
                                            UnlimitedRidesPerAdmission,
                                            Maze,
                                            Race,
                                            BumperCar,
                                            Swing,
                                            ShopStall,
                                            Rotation,
                                            ForwardRotation,
                                            BackwardRotation,
                                            FilmAvengingAviators,
                                            FilmMouseTails3D,
                                            SpaceRings,
                                            Beginners,
                                            LIMPoweredLaunch,
                                            FilmThrillRiders,
                                            FilmStormChasers3D,
                                            FilmSpaceRaiders3D,
                                            Intense,
                                            Berserk,
                                            HauntedGouse,
                                            CircusShow,
                                            DownwardLaunch,
                                            CrookedHouse,
                                            FreefallDrop,
                                            CintinuousCircuitBlockSectioned,
                                            PoweredLaunchBlockSectioned };

        public enum RCT2EntranceStyle {     Plain,
                                            Wooden,
                                            Canvas,
                                            CastleGrey,
                                            CastleBrown,
                                            Jungle,
                                            LogCabin,
                                            Classical,
                                            Abstract,
                                            Snow,
                                            Pagoda,
                                            Space };

        public RCT2RideCode TrackType { get; set; }
        public RCT2TrackData TrackData { get; set; }
        public RCT2RideFeatures RideFeatures { get; set; }
        public RCT2OperatingModes OperatingMode { get; set; }
        public RCT2VehicleColourScheme ColourScheme { get; set; }
        public RCT2EntranceStyle EntranceStyle { get; set; }
        public int AirTimeInSeconds { get; set; }
        public RCT2DepartureControlFlags DepartureFlags { get; set; }
        public int NumberOfTrains { get; set; }
        public int NumberOfCarsPerTrain { get; set; }
        public int MinWaitTimeInSeconds { get; set; }
        public int MaxWaitTimeInSeconds { get; set; }
        public float SpeedOfPoweredLaunch { get; set; }
        public int NumberOfGoKartLaps { get; set; }
        public int MaxNumberOfPeopleMaze { get; set; }
        public float MaxSpeedOfRide { get; set; }
        public float AverageSpeedOfRide { get; set; }
        public int RideLengthInMetres { get; set; }
        public float PosGForce { get; set; }
        public float NegGForce { get; set; }
        public float LatGForce { get; set; }
        public int NumberOfInversions { get; set; }
        public int NumberOfDrops { get; set; }
        public float HighestDrop { get; set; }
        public float ExcitementTimesTen { get; set; }
        public float IntensityTimesTen { get; set; }
        public float NauseaTimesTen { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackMainColour { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackMainColourAlt1 { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackMainColourAlt2 { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackMainColourAlt3 { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackAdditionalColour { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackAdditionalColourAlt1 { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackAdditionalColourAlt2 { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackAdditionalColourAlt3 { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackSupportColour { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackSupportColourAlt1 { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackSupportColourAlt2 { get; set; }
        public RCT2VehicleColourScheme.RCT2Colour TrackSupportColourAlt3 { get; set; }
        public bool IsSixFlagsDesign { get; set; }
        public DATFileHeader DatFile { get; set; }
        public int DatChecksum { get; set; }
        public Vector2 RequiredMapSpace { get; set; }
        public float LiftChainSpeed { get; set; }
        public int NumberOfCircuits { get; set; }
    }
}
