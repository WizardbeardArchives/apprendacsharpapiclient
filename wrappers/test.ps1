#load the dll to get our types

try {
    Add-Type -Path '.\ApprendaAPIClient.dll'
}
catch {
   $message = $_.Exception.Message 
   Write-Host $message

   foreach($le in $_.Exception.LoaderExceptions){
       Write-Host $le.Message
   }
}