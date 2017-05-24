# IO.Swagger.Api.PlansApi

All URIs are relative to *https://apps.apprenda.harp/account*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiV1ApplicationVersionsApplicationVersionKeyPlansGet**](PlansApi.md#apiv1applicationversionsapplicationversionkeyplansget) | **GET** /api/v1/applicationVersions/{applicationVersionKey}/plans | Get all plans for an application version
[**ApiV1ApplicationVersionsApplicationVersionKeyPlansPlanIdGet**](PlansApi.md#apiv1applicationversionsapplicationversionkeyplansplanidget) | **GET** /api/v1/applicationVersions/{applicationVersionKey}/plans/{planId} | Get a plan for an application version


<a name="apiv1applicationversionsapplicationversionkeyplansget"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeyPlansGet**
> List<UnpagedResourceBasePlan> ApiV1ApplicationVersionsApplicationVersionKeyPlansGet (string applicationVersionKey)

Get all plans for an application version

Returns all plans for an given application version.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeyPlansGetExample
    {
        public void main()
        {
            
            var apiInstance = new PlansApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'

            try
            {
                // Get all plans for an application version
                List&lt;UnpagedResourceBasePlan&gt; result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeyPlansGet(applicationVersionKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlansApi.ApiV1ApplicationVersionsApplicationVersionKeyPlansGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 

### Return type

[**List<UnpagedResourceBasePlan>**](UnpagedResourceBasePlan.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeyplansplanidget"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeyPlansPlanIdGet**
> Plan ApiV1ApplicationVersionsApplicationVersionKeyPlansPlanIdGet (string applicationVersionKey, string planId)

Get a plan for an application version

Returns a specific plan for the given application version and plan id.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeyPlansPlanIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new PlansApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var planId = planId_example;  // string | Required. Unique Platform assigned id of the plan

            try
            {
                // Get a plan for an application version
                Plan result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeyPlansPlanIdGet(applicationVersionKey, planId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlansApi.ApiV1ApplicationVersionsApplicationVersionKeyPlansPlanIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **planId** | **string**| Required. Unique Platform assigned id of the plan | 

### Return type

[**Plan**](Plan.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

