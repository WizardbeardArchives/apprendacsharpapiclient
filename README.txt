# README #

 This is a full C# client for accessing the Apprenda platform, asyncronously.  It uses pregenerated Swagger projects to 
   get object definitions, or in cases where they don't exist it provides them.  

   In addition it also provides the ability for very detailed logging about test behavior, by injectiong a ITelemetryReportingService 
   to the client factory.  This allows a consumer to do things like sending timestamped proxy calls and tests to Splunk or Elk,
   for example.

   To use - instantiate the ApprendaApiClientFactory, and call GetV1Client.  This will give you a client that can talk to the platform
   specified in your ConnectionSettings.

   Optional injected services:
   ITelemetryReportingService - allows the calling assembly to provide a service which will give detailed messages about when a
   test, or proxy call, begins and ends.  Useful for creating timestamped data on how long things take, especially over many
   repetitions.

   IUserLoginRepository - allows the calling assembly to provide users and admin users to tests by whatever logic they want

   ISmokeTestApplicationRepository - allows the calling assembly to provide custom code for retrieving application archives for tests

   IConnectionSettingsFactory - allows the user to extend how we get our basic connection information (where Apprenda is, etc).  
   Useful if a test writer needs to use configuration files, or some other method rather than changing code.




### What is this repository for? ###

* Quick summary
* 0.1.1

### Currently supported entities

* DeveloperPortal
  * Applications
  * Versions
  * Promotion
  * Plans
  * Users, Groups, Subscriptions
     * Mutlitenant
     * AuthZ
  * Environment Variables
  * 
* SOC
  * (External User Store) Groups
  * Clouds
  * Custom Properties
  * Health Reports
  * Registry Settings

* Account

### Who do I talk to? ###

* gsterling@apprenda.com


