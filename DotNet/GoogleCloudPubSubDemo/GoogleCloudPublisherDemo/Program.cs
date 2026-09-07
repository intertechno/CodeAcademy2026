using Google.Api.Gax;
using Google.Cloud.PubSub.V1;

Console.WriteLine("Starting the Publisher application.");

string projectId = "training-project";
string topicId = "orders-topic";
string subscriptionId = "orders-subscription";

// create name objects
TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);
SubscriptionName subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

// create the topic
PublisherServiceApiClient publisher = await new PublisherServiceApiClientBuilder()
{
    EmulatorDetection = EmulatorDetection.EmulatorOrProduction
}.BuildAsync();
try
{
    await publisher.CreateTopicAsync(topicName);
    Console.WriteLine($"Created topic: {topicName}");
}
catch (Grpc.Core.RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.AlreadyExists)
{
    Console.WriteLine($"Topic already exists: {topicName}");
}

// create the subscription
SubscriberServiceApiClient subscriberService = await new SubscriberServiceApiClientBuilder
{
    EmulatorDetection = EmulatorDetection.EmulatorOrProduction
}.BuildAsync();
try
{
    await subscriberService.CreateSubscriptionAsync(subscriptionName, topicName, pushConfig: null, ackDeadlineSeconds: 180);
    Console.WriteLine($"Created subscription: {subscriptionId}");
}
catch (Grpc.Core.RpcException ex) when (ex.StatusCode == Grpc.Core.StatusCode.AlreadyExists)
{
    Console.WriteLine($"Subscription already exists: {subscriptionId}");
}

// publish a message to the topic
Console.WriteLine("Publishing a message to the topic...");
await publisher.PublishAsync(topicName, [new PubsubMessage {
    Data = Google.Protobuf.ByteString.CopyFromUtf8("Hello, Pub/Sub! Version 2!") }]);

Console.WriteLine("Message published.");
