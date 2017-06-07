# IO.Swagger.Api.PlatformApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PlatformGetUpgradingStatus**](PlatformApi.md#platformgetupgradingstatus) | **GET** /api/v1/platform/upgradeStatus | 


<a name="platformgetupgradingstatus"></a>
# **PlatformGetUpgradingStatus**
> UpgradeStatus PlatformGetUpgradingStatus ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PlatformGetUpgradingStatusExample
    {
        public void main()
        {
            
            var apiInstance = new PlatformApi();

            try
            {
                UpgradeStatus result = apiInstance.PlatformGetUpgradingStatus();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlatformApi.PlatformGetUpgradingStatus: " + e.Message );
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
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

