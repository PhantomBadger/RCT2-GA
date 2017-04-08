using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCT2GA.RideData;

namespace RCT2GA
{
    class GeneticAlgorithm
    {
        public RCT2RideData GenerateWoodenRollerCoaster(int length)
        {
            RideData.RCT2RideData coaster = new RideData.RCT2RideData();

            //Track Type
            coaster.TrackType = new RideData.RCT2RideCode();
            coaster.TrackType.RideType = RideData.RCT2RideCode.RCT2TrackName.WoodenRollerCoaster6Seater;

            //Track Data
            coaster.TrackData = GenerateTrack(length);

            //Ride Features
            coaster.RideFeatures = new RideData.RCT2RideFeatures();
            coaster.RideFeatures.Populate(coaster.TrackData);

            //Operating Mode
            coaster.OperatingMode = RideData.RCT2RideData.RCT2OperatingModes.ContinuousCircuit;

            //Colour Scheme
            coaster.ColourScheme = new RideData.RCT2VehicleColourScheme();
            coaster.ColourScheme.ColourMode = RideData.RCT2VehicleColourScheme.RCT2VehicleColourMode.AllSameColour;
            List<RideData.RCT2VehicleColourScheme.RCT2Colour> bodyColours = new List<RideData.RCT2VehicleColourScheme.RCT2Colour>();
            List<RideData.RCT2VehicleColourScheme.RCT2Colour> trimColours = new List<RideData.RCT2VehicleColourScheme.RCT2Colour>();
            List<RideData.RCT2VehicleColourScheme.RCT2Colour> additionalColours = new List<RideData.RCT2VehicleColourScheme.RCT2Colour>();
            Random random = new Random();
            Array colourValues = Enum.GetValues(typeof(RideData.RCT2VehicleColourScheme.RCT2Colour));

            for (int i = 0; i < 32; i++)
            {
                bodyColours.Add((RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length)));
                trimColours.Add((RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length)));
                additionalColours.Add((RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length)));
            }

            coaster.ColourScheme.BodyColours = bodyColours.ToArray();
            coaster.ColourScheme.TrimColours = trimColours.ToArray();
            coaster.ColourScheme.AdditionalColours = additionalColours.ToArray();

            //Entrance Style
            coaster.EntranceStyle = RideData.RCT2RideData.RCT2EntranceStyle.Plain;

            //Air Time In Seconds
            coaster.TrackData.PopulateRideStatistics();
            coaster.AirTimeInSeconds = coaster.TrackData.AirTimeInSeconds;

            //Departure Flags
            coaster.DepartureFlags = new RideData.RCT2DepartureControlFlags();
            coaster.DepartureFlags.UseMinimumTime = true;
            coaster.DepartureFlags.WaitForFullLoad = true;

            //Number of Trains
            coaster.NumberOfTrains = 1;

            //Number of Cars per Train
            coaster.NumberOfCarsPerTrain = 2;

            //Min Wait Time in Seconds
            coaster.MinWaitTimeInSeconds = 10;

            //Max Wait Time in Seconds
            coaster.MaxWaitTimeInSeconds = 60;

            //Speed of Powered Launch/Number of Go Kart Laps/Max number of people in Maze
            coaster.SpeedOfPoweredLaunch = 0;
            coaster.NumberOfGoKartLaps = 0;
            coaster.MaxNumberOfPeopleMaze = 0;

            //Max Speed of Ride
            coaster.MaxSpeedOfRide = coaster.TrackData.MaxSpeed;

            //Average Speed of Ride
            coaster.AverageSpeedOfRide = coaster.TrackData.AverageSpeed;

            //Ride length in metres
            coaster.RideLengthInMetres = coaster.TrackData.CalculateRideLengthInMeters();

            //Pos G Force
            coaster.PosGForce = coaster.TrackData.MaxPositiveG;

            //Neg G Force
            coaster.NegGForce = coaster.TrackData.MaxNegativeG;

            //Lat G Force
            coaster.LatGForce = coaster.TrackData.MaxLateralG;

            //Number of Inversions
            coaster.NumberOfInversions = coaster.TrackData.NumOfInversions;

            //Number of Drops
            coaster.NumberOfDrops = coaster.TrackData.NumOfDrops;

            //Highest Drop
            coaster.HighestDrop = coaster.TrackData.HighestDrop;

            //Excitement Times Ten
            coaster.ExcitementTimesTen = coaster.TrackData.Excitement * 10;

            //Intensity Times Ten
            coaster.IntensityTimesTen = coaster.TrackData.Intensity * 10;

            //Nausea Times Ten
            coaster.NauseaTimesTen = coaster.TrackData.Nausea * 10;

            //Main Track Colour
            coaster.TrackMainColour = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackMainColourAlt1 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackMainColourAlt2 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackMainColourAlt3 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));

            //Additional Track Colour
            coaster.TrackAdditionalColour = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackAdditionalColourAlt1 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackAdditionalColourAlt2 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackAdditionalColourAlt3 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));

            //Support Track Colour
            coaster.TrackSupportColour = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackSupportColourAlt1 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackSupportColourAlt2 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            coaster.TrackSupportColourAlt3 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));

            //Is Six Flag Design
            coaster.IsSixFlagsDesign = false;

            //DAT File Header
            //We scum this in the TD6 Parser so it's not needed to be filled yet
            //TODO
            coaster.DatFile = new RideData.DATFileHeader();

            //DAT File Checksum
            coaster.DatChecksum = coaster.DatFile.CalculateChecksum(RideData.RCT2RideCode.RideNameVehicleMap[coaster.TrackType.RideType]);

            //Required Map Space
            coaster.RequiredMapSpace = coaster.TrackData.CalculateRequiredMapSpace();

            //Lift Chain Speed
            coaster.LiftChainSpeed = 5;

            //Number of Circuits
            coaster.NumberOfCircuits = 1;

            //Check Validity
            if (!coaster.TrackData.CheckValidity())
            {
                Console.WriteLine("ERROR: Failed Validity Check");
                return null;
            }

            return coaster;
        }

        private RCT2TrackData GenerateTrack(int length)
        {
            RCT2TrackData trackData = new RCT2TrackData();
            trackData.TrackData = new List<RCT2TrackPiece>();
            Random random = new Random();

            //Begin Station
            trackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.BeginStation,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //End Station
            trackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.EndStation,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            for (int i = 1; i < length + 2; i++)
            {
                List<RCT2TrackElements.RCT2TrackElement> candidates = RCT2TrackElements.FindValidSuccessors(trackData.TrackData[i].TrackElement);
                bool reselect = false;

                do
                {
                    //If we have no candidates left
                    if (candidates.Count <= 0)
                    {
                        Console.WriteLine("ERROR: No Valid Track Pieces Found");
                        return null;
                    }

                    //Select our successor and remove it from the potential pool
                    RCT2TrackElements.RCT2TrackElement successor = candidates[random.Next(candidates.Count)];
                    candidates.Remove(successor);
                    RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[successor];

                    RCT2Qualifier qualifier;

                    //Create our qualifier bit
                    if (property.Displacement.Y > 0)
                    {
                        //TODO: Check if it should be a chain
                        //      Perform a lookup to see if previous track was chain lift
                        //      Or if our current velocity would be negative/0
                        //      If not possible, do a lookup to see if previous X tracks contained a decline, if not we need one

                        bool chainLift = trackData.TrackData[i - 1].Qualifier.IsChainLift;

                        //If our current velocity would be negative or zero, we need a chain lift
                        

                        qualifier = new RCT2Qualifier()
                        {
                            IsChainLift = true,
                            TrackColourSchemeNumber = 0,
                            TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                            AtTerminalStation = false,
                            StationNumber = 0
                        };
                    }
                    else
                    {
                        qualifier = new RCT2Qualifier()
                        {
                            IsChainLift = false,
                            TrackColourSchemeNumber = 0,
                            TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                            AtTerminalStation = false,
                            StationNumber = 0
                        };
                    }

                    //Add to track
                    trackData.TrackData.Add(new RCT2TrackPiece() { TrackElement = successor, Qualifier = qualifier });

                    //If it's invalid
                    if (!trackData.CheckValidity())
                    {
                        //Remove it and try again
                        reselect = true;
                        trackData.TrackData.Remove(trackData.TrackData.Last());
                    }
                } while (reselect);                            
            }

            return trackData;
        }
    }
}
