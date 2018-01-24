using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EventHubAvroReader
{
    public class AvroParser
    {
        public static List<EventHubAvroData> ParseAvroFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Missing Avro file " + fileName);
                Console.ResetColor();
            }

            using (Stream f = File.Open(fileName, FileMode.Open))
            {
                return ParseAvroFile(f);
            }
        }
        public static List<EventHubAvroData> ParseAvroFile(Stream inStream)
        {
           
            List<EventHubAvroData> items = new List<EventHubAvroData>();

            using (var reader = Avro.File.DataFileReader<object>.OpenReader(inStream))
            {
                foreach (Avro.Generic.GenericRecord m in reader.NextEntries)
                {
                    EventHubAvroData e = new EventHubAvroData(m);
                    items.Add(e);
                }
            }

            return items;
        }
    }
}
