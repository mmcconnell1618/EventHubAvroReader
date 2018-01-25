# Event Hub Avro Reader
Simple utility to parse .avro files generated by Azure Event Hubs. There is a utility library that does the actual parsing of the file and a sample console application. The payload of the events is an array of bytes and there is a helper method to decode UTF8 strings from the payload. 

Please contribute improvements if you see opportunities. Locating the .avro files that actually have messages in a storage account (versus the 508b heartbeat files) is an area that I'd like to solve.



