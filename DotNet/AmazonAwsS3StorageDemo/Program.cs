using Amazon.S3;
using Amazon.S3.Model;

string bucketName = "saranen-training-s3";
string student = "instructor";
string key = $"{student}/hello3.txt";

using AmazonS3Client s3 = new();
Console.WriteLine($"Bucket: {bucketName}");
Console.WriteLine($"Object: {key}");

//
// 1. Upload
//
string content = $"""
    Hello from {student}!
    Uploaded at {DateTimeOffset.UtcNow:u}
    """;

await s3.PutObjectAsync(new PutObjectRequest()
{
    BucketName = bucketName,
    Key = key,
    ContentBody = content,
    ContentType = "text/plain"
});
Console.WriteLine("Upload successful.");

//
// 2. List objects
//
Console.WriteLine();
Console.WriteLine("Objects:");
ListObjectsV2Response listResponse = await s3.ListObjectsV2Async(new ListObjectsV2Request()
{
    BucketName = bucketName
});
foreach (S3Object? obj in listResponse.S3Objects)
{
    Console.WriteLine($"  {obj.Key} ({obj.Size} bytes)");
}

//
// 3. Download our object
//
GetObjectResponse getResponse = await s3.GetObjectAsync(new GetObjectRequest()
{
    BucketName = bucketName,
    Key = key
});
using StreamReader reader = new(getResponse.ResponseStream);
string downloadedContent = await reader.ReadToEndAsync();

Console.WriteLine();
Console.WriteLine("Downloaded content:");
Console.WriteLine(downloadedContent);
