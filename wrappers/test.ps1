Set-StrictMode -Version latest

Import-Module –Name ./apprendaapitclient_powershell.psm1

$pwd = "password"
$client = Get-APIClient -baseUri "https://apps.apprenda.msterling10" -userName "gsterling@apprenda.com" -password $pwd

Write-Host "complete test"
