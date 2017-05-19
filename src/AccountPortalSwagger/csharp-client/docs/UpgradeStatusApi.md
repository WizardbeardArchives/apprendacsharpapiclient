# IO.Swagger.Api.UpgradeStatusApi

All URIs are relative to *https://apps.apprenda.harp/account*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiV1PlatformUpgradestatusGet**](UpgradeStatusApi.md#apiv1platformupgradestatusget) | **GET** /api/v1/platform/upgradestatus | Check if the Platform is upgrading


<a name="apiv1platformupgradestatusget"></a>
# **ApiV1PlatformUpgradestatusGet**
> UpgradeStatus ApiV1PlatformUpgradestatusGet ()

Check if the Platform is upgrading

Returns if the Platform is being upgraded or not. Certain actions are not available while your Platform is upgrading.   Read more on [Platform upgrades](/current/upgrade). 

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1PlatformUpgradestatusGetExample
    {
        public void main()
        {
            
            var apiInstance = new UpgradeStatusApi();

            try
            {
                // Check if the Platform is upgrading
                UpgradeStatus result = apiInstance.ApiV1PlatformUpgradestatusGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UpgradeStatusApi.ApiV1PlatformUpgradestatusGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**UpgradeStatus**](UpgradeStatus.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

