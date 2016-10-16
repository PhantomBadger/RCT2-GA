using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RCT2GA
{
    //Run-Length Encoding Parser
    class RLEParser
    {
        const int TD6ChecksumModifier = 0x1D4C1;

        //Decode the RLE Bytes
        public byte[] Decode(byte[] encodedBytes)
        {
            List<byte> decodedBytes = new List<byte>();

            //Decode the bytes - Run Length Encoding

            //Go through each byte
            for (int i = 0; i < encodedBytes.Count(); i++)
            {
                byte b = encodedBytes[i];

                //Get the MSB
                bool msb = GetBit(b, 1);

                //If MSB is false(0) then the byte is a counter of how many bytes to copy
                if (!msb)
                {
                    //Get the next x bytes
                    int bCounter = Math.Abs(Convert.ToInt32(b)) + 1;

                    //Go to the next byte
                    i++;

                    //And add them to our decoded stream
                    int positionChange = 0;
                    for (int j = i; j < encodedBytes.Length && j < (i + bCounter); j++)
                    {
                        decodedBytes.Add(encodedBytes[j]);
                        positionChange++;
                    }

                    //Offset the position change by one to account for the byte we skipped ahead to
                    i += (positionChange - 1);
                }
                //If MSB is true(1) then the byte is a flag to duplicate data, read next byte and copy it -B+1 times
                else
                {
                    if (i + 1 <= encodedBytes.Length)
                    {
                        byte byteToCopy = encodedBytes[i + 1];

                        //Flip the byte and + 1, or we can just do 257 - the byte value and cheat a little bit
                        int copyCounter = 257 - Math.Abs(Convert.ToInt32(b));

                        for (int j = 0; j < copyCounter; j++)
                        {
                            decodedBytes.Add(byteToCopy);
                        }

                        i++;
                    }
                    else
                    {
                        Console.WriteLine("Copy byte went out of bounds");
                        return null;
                    }
                }
            }

            return decodedBytes.ToArray();
        }

        /// <summary>
        /// Encodes the raw bytes to the Run-Length Encoding required for a TD6 file, inc Checksum
        /// </summary>
        /// <param name="rawBytes">The unencoded byte array</param>
        /// <returns>The encoded byte array</returns>
        public byte[] Encode(byte[] rawBytes)
        {
            List<byte> encodedBytes = new List<byte>();

            for (int i = 0; i < rawBytes.Count(); i++)
            {
                byte curByte = rawBytes[i];

                //Check the next byte
                if (i + 1 >= rawBytes.Count())
                {
                    //Next byte is end of file, so we done Im p sure
                    break;
                }

                byte peekByte = rawBytes[i + 1];

                //If they're different, then we need to set a copy byte (0 MSB Byte = amount of vals to copy -1)
                if (curByte != peekByte)
                {
                    List<byte> bytesToCopy = new List<byte>();
                    int amountToCopy = 1;

                    //Add the initial byte to our copy list
                    bytesToCopy.Add(curByte);

                    //Set the 125 (0-124) copy cap as thats the size limit in the internal RCT program
                    for (int j = i + 1; j < rawBytes.Count() && amountToCopy < 124; j++)
                    {
                        curByte = rawBytes[j];

                        //Check if the next value is the end
                        if (j + 1 >= rawBytes.Count())
                        {
                            //If it is, we add our current and bail
                            bytesToCopy.Add(curByte);
                            amountToCopy++;
                            break;
                        }

                        //If it isnt we record it and continue as normal
                        peekByte = rawBytes[j + 1];

                        //Then make sure we're still not going through duplicates
                        if (curByte != peekByte)
                        {
                            bytesToCopy.Add(curByte);
                            amountToCopy++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    //Create the copy byte
                    byte copyByte = Convert.ToByte(amountToCopy -1);

                    encodedBytes.Add(copyByte);
                    for (int j = 0; j < bytesToCopy.Count(); j++)
                    {
                        encodedBytes.Add(bytesToCopy[j]);
                    }

                    //Update our increment
                    i += bytesToCopy.Count() - 1;
                }
                //If they're the same, then we need to set a dupe byte (1 MSB Byte = amount of times to copy next byte)
                else
                {
                    
                    byte byteToDuplicate = curByte;
                    int duplicateCount = 1;

                    for (int j = i + 1; j < rawBytes.Count() - 1 && duplicateCount < 124; j++)
                    {
                        curByte = rawBytes[j];
                        peekByte = rawBytes[j + 1];

                        if (curByte != peekByte)
                        {
                            break;
                        }
                        else
                        {
                            duplicateCount++;
                        }
                    }

                    //Create the duplicate flag byte
                    byte duplicateByte = (byte)(-duplicateCount);

                    encodedBytes.Add(duplicateByte);
                    encodedBytes.Add(byteToDuplicate);

                    i += duplicateCount;
                }
            }

            uint checksum = CalculateChecksum(encodedBytes.ToArray());

            byte[] checksumArray = BitConverter.GetBytes(checksum);
            //checksumArray = checksumArray.Reverse().ToArray();

            for (int i = 0; i < checksumArray.Count(); i++)
            {
                encodedBytes.Add(checksumArray[i]);
            }

            return encodedBytes.ToArray();
        }

        private bool GetBit(byte b, int bitNumber)
        {
            string binaryString = Convert.ToString(b, 2).PadLeft(8, '0');

            //Turn into bool
            return (binaryString[bitNumber - 1] != '0');
        }

        private uint CalculateChecksum(byte[] encodedBytes)
        {
            uint checksum = 0;

            for (int i = 0; i < encodedBytes.Count(); i++)
            {
                //Add to the summation register
                //Use casting to byte to limit it to 8 bits
                uint newByte = checksum + encodedBytes[i];
                checksum = (checksum & 0xFFFFFF00) | (newByte & 0xFF);
                //Rotate to the left by 3 bits
                checksum = RotateByteLeft(checksum, 3);
            }

            //Apply the offset to the checksum
            checksum -= 0x1D4C1;

            return checksum;
        }

        private uint RotateByteLeft(uint val, int num)
        {
            return (val << num) | (val >> 32 - num);
        }
    }
}
