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
        /// <summary>
        /// Encode the RCT2RideData Structure into a Run-Length Unencoded Byte Array
        /// </summary>
        /// <param name="td6Data">The RCT2RideData Structure</param>
        /// <returns></returns>
        byte[] Encode(RCT2RideData td6Data)
        {
            List<byte> td6Bytes = new List<byte>();

            // Go through the data structure described here and add the bytes in
            // http://freerct.github.io/RCTTechDepot-Archive/TD6.html
            byte dummyByte = 0;

            //00 Track Type
            //TODO: Finish The RCT2RideCode Class into an enum

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
            td6Bytes.Add((byte)(0x4 + td6Data.ColourScheme.ColourMode));

            //08-47 32 sets of two byte colour specifiers for vehicles. 
            //first byte = body colour, second byte = trim colour
            //TODO

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
                int numberOfBits = (int)(td6Data.SpeedOfPoweredLaunch / 2.25f);
                numberOfBits = Math.Min(8, numberOfBits);

                byte maskByte = 0x1;
                byte sppedOfPoweredLaunchByte = 0;
                for (int i = 0; i < numberOfBits; i++)
                {
                    sppedOfPoweredLaunchByte |= maskByte;
                    maskByte <<= 1;
                }
            }
            else if (td6Data.NumberOfGoKartLaps != default(int))
            {
                //Max number of go kart laps
            }
            else
            {
                //Max Number of people in maze
            }
            //TODO

            //51 Max Speed of Ride
            //1 bit = 3.616 km/hr 2.25 mph
            //TODO

            //52 Average Speed of Ride
            //1 bit = 3.616 km/hr 2.25 mph
            //TODO

            //53-54 Ride Length in Meters
            //TODO

            //55 Positive G-Force 
            //1 bit = 0.32g
            //TODO

            //56 Negative G-Force
            //1 bit = 0.32g
            //TODO

            //57 Lateral G-Force
            //1 bit = 0.32g
            //TODO

            //58 Number of Inversions
            //Max 31
            td6Bytes.Add((byte)Math.Min(31, td6Data.NumberOfInversions));

            //59 Number of drops
            //Max 63
            td6Bytes.Add((byte)Math.Min(31, td6Data.NumberOfDrops));

            //5A Highest Drop
            //1 bit = 3/4 meter
            //TODO

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

            //60-6B Various Colours
            //TODO

            //6C ?
            td6Bytes.Add(dummyByte);

            //6D ?
            td6Bytes.Add(dummyByte);

            //6E ?
            td6Bytes.Add(dummyByte);

            //6F - Six Flags Design if MSB is 1
            td6Bytes.Add(dummyByte);

            //70-73 DAT file flags
            //TODO

            //74-7B Vehicle (Alphanumeric - 8 characters with trailing spaces
            //TODO

            //7C-7F DAT file checksum
            //TODO

            //80-81 Map Space Required (X and Y)
            //TODO

            //82-A1 One-byte colour specifiers for vehicles additional colour
            //TODO

            //A2 - Low 5 bites = lift chain speed (1.6 km/hr per bit)
            //     Upper 3 bits = number of circuits
            //TODO

            //A3 Beginning of track data
            //Each track element is the track segment, then the qualifier, ends with an FF for track segment
            for (int i = 0; i < td6Data.TrackData.TrackData.Count(); i++)
            {
                if (td6Data.TrackData.TrackData[i].TrackElement == RCT2TrackElements.RCT2TrackElement.EndOfTrack)
                {
                    break;
                }

                td6Bytes.Add((byte)td6Data.TrackData.TrackData[i].TrackElement);
                //TODO - Qualifier
            }

            //End of track byte
            td6Bytes.Add(0xFF);

            //TODO Scenary Items


            return td6Bytes.ToArray();
        }

        /// <summary>
        /// Decode an array of Run-Length Unencoded Bytes into the data structure
        /// </summary>
        /// <param name="rawBytes">The RLE decoded byte array</param>
        /// <returns>The created TD6 Data Structure represented as RCT2RideData</returns>
        RCT2RideData Decode(byte[] rawBytes)
        {
            RCT2RideData td6Data = new RCT2RideData();


            return td6Data;
        }
        
    }
}
