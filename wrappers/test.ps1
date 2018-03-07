Import-Module –Name ./apprendaapitclient_powershell.psm1

$client = Get-APIClient("https://apps.apprenda.msterling10", "gsterling@apprenda.com", 'password')

Write-Host $client
