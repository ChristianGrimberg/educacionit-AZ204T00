using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Consumer;
using System;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

const string connectionStringEventHub = "<EventHub Connection String>";
const string hubName = "hub4chris";
const string connectionStringStorageAccount = "DefaultEndpointsProtocol=https;AccountName=storageaccount4eventhubs;AccountKey=A7nX9QZL96a0Iekr/YJdexMcbgvswc26wb0MS3wZoU+O2+iJ2Q6p4KRrhkor3U/4+y87+Opex2kO+AStNZxMKA==;EndpointSuffix=core.windows.net";
const string container = "hubcontainer";

BlobContainerClient blobClient = new BlobContainerClient(connectionStringStorageAccount, container);

EventProcessorClient client = new EventProcessorClient(
    EventHubConsumerClient.DefaultConsumerGroupName,
    connectionStringEventHub,
    hubName
);

client.ProcessEventAsync += async (ProcessEventArgs args) => {
    Console.WriteLine(args.Data.EventBody.ToString());
    await args.UpdateCheckpointAsync(args.CancellationToken);
};

client.ProcessErrorAsync += async (ProcessEventArgs args) => {
    Console.WriteLine("Algo salio mal al recibir el evento.");
    await Task.CompletedTask;
};

await client.StartPorcessAsync();

Console.WriteLine("Procesando eventos. Enter para terminar...");
Console.ReadLine();