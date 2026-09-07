using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

/* To run this application, make sure the following environment variables are set:
 * AWS_ACCESS_KEY_ID
 * AWS_SECRET_ACCESS_KEY
 * AWS_SESSION_TOKEN
 * AWS_REGION (set to "us-east-1")
 */

// connect the region where the DynamoDB table exists
const string tableName = "TrainingTable";
AmazonDynamoDBClient client = new(RegionEndpoint.USEast1);
string id = Guid.NewGuid().ToString();

/*
// start to access the table
Console.WriteLine($"Writing item {id}...");
await client.PutItemAsync(new PutItemRequest()
{
    TableName = tableName,
    Item = new Dictionary<string, AttributeValue>
    {
        ["id"] = new AttributeValue { S = id },
        ["message"] = new AttributeValue { S = "Hello from C#!" },
        ["created"] = new AttributeValue { S = DateTime.UtcNow.ToString("O") }
    }
});
Console.WriteLine("Item written.");

// start to read the item back
Console.WriteLine("Reading it back...");
GetItemResponse response = await client.GetItemAsync(new GetItemRequest
{
    TableName = tableName,
    Key = new Dictionary<string, AttributeValue>
    {
        ["id"] = new AttributeValue { S = id }
    }
});

if (response.Item.Count == 0)
{
    Console.WriteLine("Item not found.");
}
else
{
    Console.WriteLine("Item found:");

    foreach (var pair in response.Item)
    {
        Console.WriteLine($"{pair.Key} = {pair.Value.S}");
    }
}

// update item, set a new property
Console.WriteLine("Updating item...");
await client.UpdateItemAsync(new UpdateItemRequest
{
    TableName = tableName,
    Key = new Dictionary<string, AttributeValue>
    {
        ["id"] = new AttributeValue { S = id }
    },
    UpdateExpression = "SET #msg = :newMessage",
    ExpressionAttributeNames = new Dictionary<string, string>
    {
        ["#msg"] = "message"
    },
    ExpressionAttributeValues = new Dictionary<string, AttributeValue>
    {
        [":newMessage"] = new AttributeValue { S = "Hello from C# (updated)!" }
    }
});

// deletion
await client.DeleteItemAsync(new DeleteItemRequest
{
    TableName = tableName,
    Key = new Dictionary<string, AttributeValue>
    {
        ["id"] = new AttributeValue { S = id }
    }
});
Console.WriteLine("Item deleted.");
*/

// scan the table
Console.WriteLine("Scanning the table...");
ScanResponse scanResponse = await client.ScanAsync(new ScanRequest
{
    TableName = tableName
});

if (scanResponse.Items.Count == 0)
{
    Console.WriteLine("No items found.");
}
else
{
    Console.WriteLine($"Found {scanResponse.Items.Count} items:");
    foreach (var item in scanResponse.Items)
    {
        Console.WriteLine(string.Join(", ", item.Select(kv => $"{kv.Key} = {kv.Value.S}")));
    }
}
