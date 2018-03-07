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
"@    # this here-string terminator needs to be at column zero

$assemblyPath = 'ApprendaAPIClient.dll'
Add-Type -LiteralPath $assemblyPath
Add-Type -TypeDefinition $sourceCode -Language CSharp -ReferencedAssemblies $assemblyPath

function Get-APIClient{
    # Base URL of the apprenda cloud
    param(
    [string]
    $baseUri,
    [string]
    $userName,
    [securestring]
    $password,
    [string]$dllLocation = ".")
    {


        #require the url, username, password, and file or console logging (latter default)

        #create object to pass conneciton info
        $loginInfo = New-Object LoginInfo
        $loginInfo.UserName = "gsterling@apprenda.com"


        $connectionInfo = New-Object ConnectionInfo
        $connectionInfo.UserLogin = $loginInfo
        $connectionInfo.AppsUrl = "https://apprenda.msterling10"

        #create logger to give to API client, and display info in the powershell console

        #create the factory
        $connectionInfoFactory = New-Object StupidFactory($connectionInfo)

        $newCon = $connectionInfoFactory.GetConnectionSettings();

        Write-Host $newCon.UserLogin.UserName;
        #make object (wrapper) that implements all our interfaces to ensure that we support all items, facade for the internal object returned from 
        #the factory

        #call factory to create real object from factory

    
    }

}