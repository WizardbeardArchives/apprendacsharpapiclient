# IO.Swagger.Api.ApplicationVersionsApi

All URIs are relative to *https://apps.apprenda.harp/account*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiV1ApplicationVersionsApplicationVersionKeyGet**](ApplicationVersionsApi.md#apiv1applicationversionsapplicationversionkeyget) | **GET** /api/v1/applicationVersions/{applicationVersionKey} | Get a version of an application
[**ApiV1ApplicationVersionsGet**](ApplicationVersionsApi.md#apiv1applicationversionsget) | **GET** /api/v1/applicationVersions | Get all applications


<a name="apiv1applicationversionsapplicationversionkeyget"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeyGet**
> ApplicationVersion ApiV1ApplicationVersionsApplicationVersionKeyGet (string applicationVersionKey)

Get a version of an application

Returns a single application version for the given application and version alias.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeyGetExample
    {
        public void main()
        {
            
            var apiInstance = new ApplicationVersionsApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'

            try
            {
                // Get a version of an application
                ApplicationVersion result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeyGet(applicationVersionKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationVersionsApi.ApiV1ApplicationVersionsApplicationVersionKeyGet: " + e.Message );
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

[**ApplicationVersion**](ApplicationVersion.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsget"></a>
# **ApiV1ApplicationVersionsGet**
> PagedResourceBaseApplicationVersion ApiV1ApplicationVersionsGet (string pageSize = null, string pageNumber = null, string sortBy = null, string sortOrder = null)

Get all applications

Returns a list of all applications, including different versions, for the Tenant.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsGetExample
    {
        public void main()
        {
            
            var apiInstance = new ApplicationVersionsApi();
            var pageSize = pageSize_example;  // string | Number of results to return in a single request. All results will be grouped into pages of this size. Default 20 (optional) 
            var pageNumber = pageNumber_example;  // string | The page of results to return. Defaults to the first page (optional) 
            var sortBy = sortBy_example;  // string |  (optional) 
            var sortOrder = sortOrder_example;  // string | Determines how results will be sorted. Allowed values: ascending, descending (optional) 

            try
            {
                // Get all applications
                PagedResourceBaseApplicationVersion result = apiInstance.ApiV1ApplicationVersionsGet(pageSize, pageNumber, sortBy, sortOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationVersionsApi.ApiV1ApplicationVersionsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **pageSize** | **string**| Number of results to return in a single request. All results will be grouped into pages of this size. Default 20 | [optional] 
 **pageNumber** | **string**| The page of results to return. Defaults to the first page | [optional] 
 **sortBy** | **string**|  | [optional] 
 **sortOrder** | **string**| Determines how results will be sorted. Allowed values: ascending, descending | [optional] 

### Return type

[**PagedResourceBaseApplicationVersion**](PagedResourceBaseApplicationVersion.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

