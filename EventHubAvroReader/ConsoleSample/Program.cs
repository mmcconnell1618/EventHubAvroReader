using System;
using System.Collections.Generic;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string fileName = args[0];
                List<EventHubAvroReader.EventHubAvroData> items = new List<EventHubAvroReader.EventHubAvroData>();

                if (fileName.StartsWith("http"))
                {
                    items = EventHubAvroReader.AvroParser.ParseDataFromCloudStorage(fileName);
                }
                else
                {
                    items = EventHubAvroReader.AvroParser.ParseAvroFile(fileName);
                }

                Console.WriteLine("Parsed {0} items", items.Count);
                foreach(var item in items)
                {
                    Console.WriteLine("Enqueued Time: " + item.EnqueuedTimeUtc.ToLongDateString());
                }
            }
            else
            {
                Console.WriteLine("Missing input file name!");
            }

            //Console.ReadKey();
        }
    }
}
