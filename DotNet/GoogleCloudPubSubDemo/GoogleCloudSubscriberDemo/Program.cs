using Google.Api.Gax;
using Google.Cloud.PubSub.V1;

Console.WriteLine("Starting the Subscriber application.");

string projectId = "training-project";
string subscriptionId = "orders-subscription";

SubscriberClient subscriber = await new SubscriberClientBuilder()
{
    SubscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId),
    EmulatorDetection = EmulatorDetection.EmulatorOrProduction
}.BuildAsync();

Console.WriteLine("Listening for messages on the subscription...");
await subscriber.StartAsync(async (PubsubMessage message, CancellationToken cancellationToken) =>
{
    Console.WriteLine($"Received message: {message.Data.ToStringUtf8()}");
    return await Task.FromResult(SubscriberClient.Reply.Ack);
});
