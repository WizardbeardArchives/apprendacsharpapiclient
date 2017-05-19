# IO.Swagger.Api.QuotasApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**QuotasGet**](QuotasApi.md#quotasget) | **GET** /api/v1/Quotas | 
[**QuotasGetById**](QuotasApi.md#quotasgetbyid) | **GET** /api/v1/Quotas/{id} | 
[**QuotasGetBySubAlias**](QuotasApi.md#quotasgetbysubalias) | **GET** /api/v1/Quotas/{alias}/{subAlias} | 


<a name="quotasget"></a>
# **QuotasGet**
> List<StorageQuota> QuotasGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class QuotasGetExample
    {
        public void main()
        {
            
            var apiInstance = new QuotasApi();

            try
            {
                List&lt;StorageQuota&gt; result = apiInstance.QuotasGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling QuotasApi.QuotasGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<StorageQuota>**](StorageQuota.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="quotasgetbyid"></a>
# **QuotasGetById**
> EnrichedStorageQuota QuotasGetById (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class QuotasGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new QuotasApi();
            var id = 56;  // int? | 

            try
            {
                EnrichedStorageQuota result = apiInstance.QuotasGetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling QuotasApi.QuotasGetById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

[**EnrichedStorageQuota**](EnrichedStorageQuota.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="quotasgetbysubalias"></a>
# **QuotasGetBySubAlias**
> List<StorageQuota> QuotasGetBySubAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class QuotasGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new QuotasApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;StorageQuota&gt; result = apiInstance.QuotasGetBySubAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling QuotasApi.QuotasGetBySubAlias: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **alias** | **string**|  | 
 **subAlias** | **string**|  | 

### Return type

[**List<StorageQuota>**](StorageQuota.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

