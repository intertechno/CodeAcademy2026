# Source and destination folders
$sourceFolder = "C:\Academy\Code2026\Integration\PowerShell\In"
$destinationFolder = "C:\Academy\Code2026\Integration\PowerShell\Out"

# Get current date in yyyy-MM-dd format
$currentDate = Get-Date -Format "yyyy-MM-dd"

# Create destination folder if it doesn't exist
if (-not (Test-Path $destinationFolder)) {
    New-Item -ItemType Directory -Path $destinationFolder | Out-Null
}

# Copy and rename XML files
Get-ChildItem -Path $sourceFolder -Filter "*.xml" | ForEach-Object {
    $newFileName = "{0}-{1}{2}" -f $_.BaseName, $currentDate, $_.Extension
    $destinationPath = Join-Path $destinationFolder $newFileName

    Copy-Item -Path $_.FullName -Destination $destinationPath -Force
}

Write-Host "XML files copied successfully."
