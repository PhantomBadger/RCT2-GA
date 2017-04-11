﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCT2GA.RideData;

namespace RCT2GA
{
    class GeneticAlgorithm
    {
        float mutationRate;
        float crossoverRate;
        int populationSize;
        int generationCount;
        int length;

        List<RCT2RideData> population;
        List<RCT2RideData> nextPopulation;
        List<RCT2TrackElements.RCT2TrackElement> whitelistedTracks;

        Random random;

        public GeneticAlgorithm()
        {
            mutationRate = 0.01f;
            crossoverRate = 0.7f;
            populationSize = 100;
            generationCount = 1000;
            length = 30;

            population = new List<RCT2RideData>();
            nextPopulation = new List<RCT2RideData>();
            whitelistedTracks = new List<RCT2TrackElements.RCT2TrackElement>();
        
            random = new Random();

            WhitelistBasicTrackElements();
        }

        public void InitialiseParameters()
        {
            do
            {
                Console.WriteLine("Please enter an integer value for population size: ");
            } while (!int.TryParse(Console.ReadLine(), out populationSize));

            do
            {
                Console.WriteLine("Please enter an integer value for ride length: ");
            } while (!int.TryParse(Console.ReadLine(), out length));

            do
            {
                Console.WriteLine("Please enter an integer value for generation count: ");
            } while (!int.TryParse(Console.ReadLine(), out generationCount));

            do
            {
                Console.WriteLine("Please enter a float value for mutation rate: ");
            } while (!float.TryParse(Console.ReadLine(), out mutationRate));

            do
            {
                Console.WriteLine("Please enter a float value for crossover rate: ");
            } while (!float.TryParse(Console.ReadLine(), out crossoverRate));
        }

        public void InitialPopulationGeneration()
        {
            for (int i = 0; i < populationSize; i++)
            {
                RCT2RideData ride = GenerateWoodenRollerCoaster();
                population.Add(ride);
            }
        }

        public void PerformAlgorithm()
        {
            InitialPopulationGeneration();
            for (int i = 0; i < generationCount; i++)
            {
                //Generate the next generation
                NextGeneration();

                //Swap over the populations
                population = nextPopulation;
                nextPopulation.Clear();
            }
            Console.WriteLine("==================");
            Console.WriteLine("Evolution Complete");
            Console.WriteLine("==================");

            //Find the best one of the final generation
            RCT2RideData bestCoasterMyDude = population[0];
            int bestFitnessMyDude = CalculateFitness(bestCoasterMyDude);
            for (int i = 0; i < populationSize; i++)
            {
                int currentFitness = CalculateFitness(population[i]);
                if (currentFitness > bestFitnessMyDude)
                {
                    bestCoasterMyDude = population[i];
                    bestFitnessMyDude = currentFitness;
                }
            }

            //Print the best candidate
            for (int i = 0; i < bestCoasterMyDude.TrackData.TrackData.Count; i++)
            {
                Console.WriteLine(bestCoasterMyDude.TrackData.TrackData[i].TrackElement.ToString());
            }

        }

        private int CalculateFitness(RCT2RideData candidate)
        {
            int fitness = 0;

            //Get Displacement to End & Max Y Displacement
            Vector3 prevWorldPos = new Vector3(0.0f, 0.0f, 0.0f);
            List<RCT2TrackElements.RCT2TrackElement> additionalElements = new List<RCT2TrackElements.RCT2TrackElement>();
            int worldDirectionChange = 0;
            int maxYDisplacement = 0;
            for (int i = 0; i < candidate.TrackData.TrackData.Count; i++)
            {
                RCT2TrackElements.RCT2TrackElement currentElement = candidate.TrackData.TrackData[i].TrackElement;
                RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[currentElement];

                Vector3 worldDisplacement = candidate.TrackData.LocalDisplacementToWorld(property.Displacement, worldDirectionChange);

                if (worldDisplacement.Y >= maxYDisplacement)
                {
                    maxYDisplacement = (int)worldDisplacement.Y;
                }

                //Update World Position Changes
                prevWorldPos += worldDisplacement;

                //Update World Direction Changes
                worldDirectionChange = candidate.TrackData.UpdateRotation(worldDirectionChange, property.DirectionChange);
            }
            Vector3 displacementToEnd = new Vector3(0, 0, 0);
            displacementToEnd.X = Math.Abs(prevWorldPos.X);
            displacementToEnd.Y = Math.Abs(prevWorldPos.Y);
            displacementToEnd.Z = Math.Abs(prevWorldPos.Z);

            double displacementToEndLength = Math.Sqrt(Math.Pow(displacementToEnd.X, 2) + Math.Pow(displacementToEnd.Y, 2) + Math.Pow(displacementToEnd.Z, 2));

            fitness = (int)((candidate.ExcitementTimesTen / 1 + candidate.NauseaTimesTen) - (displacementToEndLength) + (maxYDisplacement));

            return fitness;
        }

