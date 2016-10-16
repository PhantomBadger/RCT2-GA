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
            //TEMP
            //CURRENTLY ONLY DECODES & RE-ENCODES AN ENTERED FILE
    
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
            Console.ReadLine();

        }
    }
}
