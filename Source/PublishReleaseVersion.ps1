#declaring & setting some variables
$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
$publishPath = $scriptPath+"\_PublishTemp_\"

#Checking destination folder first
if (($env:dcsfpReleaseDestinationFolderPath -eq $null) -or (-not (Test-Path $env:dcsfpReleaseDestinationFolderPath))){
	Write-Host "Destination folder does not exists. Please set environment variable 'dcsfpReleaseDestinationFolderPath' to a valid value" -foregroundcolor "Red"
	exit
}

Write-Host "Building release version " -foregroundcolor "Green"

dotnet publish DCSFlightpanels\DCSFlightpanels.csproj --self-contained false -f net6.0-windows -r win-x64 -c Release -o $publishPath /p:DebugType=None /p:DebugSymbols=false
$buildLastExitCode = $LastExitCode

Write-Host "Build LastExitCode: $buildLastExitCode" -foregroundcolor "Green"

if ( 0 -ne $buildLastExitCode )
{
  Write-Host "Build seems to have failed. No Zip & copy will be done." -foregroundcolor "Red"
  exit
}

#Getting file info & remove revision from file_version
Write-Host "Getting file info" -foregroundcolor "Green"
$file_version = (Get-Command $publishPath\dcsfp.exe).FileVersionInfo.FileVersion
$file_version = $file_version.Remove($file_version.LastIndexOf('.'))

#Delete eventual debug and error log before compression
#Add in the array any other files you want to remove from release version
$ArrayOfExtraFiles = 
@(
'DCSFlightpanels_debug_log.txt',
'DCSFlightpanels_error_log.txt'
)
foreach ($extraFile in $ArrayOfExtraFiles)
{  
	$fileToCheckAndDelete = $publishPath+$extraFile
	if (Test-Path $fileToCheckAndDelete){
		Write-Host "Deleting extra file:" $fileToCheckAndDelete -foregroundcolor "Green"
		Remove-Item $fileToCheckAndDelete
	}
}

#Compressing release folder to destination
Write-Host "Destination for zip file:" $env:dcsfpReleaseDestinationFolderPath"\DCSFlightpanels_x64_$file_version.zip" -foregroundcolor "Green"
Compress-Archive -Force -Path $publishPath\* -DestinationPath $env:dcsfpReleaseDestinationFolderPath"\DCSFlightpanels_x64_$file_version.zip"

Write-Host "Script end" -foregroundcolor "Green"