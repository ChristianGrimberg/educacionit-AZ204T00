using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Threading.Tasks;
public class Program
{
    private const string blobServiceEndpoint = "https://stormediaclase04.blob.core.windows.net/";
    private const string storageAccountName = "stormediaclase04";
    private const string storageAccountKey = "bWkHbm1j/4LzpS2KaIxjx+af5q7cRbtDtMZJwv3jo9s+QR7bnUnBZ93US+8uo91oGfTBZfFKwpld+AStdHDOBQ==";

    public static async Task Main(string[] args)
    {
        StorageSharedKeyCredential accountCredentials = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);
        BlobServiceClient serviceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), accountCredentials);
        AccountInfo info = await serviceClient.GetAccountInfoAsync();

        await Console.Out.WriteLineAsync($"Connected to Azure Storage Account");
        await Console.Out.WriteLineAsync($"Account name:\t{storageAccountName}");
        await Console.Out.WriteLineAsync($"Account kind:\t{info?.AccountKind}");
        await Console.Out.WriteLineAsync($"Account sku:\t{info?.SkuName}");

        Console.WriteLine("List of containers:");
        foreach (BlobContainerItem item in serviceClient.GetBlobContainers())
        {
            Console.WriteLine($"Container={item.Name}");
            BlobContainerClient container = serviceClient.GetBlobContainerClient(item.Name);

            Console.WriteLine("Container content:");

            foreach (BlobItem blob in container.GetBlobs())
            {
                Console.WriteLine($"{blob.Name}");
            }
        }
    }
}