        private RCT2RideData SelectCandidate()
        {
            if (population.Count <= 0)
            {
                Console.WriteLine("ERROR: Population is 0");
                return null;
            }

            //Get the total fitness for roulette wheel selection
            int totalFitness = 0;
            for (int i = 0; i < population.Count; i++)
            {
                totalFitness += CalculateFitness(population[i]);
            }

            //Get a random number
            int randomNumber = random.Next(totalFitness);

            //Perform Roulette Wheel Selection
            int partSum = 0;
            for (int i = 0; i < population.Count; i++)
            {
                partSum += CalculateFitness(population[i]);
                if (partSum >= randomNumber)
                {
                    return population[i];
                }
            }

            //Shouldnt ever reach here
            return population[0];
        }

        private List<RCT2RideData> Crossover(RCT2RideData parent1, RCT2RideData parent2)
        {
            List<RCT2RideData> children = new List<RCT2RideData>();
            int crossoverPoint = length - 1;
            bool redo = false;

            //Create crossover point
            if (random.NextDouble() >= crossoverRate)
            {
                crossoverPoint = random.Next(length);
            }

            do
            {
                //Add first halves to each child
                RCT2TrackData child1Track = new RCT2TrackData();
                RCT2TrackData child2Track = new RCT2TrackData();
                for (int i = 0; i <= crossoverPoint; i++)
                {
                    child1Track.TrackData.Add(parent1.TrackData.TrackData[i]);
                    child2Track.TrackData.Add(parent2.TrackData.TrackData[i]);
                }

                //Add second halves to each child
                for (int i = crossoverPoint; i < length; i++)
                {
                    child1Track.TrackData.Add(parent2.TrackData.TrackData[i]);
                    child2Track.TrackData.Add(parent1.TrackData.TrackData[i]);
                }

                RCT2RideData child1 = new RCT2RideData(parent1);
                RCT2RideData child2 = new RCT2RideData(parent2);
                child1.TrackData = child1Track;
                child2.TrackData = child2Track;

                //If the created children are invalid, keep trying
                //Wont cause an infinite loop as we will eventually crossover at point 0
                //Which acts as if we never crossed over at all
                if (child1.TrackData.CheckValidity() != RCT2TrackData.InvalidityCode.Valid ||
                    child2.TrackData.CheckValidity() != RCT2TrackData.InvalidityCode.Valid)
                {
                    redo = true;
                    crossoverPoint = random.Next(length);
                }
                else
                {
                    redo = false;
                    children.Add(child1);
                    children.Add(child2);
                }

            } while (redo);

            return children;
        }

