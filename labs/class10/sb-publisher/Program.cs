using System;
using Azure.Messaging.ServiceBus;

const string connectionString = "<ServiceBus Connection String>";
const string queueName = "messagequeue";
const int numOfMessages = 30;

ServiceBusClient client = new ServiceBusClient(connectionString);
ServiceBusSender sender = client.CreateSender(queueName);
ServiceBusMessageBatch manyMessages = await sender.CreateMessageBatchAsync();

for (int i = 0; i < numOfMessages; i++)
{
    manyMessages.TryAddMessage(new ServiceBusMessage($"Mensaje desde .NET nro {i}"));
}

try
{
    await sender.SendMessagesAsync(manyMessages);
    Console.WriteLine("Mensaje enviado");

}
finally
{
    await sender.DisposeAsync();
    await client.DisposeAsync();
}
