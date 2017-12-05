if ((Get-Command "npm" -ErrorAction SilentlyContinue) -eq $null) 
{ 
   Write-Host "Unable to find npm in your path. Install NodeJS first."
   exit 1
}

###############################################################################
# NPM build (for VueJS)
###############################################################################
$websitewwwRootDir = Resolve-Path ".\src\Nooptime.Web\wwwroot"
pushd $websitewwwRootDir

npm install
npm run build

popd

###############################################################################
# .NET Core build 
###############################################################################
$webDir = Resolve-Path ".\src\Nooptime.Web\"
pushd $webDir

dotnet restore
dotnet publish -c Release

###############################################################################
# Docker build
###############################################################################

docker build -t nooptime .

popd

echo "-------------------------------------------------------------------------"
echo "Finished!"
echo "-------------------------------------------------------------------------"
