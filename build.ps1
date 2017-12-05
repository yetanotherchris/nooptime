Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'));

choco install nodejs

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
