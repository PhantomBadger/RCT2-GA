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
        float mutationRate = 0;
        float crossoverRate = 0;
        int populationSize = 100;
        int generationCount = 100;
        int length = 20;

        public GeneticAlgorithm()
        {

        }

        public void Initialise()
        {

        }

        public RCT2RideData GenerateWoodenRollerCoaster(int length)
        {
            RideData.RCT2RideData coaster = new RideData.RCT2RideData();

            //Track Type
            coaster.TrackType = new RideData.RCT2RideCode();
            coaster.TrackType.RideType = RideData.RCT2RideCode.RCT2TrackName.WoodenRollerCoaster6Seater;

            //Track Data
            coaster.TrackData = GenerateWoodenRollerCoasterTrack(length);

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
            if (coaster.TrackData.CheckValidity() != RCT2TrackData.InvalidityCode.Valid)
            {
                Console.WriteLine("ERROR: Failed Validity Check");
                return null;
            }

            return coaster;
        }

        private RCT2TrackData GenerateWoodenRollerCoasterTrack(int length)
        {
            List<RCT2TrackElements.RCT2TrackElement> whitelistedTracks = new List<RCT2TrackElements.RCT2TrackElement>();
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Flat);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.FlatToIncline25);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.FlatToDecline25);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Incline25);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Decline25);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Incline25ToFlat);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Decline25ToFlat);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBank);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankToIncline25);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankToDecline25);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Incline25LeftBanked);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Decline25LeftBanked);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankIncline25ToFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankDecline25ToFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankToFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankFlatToLeftBankIncline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankFlatToLeftBankDecline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankIncline25ToIncline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankDecline25ToDecline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankIncline25ToLeftBankFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankDecline25ToLeftBankFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBank);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankToIncline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankToDecline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Incline25RightBanked);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.Decline25RightBanked);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankIncline25ToFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankDecline25ToFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankToFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankFlatToRightBankIncline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankFlatToRightBankDecline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankIncline25ToIncline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankDecline25ToDecline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankIncline25ToRightBankFlat);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankDecline25ToRightBankFlat);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftSBend);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightSBend);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross3);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnBankAcross3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnBankAcross5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftBankToLeftQuarterTurnIncline25Across3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnDecline25Across3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnIncline25Across3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnIncline25Across5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnDecline25Across5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnDecline25ToLeftBankAcross3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnIncline25BankedAcross5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnDecline25BankedAcross5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnIncline25BankedAcross3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnDecline25BankedAcross3);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnAcross3);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnAcross5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnBankAcross3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnBankAcross5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightBankToRightQuarterTurnIncline25Across3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnDecline25Across3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnIncline25Across3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnIncline25Across5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnDecline25Across5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnDecline25ToRightBankAcross3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnIncline25BankedAcross5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnDecline25BankedAcross5);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnIncline25BankedAcross3);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.RightQuarterTurnDecline25BankedAcross3);
            whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.OnRidePhoto);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.FlatToLeftBank);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.FlatToRightBank);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.FlatToLeftBankIncline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.FlatToRightBankIncline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.FlatToLeftBankDecline25);
            //whitelistedTracks.Add(RCT2TrackElements.RCT2TrackElement.FlatToRightBankDecline25);


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

            //TODO: Marking valid track pieces as invalid
            //      The prior connection check is failing

            for (int i = 1; i < length + 2; i++)
            {
                List<RCT2TrackElements.RCT2TrackElement> candidates = RCT2TrackElements.FindValidSuccessors(whitelistedTracks, trackData.TrackData[i].TrackElement);
                bool reselect = false;

                do
                {
                    //If we have no candidates left
                    if (candidates.Count <= 0)
                    {
                        if (i < 1)
                        {
                            Console.WriteLine("ERROR: Unable to create Coaster - Index stepped back too far");
                            return null;
                        }
                        Console.WriteLine("ERROR: No Valid Track Pieces Found, Stepping back and starting again");
                        trackData.TrackData.RemoveAt(i--);
                        continue;
                    }

                    //Select our successor and remove it from the potential pool
                    RCT2TrackElements.RCT2TrackElement successor = candidates[random.Next(candidates.Count)];
                    candidates.Remove(successor);
                    RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[successor];

                    Console.WriteLine($"\tAttempting Track Piece {successor.ToString()}");

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
                    RCT2TrackData.InvalidityCode invalidityCode = trackData.CheckValidity();
                    if (invalidityCode != RCT2TrackData.InvalidityCode.Valid)
                    {
                        //Remove it and try again
                        reselect = true;
                        trackData.TrackData.Remove(trackData.TrackData.Last());
                        Console.WriteLine($"\tInvalid Selection, Code: {invalidityCode.ToString()}");
                    }
                    else
                    {
                        reselect = false;
                    }
                } while (reselect);

                Console.WriteLine($"{trackData.TrackData.Last().TrackElement.ToString()} Selected!");       
            }

            return trackData;
        }
    }
}
