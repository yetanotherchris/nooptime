Write-Host "Restoring nuget packages"
dotnet restore
Write-Host "Building packages"
dotnet build
$websitewwwRootDir = Resolve-Path ".\src\Nooptime.Web\wwwroot"

Set-Location $websitewwwRootDir

Write-Host "restoring npm packages"
npm install

Write-Host "Running npm build..."
npm run build

Write-Host "Build done!"

