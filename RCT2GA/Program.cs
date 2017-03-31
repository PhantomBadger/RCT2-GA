using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RCT2GA
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valid = false;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - RLE Encoding/Decoding");
                Console.WriteLine("2 - Test TD6 Writing");
                Console.WriteLine("Press which key you want...");

                string key = Console.ReadLine();
                int keyVal;
                if (!int.TryParse(key, out keyVal))
                {
                    Console.WriteLine("Invalid Key. Key not a number, press any key to continue...");
                    Console.ReadKey();
                    valid = false;
                    continue;
                }

                switch (keyVal)
                {
                    case 1:
                        Console.Clear();
                        valid = true;
                        RLEFunction();
                        break;
                    case 2:
                        Console.Clear();
                        valid = true;
                        TestTD6Writer();
                        break;
                    default:
                        Console.WriteLine("Invalid Key. Key not one of the given values, press any key to continue...");
                        Console.ReadKey();
                        valid = false;
                        continue;
                }
            } while (!valid);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void TestTD6Writer()
        {
            RideData.RCT2RideData testCoaster = GenerateTestCoaster();

            RideData.TD6Parser td6Parser = new RideData.TD6Parser();
            byte[] td6Bytes = td6Parser.Encode(testCoaster);

            //Console.WriteLine("Directory to Save to:");
            string directory = @"G:\GOG Games\RollerCoaster Tycoon 2 Triple Thrill Pack\Tracks\User Tracks\Generated Test Coasters";
            string filename = "TEST_" + DateTime.Now.ToString("yyMMddhhmmss");

            File.WriteAllBytes(directory + "\\UNENCODED_" + filename + ".td6", td6Bytes);

            RLEParser rleParser = new RLEParser();
            byte[] encodedTD6Bytes = rleParser.Encode(td6Bytes);

            File.WriteAllBytes(directory + "\\" + filename + ".td6", encodedTD6Bytes);

            Console.WriteLine("Complete");
        }

        static void RLEFunction()
        {
            //Test output decoded TD6 file
            Console.WriteLine("File location of TD6 File:");
            string filename = Console.ReadLine().Trim('"');

            //Read in the raw bytes
            byte[] rawBytes;

            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} does not exist!");
                return;
            }

            //Read in all the raw bytes
            using (MemoryStream ms = new MemoryStream())
            {
                Stream stream = File.Open(filename, FileMode.Open);

                stream.CopyTo(ms);
                rawBytes = ms.ToArray();
            }

            //Ignore the last 4 bytes as thats the checksum
            rawBytes = rawBytes.Take(rawBytes.Count() - 4).ToArray();

            //Decode the file and write it out
            RLEParser decoder = new RLEParser();
            byte[] decodedBytes = decoder.Decode(rawBytes);
            if (decodedBytes != null)
            {
                Console.WriteLine("Writing decoded file");
                string decodedFileName = Path.GetDirectoryName(filename) + "\\DECODED_" + Path.GetFileName(filename);

                File.WriteAllBytes(decodedFileName, decodedBytes);
            }

            Console.WriteLine("Re-encoding the file");

            byte[] encodedBytes = decoder.Encode(decodedBytes);

            string recodedFileName = Path.GetDirectoryName(filename) + "\\RECODED_" + Path.GetFileName(filename);

            File.WriteAllBytes(recodedFileName, encodedBytes);

            Console.WriteLine("Complete");
        }

        static RideData.RCT2RideData GenerateTestCoaster()
        {
            RideData.RCT2RideData testCoaster = new RideData.RCT2RideData();

            //Track Type
            testCoaster.TrackType = new RideData.RCT2RideCode();
            testCoaster.TrackType.RideType = RideData.RCT2RideCode.RCT2TrackName.WoodenRollerCoaster6Seater;

            //Track Data
            testCoaster.TrackData = new RideData.RCT2TrackData();

            //====== Track Generation ======
            #region TrackGen

            //Begin Station
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
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
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
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

            //Left Turn
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross3,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Right Turn
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.RightQuarterTurnAcross3,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat To Incline 25
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.FlatToIncline25,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = true,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Incline 25
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Incline25,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = true,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Incline 25 to Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Incline25ToFlat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = true,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Left Turn
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross3,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Left Turn
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross3,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat To Decline 25
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.FlatToDecline25,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Decline 25
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Decline25,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Decline 25 To Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Decline25ToFlat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Flat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Flat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Flat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Flat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Flat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Left Turn
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross3,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Flat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Flat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Flat
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.Flat,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //Left Turn
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.LeftQuarterTurnAcross3,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });

            //End of Track
            testCoaster.TrackData.TrackData.Add(new RideData.RCT2TrackPiece()
            {
                TrackElement = RideData.RCT2TrackElements.RCT2TrackElement.EndOfTrack,
                Qualifier = new RideData.RCT2Qualifier()
                {
                    IsChainLift = false,
                    TrackColourSchemeNumber = 0,
                    TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                    AtTerminalStation = false,
                    StationNumber = 0
                }
            });
            #endregion
            //====== End of Track Gen ======

            //Ride Features
            testCoaster.RideFeatures = new RideData.RCT2RideFeatures();
            testCoaster.RideFeatures.Populate(testCoaster.TrackData);

            //Operating Mode
            testCoaster.OperatingMode = RideData.RCT2RideData.RCT2OperatingModes.ContinuousCircuit;

            //Colour Scheme
            testCoaster.ColourScheme = new RideData.RCT2VehicleColourScheme();
            testCoaster.ColourScheme.ColourMode = RideData.RCT2VehicleColourScheme.RCT2VehicleColourMode.AllSameColour;
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

            testCoaster.ColourScheme.BodyColours = bodyColours.ToArray();
            testCoaster.ColourScheme.TrimColours = trimColours.ToArray();
            testCoaster.ColourScheme.AdditionalColours = additionalColours.ToArray();

            //Entrance Style
            testCoaster.EntranceStyle = RideData.RCT2RideData.RCT2EntranceStyle.Plain;

            //Air Time In Seconds
            testCoaster.TrackData.PopulateRideStatistics();
            testCoaster.AirTimeInSeconds = testCoaster.TrackData.AirTimeInSeconds;

            //Departure Flags
            testCoaster.DepartureFlags = new RideData.RCT2DepartureControlFlags();
            testCoaster.DepartureFlags.UseMinimumTime = true;
            testCoaster.DepartureFlags.WaitForFullLoad = true;

            //Number of Trains
            testCoaster.NumberOfTrains = 1;

            //Number of Cars per Train
            testCoaster.NumberOfCarsPerTrain = 2;

            //Min Wait Time in Seconds
            testCoaster.MinWaitTimeInSeconds = 10;

            //Max Wait Time in Seconds
            testCoaster.MaxWaitTimeInSeconds = 60;

            //Speed of Powered Launch/Number of Go Kart Laps/Max number of people in Maze
            testCoaster.SpeedOfPoweredLaunch = 0;
            testCoaster.NumberOfGoKartLaps = 0;
            testCoaster.MaxNumberOfPeopleMaze = 0;

            //Max Speed of Ride
            testCoaster.MaxSpeedOfRide = testCoaster.TrackData.MaxSpeed;

            //Average Speed of Ride
            testCoaster.AverageSpeedOfRide = testCoaster.TrackData.AverageSpeed;

            //Ride length in metres
            testCoaster.RideLengthInMetres = testCoaster.TrackData.CalculateRideLengthInMeters();

            //Pos G Force
            testCoaster.PosGForce = testCoaster.TrackData.MaxPositiveG;

            //Neg G Force
            testCoaster.NegGForce = testCoaster.TrackData.MaxNegativeG;

            //Lat G Force
            testCoaster.LatGForce = testCoaster.TrackData.MaxLateralG;

            //Number of Inversions
            testCoaster.NumberOfInversions = testCoaster.TrackData.NumOfInversions;

            //Number of Drops
            testCoaster.NumberOfDrops = testCoaster.TrackData.NumOfDrops;

            //Highest Drop
            testCoaster.HighestDrop = testCoaster.TrackData.HighestDrop;

            //Excitement Times Ten
            testCoaster.ExcitementTimesTen = testCoaster.TrackData.Excitement * 10;

            //Intensity Times Ten
            testCoaster.IntensityTimesTen = testCoaster.TrackData.Intensity * 10;

            //Nausea Times Ten
            testCoaster.NauseaTimesTen = testCoaster.TrackData.Nausea * 10;

            //Main Track Colour
            testCoaster.TrackMainColour = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackMainColourAlt1 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackMainColourAlt2 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackMainColourAlt3 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));

            //Additional Track Colour
            testCoaster.TrackAdditionalColour = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackAdditionalColourAlt1 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackAdditionalColourAlt2 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackAdditionalColourAlt3 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));

            //Support Track Colour
            testCoaster.TrackSupportColour = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackSupportColourAlt1 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackSupportColourAlt2 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));
            testCoaster.TrackSupportColourAlt3 = (RideData.RCT2VehicleColourScheme.RCT2Colour)colourValues.GetValue(random.Next(colourValues.Length));

            //Is Six Flag Design
            testCoaster.IsSixFlagsDesign = false;

            //DAT File Header
            //We scum this in the TD6 Parser so it's not needed to be filled yet
            //TODO
            testCoaster.DatFile = new RideData.DATFileHeader();

            //DAT File Checksum
            testCoaster.DatChecksum = testCoaster.DatFile.CalculateChecksum(RideData.RCT2RideCode.RideNameVehicleMap[testCoaster.TrackType.RideType]);

            //Required Map Space
            testCoaster.RequiredMapSpace = testCoaster.TrackData.CalculateRequiredMapSpace();

            //Lift Chain Speed
            testCoaster.LiftChainSpeed = 5;

            //Number of Circuits
            testCoaster.NumberOfCircuits = 1;

            return testCoaster;
        }
    }
}
