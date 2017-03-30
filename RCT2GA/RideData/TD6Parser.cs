using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCT2GA.RideData
{
    class TD6Parser
    {
        const float MPHToBit = 2.25f;
        const float GForceToBit = 0.32f;
        const float DropMeterToBit = 0.75f;
        const int TD6FileSize = 24735;

        /// <summary>
        /// Encode the RCT2RideData Structure into a Run-Length Unencoded Byte Array
        /// </summary>
        /// <param name="td6Data">The RCT2RideData Structure</param>
        /// <returns>A Byte array containing a full TD6 file</returns>
        public byte[] Encode(RCT2RideData td6Data)
        {
            List<byte> td6Bytes = new List<byte>();

            // Go through the data structure described here and add the bytes in
            // http://freerct.github.io/RCTTechDepot-Archive/TD6.html
            byte dummyByte = 0;

            //00 Track Type
            td6Bytes.Add((byte)RCT2RideCode.RideNameCodeMap[td6Data.TrackType.RideType]);

            //01 ?
            td6Bytes.Add(dummyByte);

            td6Data.RideFeatures.Populate(td6Data.TrackData);

            //02 - Ride Features Byte 0
            byte rideFeaturesByte0 = 0;
            //Straight Flat
            rideFeaturesByte0 |= (byte)((td6Data.RideFeatures.StraightFlat) ? 0x2 : 0x0);
            //Station Platform
            rideFeaturesByte0 |= (byte)((td6Data.RideFeatures.StationPlatform) ? 0x4 : 0x0);
            //Lift Chain
            rideFeaturesByte0 |= (byte)((td6Data.RideFeatures.LiftChain) ? 0x8 : 0x0);
            //Steep Lift Chain
            rideFeaturesByte0 |= (byte)((td6Data.RideFeatures.SteepLiftChain) ? 0x10 : 0x0);
            //Curve Lift Chain
            rideFeaturesByte0 |= (byte)((td6Data.RideFeatures.CurveLiftChain) ? 0x20 : 0x0);
            //Banking
            rideFeaturesByte0 |= (byte)((td6Data.RideFeatures.Banking) ? 0x40 : 0x0);
            //Vertical Loop
            rideFeaturesByte0 |= (byte)((td6Data.RideFeatures.VerticalLoop) ? 0x80 : 0x0);
            td6Bytes.Add(rideFeaturesByte0);

            //03 - Ride Features Byte 1
            byte rideFeaturesByte1 = 0;
            //Normal Slope
            rideFeaturesByte1 |= (byte)((td6Data.RideFeatures.NormalSlope) ? 0x1 : 0x0);
            //Steep Slope
            rideFeaturesByte1 |= (byte)((td6Data.RideFeatures.SteepSlope) ? 0x2 : 0x0);
            //Flat-To-Steep
            rideFeaturesByte1 |= (byte)((td6Data.RideFeatures.FlatToSteep) ? 0x4 : 0x0);
            //Sloped Curves
            rideFeaturesByte1 |= (byte)((td6Data.RideFeatures.SlopedCurves) ? 0x8 : 0x0);
            //Steep Twist
            rideFeaturesByte1 |= (byte)((td6Data.RideFeatures.SteepTwist) ? 0x10 : 0x0);
            //S-Bends
            rideFeaturesByte1 |= (byte)((td6Data.RideFeatures.SBends) ? 0x20 : 0x0);
            //Small radius curves
            rideFeaturesByte1 |= (byte)((td6Data.RideFeatures.SmallRadiusCurves) ? 0x40 : 0x0);
            //Small radius banked
            rideFeaturesByte1 |= (byte)((td6Data.RideFeatures.SmallRadiusBanked) ? 0x80 : 0x0);
            td6Bytes.Add(rideFeaturesByte1);

            //04 - Ride Features Byte 2
            byte rideFeaturesByte2 = 0;
            //Medium Radius Curves
            rideFeaturesByte2 |= (byte)((td6Data.RideFeatures.MediumRadiusCurves) ? 0x1 : 0x0);
            //Inline Twist
            rideFeaturesByte2 |= (byte)((td6Data.RideFeatures.InlineTwist) ? 0x2 : 0x0);
            //Half Loop
            rideFeaturesByte2 |= (byte)((td6Data.RideFeatures.HalfLoop) ? 0x4 : 0x0);
            //Half Corkscrew
            rideFeaturesByte2 |= (byte)((td6Data.RideFeatures.HalfCorkscrew) ? 0x8 : 0x0);
            //Tower Base/Vertical
            rideFeaturesByte2 |= (byte)((td6Data.RideFeatures.TowerBaseVertical) ? 0x10 : 0x0);
            //Helix Banked
            rideFeaturesByte2 |= (byte)((td6Data.RideFeatures.HelixBanked) ? 0x20 : 0x0);
            //Helix Banked
            rideFeaturesByte2 |= (byte)((td6Data.RideFeatures.HelixBanked) ? 0x40 : 0x0);
            //Helix Unbanked
            rideFeaturesByte2 |= (byte)((td6Data.RideFeatures.HelixUnbanked) ? 0x80 : 0x0);
            td6Bytes.Add(rideFeaturesByte2);

            //05 - Ride Features Byte 3
            byte rideFeaturesByte3 = 0;
            //Brakes
            rideFeaturesByte3 |= (byte)((td6Data.RideFeatures.Brakes) ? 0x1 : 0x0);
            //Booster
            rideFeaturesByte3 |= (byte)((td6Data.RideFeatures.Booster) ? 0x2 : 0x0);
            //On-Ride-Photo
            rideFeaturesByte3 |= (byte)((td6Data.RideFeatures.OnRidePhoto) ? 0x4 : 0x0);
            //Water Splash
            rideFeaturesByte3 |= (byte)((td6Data.RideFeatures.WaterSplash) ? 0x8 : 0x0);
            //Vertical Track
            rideFeaturesByte3 |= (byte)((td6Data.RideFeatures.VerticalTrack) ? 0x10 : 0x0);
            //Barrel Roll
            rideFeaturesByte3 |= (byte)((td6Data.RideFeatures.BarrelRoll) ? 0x20 : 0x0);
            //Launched Lift Hill
            rideFeaturesByte3 |= (byte)((td6Data.RideFeatures.LaunchedLiftHill) ? 0x40 : 0x0);
            //Large Half Loop
            rideFeaturesByte3 |= (byte)((td6Data.RideFeatures.LargeHalfLoop) ? 0x80 : 0x0);
            td6Bytes.Add(rideFeaturesByte3);

            //06 Operating Mode
            td6Bytes.Add((byte)td6Data.OperatingMode);

            //07 Vehicle Colour Scheme
            //Third bit is set to 1 for RCT2
            td6Bytes.Add((byte)(0x8 + td6Data.ColourScheme.ColourMode));

            //08-47 32 sets of two byte colour specifiers for vehicles. 
            //first byte = body colour, second byte = trim colour
            for (int i = 0; i < 32; i++)
            {
                if (i < td6Data.ColourScheme.BodyColours.Length)
                {
                    td6Bytes.Add((byte)td6Data.ColourScheme.BodyColours[i]);
                }
                else
                {
                    td6Bytes.Add((byte)RCT2VehicleColourScheme.RCT2Colour.Black);
                }

                if (i < td6Data.ColourScheme.TrimColours.Length)
                {
                    td6Bytes.Add((byte)td6Data.ColourScheme.TrimColours[i]);
                }
                else
                {
                    td6Bytes.Add((byte)RCT2VehicleColourScheme.RCT2Colour.Black);
                }
            }

            //48 ?
            td6Bytes.Add(dummyByte);

            //49 Entrance Style
            td6Bytes.Add((byte)td6Data.EntranceStyle);

            //4A Air Time (in seconds / 4)
            td6Bytes.Add((byte)(td6Data.AirTimeInSeconds / 4));

            //4B Departure Control Flags
            //http://freerct.github.io/RCTTechDepot-Archive/controlFlags.html
            byte departureControlFlagsByte = 0;

            //Load Info
            if (td6Data.DepartureFlags.WaitForQuarterLoad)
            {
                departureControlFlagsByte = 0;
            }
            else if (td6Data.DepartureFlags.WaitForHalfLoad)
            {
                departureControlFlagsByte = 0x1;
            }
            else if (td6Data.DepartureFlags.WaitForThreeQuarterLoad)
            {
                departureControlFlagsByte = 0x2;
            }
            else if (td6Data.DepartureFlags.WaitForFullLoad)
            {
                departureControlFlagsByte = 0x3;
            }
            else if (td6Data.DepartureFlags.WaitForAnyLoad)
            {
                departureControlFlagsByte = 0x4;
            }

            //Departure Info
            if (td6Data.DepartureFlags.UseMaximumTime)
            {
                departureControlFlagsByte |= 0x80;
            }
            else if (td6Data.DepartureFlags.UseMinimumTime)
            {
                departureControlFlagsByte |= 0x40;
            }
            else if (td6Data.DepartureFlags.SyncWithAdjacentStation)
            {
                departureControlFlagsByte |= 0x20;
            }
            else if (td6Data.DepartureFlags.LeaveIfAnotherArrives)
            {
                departureControlFlagsByte |= 0x10;
            }
            else if (td6Data.DepartureFlags.WaitForLoad)
            {
                departureControlFlagsByte |= 0x8;
            }

            td6Bytes.Add(departureControlFlagsByte);

            //4C Number of Trains
            td6Bytes.Add((byte)td6Data.NumberOfTrains);

            //4D Number Of Cars per Train
            td6Bytes.Add((byte)td6Data.NumberOfCarsPerTrain);

            //4E Minimum Wait Time in Seconds
            td6Bytes.Add((byte)td6Data.MinWaitTimeInSeconds);

            //4F Maximum Wait Time in Seconds
            td6Bytes.Add((byte)td6Data.MaxWaitTimeInSeconds);

            //50 Speed (Powered Launch/Chairlift/Whoa Belly, or num of laps for go kart, or num of people in a maze)
            //1 bit = 3.616 km/hr 2.25 mph
            if (td6Data.SpeedOfPoweredLaunch != default(float))
            {
                //Speed of powered launch
                td6Bytes.Add((byte)(Math.Round(td6Data.SpeedOfPoweredLaunch / MPHToBit)));
            }
            else if (td6Data.NumberOfGoKartLaps != default(int))
            {
                //Max number of go kart laps
                td6Bytes.Add((byte)td6Data.NumberOfGoKartLaps);
            }
            else
            {
                //Max Number of people in maze
                td6Bytes.Add((byte)td6Data.MaxNumberOfPeopleMaze);
            }

            //51 Max Speed of Ride
            //1 bit = 3.616 km/hr 2.25 mph
            td6Bytes.Add((byte)(Math.Round(td6Data.MaxSpeedOfRide / MPHToBit)));

            //52 Average Speed of Ride
            //1 bit = 3.616 km/hr 2.25 mph
            td6Bytes.Add((byte)(Math.Round((td6Data.AverageSpeedOfRide / MPHToBit))));

            //53-54 Ride Length in Meters
            td6Bytes.Add((byte)td6Data.RideLengthInMetres);
            td6Bytes.Add((byte)(td6Data.RideLengthInMetres >> 8));

            //55 Positive G-Force 
            //1 bit = 0.32g
            td6Bytes.Add((byte)(Math.Round((td6Data.PosGForce / GForceToBit))));

            //56 Negative G-Force
            //1 bit = 0.32g
            td6Bytes.Add((byte)(Math.Round((td6Data.NegGForce / GForceToBit))));

            //57 Lateral G-Force
            //1 bit = 0.32g
            td6Bytes.Add((byte)(Math.Round((td6Data.LatGForce / GForceToBit))));

            //58 Number of Inversions
            //Max 31
            td6Bytes.Add((byte)Math.Min(31, td6Data.NumberOfInversions));

            //59 Number of drops
            //Max 63
            td6Bytes.Add((byte)Math.Min(63, td6Data.NumberOfDrops));

            //5A Highest Drop
            //1 bit = 3/4 meter
            td6Bytes.Add((byte)(Math.Round((td6Data.HighestDrop / DropMeterToBit))));

            //5B Excitement
            td6Bytes.Add((byte)td6Data.ExcitementTimesTen);

            //5C Intensity
            td6Bytes.Add((byte)td6Data.IntensityTimesTen);

            //5D Nausea
            td6Bytes.Add((byte)td6Data.NauseaTimesTen);

            //5E ?
            td6Bytes.Add(dummyByte);

            //5F ?
            td6Bytes.Add(dummyByte);

            //60 Track Main Spine Color (Main)
            td6Bytes.Add((byte)td6Data.TrackMainColour);

            //61 Track Main Spine Color (Alt 1)
            td6Bytes.Add((byte)td6Data.TrackMainColourAlt1);

            //62 Track Main Spine Color (Alt 2)
            td6Bytes.Add((byte)td6Data.TrackMainColourAlt2);

            //63 Track Main Spine Color (Alt 3)
            td6Bytes.Add((byte)td6Data.TrackMainColourAlt3);

            //64 Track Additional Rail Color (Main)
            td6Bytes.Add((byte)td6Data.TrackAdditionalColour);

            //65 Track Additional Rail Color (Alt 1)
            td6Bytes.Add((byte)td6Data.TrackAdditionalColourAlt1);

            //66 Track Additional Rail Color (Alt 2)
            td6Bytes.Add((byte)td6Data.TrackAdditionalColourAlt2);

            //67 Track Additional Rail Color (Alt 3)
            td6Bytes.Add((byte)td6Data.TrackAdditionalColourAlt3);

            //68 Track Support Color (Main)
            td6Bytes.Add((byte)td6Data.TrackSupportColour);

            //69 Track Support Color (Alt 1)
            td6Bytes.Add((byte)td6Data.TrackSupportColourAlt1);

            //6A Track Support Color (Alt 2)
            td6Bytes.Add((byte)td6Data.TrackSupportColourAlt2);

            //6B Track Support Color (Alt 3)
            td6Bytes.Add((byte)td6Data.TrackSupportColourAlt3);

            //6C ?
            td6Bytes.Add(dummyByte);

            //6D ?
            td6Bytes.Add(dummyByte);

            //6E ?
            td6Bytes.Add(dummyByte);

            //6F - Six Flags Design if MSB is 1
            td6Bytes.Add(td6Data.IsSixFlagsDesign ? (byte)0x80 : dummyByte);

            //70-73 DAT file flags
            //TODO
            //For now we'll cheat and always use ones for a PTCT1 Track
            td6Bytes.Add(0x80);
            td6Bytes.Add(0xB1);
            td6Bytes.Add(0x58);
            td6Bytes.Add(0x0C);

            //74-7B Vehicle (Alphanumeric - 8 characters with trailing spaces)
            //We're using Wooden Roller Coaster - 4 Seater (PTCT1) for our example
            //And so this will only work properly with PTCT1, as the DAT file flags / checksum will be different
            string vehicle = RCT2RideCode.RideNameVehicleMap[td6Data.TrackType.RideType];
            for (int i = 0; i < 8; i++)
            {
                if (i < vehicle.Length)
                {
                    td6Bytes.Add((byte)vehicle[i]);
                }
                else
                {
                    td6Bytes.Add((byte)' ');
                }
            }


            //7C-7F DAT file checksum
            //TODO
            //For now we'll cheat and always use ones for a PTCT1 Track
            td6Bytes.Add(0xB2);
            td6Bytes.Add(0x81);
            td6Bytes.Add(0x15);
            td6Bytes.Add(0xFF);

            //80-81 Map Space Required (X and Y)
            td6Bytes.Add((byte)td6Data.RequiredMapSpace.X);
            td6Bytes.Add((byte)td6Data.RequiredMapSpace.Y);

            //82-A1 One-byte colour specifiers for vehicles additional colour
            for (int i = 0; i < 32; i++)
            {
                if (i < td6Data.ColourScheme.AdditionalColours.Length)
                {
                    td6Bytes.Add((byte)td6Data.ColourScheme.AdditionalColours[i]);
                }
                else
                {
                    td6Bytes.Add((byte)RCT2VehicleColourScheme.RCT2Colour.Black);
                }
            }

            //A2 - Low 5 bites = lift chain speed (1.6 km/hr per bit)
            //     Upper 3 bits = number of circuits
            byte a2Byte = (byte)(td6Data.NumberOfCircuits & 0x7);
            a2Byte <<= 5;
            a2Byte |= (byte)((byte)td6Data.LiftChainSpeed & 0x1F);
            td6Bytes.Add(a2Byte);

            //A3 Beginning of track data
            //Each track element is the track segment, then the qualifier, ends with an FF for track segment
            for (int i = 0; i < td6Data.TrackData.TrackData.Count(); i++)
            {
                if (td6Data.TrackData.TrackData[i].TrackElement == RCT2TrackElements.RCT2TrackElement.EndOfTrack)
                {
                    break;
                }

                RCT2TrackElements.RCT2TrackElement currentTrackPiece = td6Data.TrackData.TrackData[i].TrackElement;
                byte currentTrackByte = (byte)currentTrackPiece;

                byte qualifierByte = 0;
                //7 Bit - Chain lift
                if (currentTrackPiece == RCT2TrackElements.RCT2TrackElement.PoweredLift)
                {
                    qualifierByte |= 0x80;
                }

                //6 Bit - Inverted
                if (RCT2TrackElements.TrackElementPropertyMap[currentTrackPiece].InputTrackBank == RCT2TrackElementProperty.RCT2TrackBank.Flipped ||
                    RCT2TrackElements.TrackElementPropertyMap[currentTrackPiece].OutputTrackBank == RCT2TrackElementProperty.RCT2TrackBank.Flipped)
                {
                    qualifierByte |= 0x40;
                }

                //5 & 4 - Colour Scheme
                qualifierByte |= (byte)((td6Data.TrackData.TrackData[i].Qualifier.TrackColourSchemeNumber) << 4);

                //3, 2, 1 - Stations:
                if (td6Data.TrackData.TrackData[i].Qualifier.AtTerminalStation)
                {
                    qualifierByte |= 0x8;
                    qualifierByte |= (byte)td6Data.TrackData.TrackData[i].Qualifier.StationNumber;
                }
                else
                {
                    //Rotation value
                    qualifierByte |= (byte)td6Data.TrackData.TrackData[i].Qualifier.TrackRotation;
                }

                //Add to file
                Console.WriteLine("Adding Track Piece: " + currentTrackPiece.ToString() + ", with byte: " + currentTrackByte.ToString());
                Console.WriteLine("Adding Qualifier: " + qualifierByte.ToString());

                td6Bytes.Add(currentTrackByte);
                td6Bytes.Add(qualifierByte);

            }

            //End of track byte
            td6Bytes.Add(0xFF);

            //Add in the Entracne/Exit data
            //This is just entrance/exit data taken from an existing RCT2 TD6 file
            //With them next to each other on a two-station long area
            td6Bytes.Add(0x00);
            td6Bytes.Add(0x03);
            td6Bytes.Add(0x00);
            td6Bytes.Add(0x00);
            td6Bytes.Add(0x20);
            td6Bytes.Add(0x00);
            td6Bytes.Add(0x00);
            td6Bytes.Add(0x83);
            td6Bytes.Add(0xE0);
            td6Bytes.Add(0xFF);
            td6Bytes.Add(0x20);
            td6Bytes.Add(0x00);
            td6Bytes.Add(0xFF);
            td6Bytes.Add(0xFF);

            //Pad out to 24,735 which is the fixed length
            for (int i = td6Bytes.Count; i < TD6FileSize; i++)
            {
                td6Bytes.Add(dummyByte);
            }

            return td6Bytes.ToArray();
        }

        /// <summary>
        /// Decode an array of Run-Length Unencoded Bytes into the data structure
        /// </summary>
        /// <param name="rawBytes">The RLE decoded byte array</param>
        /// <returns>The created TD6 Data Structure represented as RCT2RideData</returns>
        public RCT2RideData Decode(byte[] rawBytes)
        {
            RCT2RideData td6Data = new RCT2RideData();


            return td6Data;
        }
        
    }
}
