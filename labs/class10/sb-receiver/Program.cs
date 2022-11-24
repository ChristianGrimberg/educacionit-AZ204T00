using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

const string connectionString = "<ServiceBus Connection String>";
const string queueName = "messagequeue";

ServiceBusClient client = new ServiceBusClient(connectionString);
ServiceBusProcessor processor = client.CreateProcessor(queueName);

processor.ProcessMessageAsync += async(ProcessMessageEventArgs args) => {
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Recibi: {body}");
    await args.CompleteMessageAsync(args.Message);
};

processor.ProcessErrorAsync += async (ProcessErrorEventArgs args) => {
    Console.WriteLine(args.Exception.ToString());
    await Task.CompletedTask;
};

await processor.StartProcessingAsync();

Console.WriteLine("Recibiendo mensajes. Presione Enter para continuar...");
Console.ReadLine();
Console.WriteLine("Terminando...");

await processor.StopProcessingAsync();