using Azure.Storage.Queues;

string storageAccountName = "saranencodeacademy";
string accessKey = "xx";
string queueName = "jani-queue";

string connectionString =
    $"DefaultEndpointsProtocol=https;" +
    $"AccountName={storageAccountName};" +
    $"AccountKey={accessKey};" +
    $"EndpointSuffix=core.windows.net";

QueueClient queueClient = new(connectionString, queueName);

// Send a message
await queueClient.SendMessageAsync("Hello from C#!");

Console.WriteLine("Message sent!");
