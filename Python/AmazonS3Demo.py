import boto3
from datetime import datetime, timezone

bucket_name = "saranen-training-s3"
student = "instructor"
key = f"{student}/hello4.txt"

# Create S3 client
s3 = boto3.client("s3")

print(f"Bucket: {bucket_name}")
print(f"Object: {key}")

# 1. Upload
content = f"""Hello from {student}!

Uploaded at {datetime.now(timezone.utc).strftime("%Y-%m-%d %H:%M:%S UTC")}
"""

s3.put_object(
    Bucket=bucket_name,
    Key=key,
    Body=content,
    ContentType="text/plain"
)

print("Upload successful.")

# 2. List objects
print()
print("Objects:")

response = s3.list_objects_v2(
    Bucket=bucket_name
)

for obj in response.get("Contents", []):
    print(f"  {obj['Key']} ({obj['Size']} bytes)")

# 3. Download our object
response = s3.get_object(
    Bucket=bucket_name,
    Key=key
)

downloaded_content = response["Body"].read().decode("utf-8")

print()
print("Downloaded content:")
print(downloaded_content)
