using System.Text.Json;
using Azure.Messaging.ServiceBus;

const string ConnectionString = "Endpoint=sb://saranen-esb.servicebus.windows.net/;SharedAccessKeyName=TrainingPolicy;SharedAccessKey=x";
const string QueueName = "testijono-jani";

await using ServiceBusClient client = new(ConnectionString);

// -----------------------------------------------------------------
// SEND
// -----------------------------------------------------------------
ServiceBusSender? sender = client.CreateSender(QueueName);

DemoMessage data = new()
{
    Id = Guid.NewGuid(),
    Name = "Hello Azure Service Bus from C#!",
    Timestamp = DateTime.UtcNow
};

string json = JsonSerializer.Serialize(data);

ServiceBusMessage message = new(json)
{
    ContentType = "application/json"
};

Console.WriteLine("Sending message...");
await sender.SendMessageAsync(message);
Console.WriteLine("Message sent.");

// wait for Enter key to continue
Console.WriteLine("Press Enter to receive the message...");
Console.ReadLine();

// -----------------------------------------------------------------
// RECEIVE
// -----------------------------------------------------------------

ServiceBusReceiver? receiver = client.CreateReceiver(QueueName);

Console.WriteLine();
Console.WriteLine("Waiting for message...");

ServiceBusReceivedMessage? received =
    await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(10));

if (received == null)
{
    Console.WriteLine("No message received.");
    return;
}

Console.WriteLine();
Console.WriteLine("Raw JSON:");
Console.WriteLine(received.Body.ToString());

var receivedData =
    JsonSerializer.Deserialize<DemoMessage>(received.Body);

Console.WriteLine();
Console.WriteLine("Deserialized object:");
Console.WriteLine($"Id        : {receivedData?.Id}");
Console.WriteLine($"Name      : {receivedData?.Name}");
Console.WriteLine($"Timestamp : {receivedData?.Timestamp}");

// Remove the message from the queue
await receiver.CompleteMessageAsync(received);

Console.WriteLine();
Console.WriteLine("Message processing completed.");
