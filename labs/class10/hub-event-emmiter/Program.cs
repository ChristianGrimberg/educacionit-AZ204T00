using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;

const string connectionString = "<EventHub Connection String>";
const string hubName = "hub4chris";

EventHubProducerClient client = new EventHubProducerClient(connectionString, hubName);
EventDataBatch manyEvents = await client.CreateBatchAsync();

for (int i = 0; i < 1000; i++)
{
    manyEvents.TryAdd(new EventData($"Evento {i}"));
}

try
{
    await client.SendAsync(manyEvents);
    Console.WriteLine("Se enviaron muchos eventos");
}
finally
{
    await client.DisposeAsync();
}