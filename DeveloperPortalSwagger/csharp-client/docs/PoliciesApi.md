# IO.Swagger.Api.PoliciesApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PoliciesGet**](PoliciesApi.md#policiesget) | **GET** /api/v1/Policies | 
[**PoliciesGetById**](PoliciesApi.md#policiesgetbyid) | **GET** /api/v1/Policies/{id} | 
[**PoliciesGetBySubAlias**](PoliciesApi.md#policiesgetbysubalias) | **GET** /api/v1/Policies/{alias}/{subAlias} | 


<a name="policiesget"></a>
# **PoliciesGet**
> List<ResourceAllocationPolicy> PoliciesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PoliciesGetExample
    {
        public void main()
        {
            
            var apiInstance = new PoliciesApi();

            try
            {
                List&lt;ResourceAllocationPolicy&gt; result = apiInstance.PoliciesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PoliciesApi.PoliciesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<ResourceAllocationPolicy>**](ResourceAllocationPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="policiesgetbyid"></a>
# **PoliciesGetById**
> EnrichedResourceAllocationPolicy PoliciesGetById (Guid? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PoliciesGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new PoliciesApi();
            var id = id_example;  // Guid? | 

            try
            {
                EnrichedResourceAllocationPolicy result = apiInstance.PoliciesGetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PoliciesApi.PoliciesGetById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **Guid?**|  | 

### Return type

[**EnrichedResourceAllocationPolicy**](EnrichedResourceAllocationPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="policiesgetbysubalias"></a>
# **PoliciesGetBySubAlias**
> List<ResourceAllocationPolicy> PoliciesGetBySubAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PoliciesGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new PoliciesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;ResourceAllocationPolicy&gt; result = apiInstance.PoliciesGetBySubAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PoliciesApi.PoliciesGetBySubAlias: " + e.Message );
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

[**List<ResourceAllocationPolicy>**](ResourceAllocationPolicy.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

