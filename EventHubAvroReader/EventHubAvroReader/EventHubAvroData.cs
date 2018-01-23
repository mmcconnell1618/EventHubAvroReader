using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubAvroReader
{
    public class EventHubAvroData
    {
        public DateTime EnqueuedTimeUtc { get; set; }
        public long SequenceNumber { get; set; }
        public string Offset { get; set; }
        public byte[] Body { get; set; }

        public EventHubAvroData()
        {

        }

        public EventHubAvroData(Avro.Generic.GenericRecord record)
        {
            this.SequenceNumber = Parse<long>("SequenceNumber", record);
            this.Offset = Parse<string>("Offset", record);
            string dateString = Parse<string>("EnqueuedTimeUtc", record);

            DateTime enq;
            if (DateTime.TryParse(dateString, out enq) == true)
            {
                EnqueuedTimeUtc = enq;
            }

            this.Body = Parse<byte[]>("Body", record);

        }

        private T Parse<T>(string fieldName, Avro.Generic.GenericRecord record)
        {
            try
            {
                object data;
                record.TryGetValue(fieldName, out data);
                return (T)data;
            }
            catch
            {
                return default(T);
            }

        }

        public string BodyAsString
        {
            get
            {
                string result = "";

                try
                {
                    result = Encoding.UTF8.GetString(this.Body);
                }
                catch
                {
                    result = "Error Decoding!";
                }

                return result;
            }
        }
    }
}
