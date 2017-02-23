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

            //02 - Ride Features Byte 0
            //03 - Ride Features Byte 1
            //04 - Ride Features Byte 2
            //05 - Ride Features Byte 3
            //TODO

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
            //TODO: td6Bytes.Add() http://freerct.github.io/RCTTechDepot-Archive/controlFlags.html

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
