Set-StrictMode -Version latest
#Requires -Version 4.0

#load our dll so types are available!
$sourceCode = @"
    public class LoginInfo : ApprendaAPIClient.IUserLogin
    {
         public string UserName{get;set;}
         public string Password { get; set; }
    }

    public class ConnectionInfo : ApprendaAPIClient.IConnectionSettings{
        public string AppsUrl { get; set;}
        public ApprendaAPIClient.IUserLogin UserLogin {get;set;}
    }

    public class StupidFactory : ApprendaAPIClient.Factories.IConnectionSettingsFactory{
        private ApprendaAPIClient.IConnectionSettings _settings;

        public StupidFactory(ApprendaAPIClient.IConnectionSettings source){
            _settings = source;
        }
        public ApprendaAPIClient.IConnectionSettings GetConnectionSettings(){
            return _settings;
        }
    }

    public class ConsoleLogger : ApprendaAPIClient.Services.ITelemetryReportingService{
        public System.Threading.Tasks.Task ReportInfo(string message, System.Collections.Generic.IEnumerable<string> tags){
            Console.WriteLine(message);
        }
    }
"@    # this here-string terminator needs to be at column zero

#add Task defintions

$assemblyPath = 'ApprendaAPIClient.dll'
Add-Type -LiteralPath $assemblyPath
Add-Type -TypeDefinition $sourceCode -Language CSharp -ReferencedAssemblies $assemblyPath

#require the url, username, password, and file or console logging (latter default)

#create object to pass conneciton info
$loginInfo = New-Object LoginInfo
$loginInfo.UserName = "gsterling@apprenda.com"
$loginInfo.Password = "password"

$connectionInfo = New-Object ConnectionInfo
$connectionInfo.UserLogin = $loginInfo
$connectionInfo.AppsUrl = "https://apps.apprenda.msterling10"

#create logger to give to API client, and display info in the powershell console

#create the factory
$connectionInfoFactory = New-Object StupidFactory($connectionInfo)

$newCon = $connectionInfoFactory.GetConnectionSettings();

Write-Host $newCon.UserLogin.UserName;

$logger = New-Object ConsoleLogger

#make object (wrapper) that implements all our interfaces to ensure that we support all items, facade for the internal object returned from 
#the factory
$factory = New-Object ApprendaAPIClient.Factories.ApprendaApiClientFactory($connectionInfo.AppsUrl, 
    $connectionInfo.UserLogin.UserName, $connectionInfo.UserLogin.Password)

$client = $factory.GetV1Client($logger)


return $client

#call factory to create real object from factory