        private RCT2RideData Mutation(RCT2RideData candidate)
        {
            for (int i = 2; i < candidate.TrackData.TrackData.Count; i++)
            {
                if (random.NextDouble() >= mutationRate)
                {
                    //Get possible candidates
                    RCT2RideData candidateCopy = new RCT2RideData(candidate);
                    List<RCT2TrackElements.RCT2TrackElement> candidateReplacements = RCT2TrackElements.FindValidSuccessors(whitelistedTracks, candidate.TrackData.TrackData[i].TrackElement);
                    bool redo = false;

                    do
                    {
                        //If we're out of possible replacements
                        if (candidateReplacements.Count <= 0)
                        {
                            return candidate;
                        }

                        //Construct our random element
                        RCT2TrackPiece randomElement = new RCT2TrackPiece();
                        randomElement.TrackElement = candidateReplacements[random.Next(candidateReplacements.Count)];
                        candidateReplacements.Remove(randomElement.TrackElement);
                        RCT2TrackElementProperty property = RCT2TrackElements.TrackElementPropertyMap[randomElement.TrackElement];
                        if (property.InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up25 ||
                            property.InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up60 ||
                            property.InputTrackDegree == RCT2TrackElementProperty.RCT2TrackDegree.Up90)
                        {
                            randomElement.Qualifier = new RCT2Qualifier()
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
                            randomElement.Qualifier = new RCT2Qualifier()
                            {
                                IsChainLift = false,
                                TrackColourSchemeNumber = 0,
                                TrackRotation = RideData.RCT2Qualifier.RCT2QualifierRotation.Zero,
                                AtTerminalStation = false,
                                StationNumber = 0
                            };
                        }

                        //Replace the existing element at that location with this
                        candidateCopy.TrackData.TrackData.RemoveAt(i);
                        candidateCopy.TrackData.TrackData.Insert(i, randomElement);

                        //If it makes the track invalid, try again
                        if (candidateCopy.TrackData.CheckValidity() != RCT2TrackData.InvalidityCode.Valid)
                        {
                            redo = true;
                        }
                        else
                        {
                            redo = false;
                        }

                    } while (redo);
                }
            }

            return candidate;
        }

        private void NextGeneration()
        {
            if (population.Count >= 2)
            {
                //Go through and populate most of our next generation with new children
                for (int i = 0; i < populationSize - 2; i++)
                {
                    RCT2RideData parent1 = SelectCandidate();
                    RCT2RideData parent2;
                    //Make sure the parents aren't the same
                    do
                    {
                        parent2 = SelectCandidate();
                    } while (parent2 == parent1);

                    //Crossover to create children
                    List <RCT2RideData> children = Crossover(parent1, parent2);

                    //Mutate the children
                    children[0] = Mutation(children[0]);
                    children[1] = Mutation(children[1]);

                    //Add them to the next population
                    nextPopulation.AddRange(children);
                }

                //Now add the best from this population as a form of Elitism
                RCT2RideData elitism1 = population[0];
                int elitism1Fitness = CalculateFitness(elitism1);
                RCT2RideData elitism2 = population[1];
                int elitism2Fitness = CalculateFitness(elitism2);

                for (int i = 0; i < population.Count; i++)
                {
                    int curFitness = CalculateFitness(population[i]);

                    if (curFitness > elitism1Fitness)
                    {
                        elitism1 = population[i];
                        elitism1Fitness = curFitness;
                    }
                    else if (curFitness > elitism2Fitness)
                    {
                        elitism2 = population[i];
                        elitism2Fitness = curFitness;
                    }
                }

                nextPopulation.Add(elitism1);
                nextPopulation.Add(elitism2);
            }
            else
            {
                Console.WriteLine("ERROR: Population Size must be at least 2");
            }
        }

        public RCT2RideData GenerateWoodenRollerCoaster()
        {
            RideData.RCT2RideData coaster = new RideData.RCT2RideData();

            //Track Type
            coaster.TrackType = new RideData.RCT2RideCode();
            coaster.TrackType.RideType = RideData.RCT2RideCode.RCT2TrackName.WoodenRollerCoaster6Seater;

            //Track Data
            coaster.TrackData = GenerateWoodenRollerCoasterTrack();

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

        private RCT2TrackData GenerateWoodenRollerCoasterTrack()
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
                            throw new Exception("ERROR: Unable to create Coaster - Index stepped back too far");
                        }
                        Console.WriteLine("ERROR: No Valid Track Pieces Found, Stepping back and starting again");
                        trackData.TrackData.RemoveAt(i--);


                        //TODO - FIX SOME SHIT IN HERE, CONTINUE IS DUMB REWORK IT
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

        private void WhitelistBasicTrackElements()
        {
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
        }
    }
}
