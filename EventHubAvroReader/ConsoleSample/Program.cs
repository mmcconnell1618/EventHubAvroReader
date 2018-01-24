using System;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string fileName = args[0];
                var items = EventHubAvroReader.AvroParser.ParseAvroFile(fileName);
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
