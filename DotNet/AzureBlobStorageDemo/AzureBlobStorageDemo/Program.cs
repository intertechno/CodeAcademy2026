using Azure.Storage.Blobs;

const string connectionString = "DefaultEndpointsProtocol=https;AccountName=saranencodeacademy;AccountKey=xxxx;EndpointSuffix=core.windows.net;";
const string containerName = "jani";

var blobServiceClient = new BlobServiceClient(connectionString);
var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

// Make sure the container exists.
// Remove this line if the container is guaranteed to already exist.
await containerClient.CreateIfNotExistsAsync();

Console.WriteLine($"Using container: {containerClient.Name}");

// ---------------------------------------------------------
// Upload a blob
// ---------------------------------------------------------

string localFileToUpload = @"C:\Academy\Code2026\Numbers.txt";
string blobName = "Numbers.txt";

BlobClient blobClient = containerClient.GetBlobClient(blobName);

Console.WriteLine($"Uploading {localFileToUpload} -> {blobName}");
await blobClient.UploadAsync(localFileToUpload, overwrite: true);
Console.WriteLine("Upload completed.");

// ---------------------------------------------------------
// Download the same blob
// ---------------------------------------------------------

string localDownloadPath = @"C:\Temp\example-downloaded.txt";

Console.WriteLine($"Downloading {blobName} -> {localDownloadPath}");
await blobClient.DownloadToAsync(localDownloadPath);
Console.WriteLine("Download completed.");
