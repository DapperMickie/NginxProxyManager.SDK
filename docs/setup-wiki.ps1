# PowerShell script to help set up GitHub Wiki for NginxProxyManager.SDK
# This script will create a guide for setting up the GitHub Wiki

# Configuration
$repoOwner = "YOUR_GITHUB_USERNAME"  # Replace with your GitHub username
$repoName = "NginxProxyManagerSdk"   # Replace with your repository name
$docsPath = "docs"                   # Path to documentation files

# Create a temporary directory for the wiki
$tempDir = "temp-wiki"
if (Test-Path $tempDir) {
    Remove-Item -Recurse -Force $tempDir
}
New-Item -ItemType Directory -Path $tempDir | Out-Null

# Clone the wiki repository
Write-Host "Cloning the wiki repository..."
git clone "https://github.com/$repoOwner/$repoName.wiki.git" $tempDir

# Copy the home page
Write-Host "Creating the home page..."
Copy-Item "$docsPath/home.md" "$tempDir/Home.md"

# Copy all service documentation files
Write-Host "Copying service documentation..."
Get-ChildItem -Path $docsPath -Filter "*-service.md" | ForEach-Object {
    $fileName = $_.Name
    $serviceName = $fileName -replace "-service.md", ""
    $wikiFileName = "$serviceName-Service.md"
    
    Write-Host "Copying $fileName to $wikiFileName..."
    Copy-Item $_.FullName "$tempDir/$wikiFileName"
}

# Create a _Sidebar.md file
Write-Host "Creating sidebar..."
$sidebarContent = @"
# NginxProxyManager.SDK Wiki

* [Home](Home)
* [Proxy Service](Proxy-Service)
* [Certificate Service](Certificate-Service)
* [Dead Host Service](Dead-Host-Service)
* [Audit Log Service](Audit-Log-Service)
* [Server Error Service](Server-Error-Service)
* [Report Service](Report-Service)
"@

Set-Content -Path "$tempDir/_Sidebar.md" -Value $sidebarContent

# Create a _Footer.md file
Write-Host "Creating footer..."
$footerContent = @"
---
© 2023 NginxProxyManager.SDK
"@

Set-Content -Path "$tempDir/_Footer.md" -Value $footerContent

# Instructions for pushing to GitHub
Write-Host "`nWiki files have been prepared in the '$tempDir' directory."
Write-Host "To push these files to GitHub:"
Write-Host "1. cd $tempDir"
Write-Host "2. git add ."
Write-Host "3. git commit -m 'Initial wiki setup'"
Write-Host "4. git push origin master"
Write-Host "`nNote: You may need to authenticate with GitHub when pushing." 