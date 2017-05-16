# IO.Swagger.Api.ContextApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ContextGet**](ContextApi.md#contextget) | **GET** /api/v1/Context | 
[**ContextGetBySubAlias**](ContextApi.md#contextgetbysubalias) | **GET** /api/v1/Context/{alias}/{subAlias} | 


<a name="contextget"></a>
# **ContextGet**
> Context ContextGet (string returnAddress = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ContextGetExample
    {
        public void main()
        {
            
            var apiInstance = new ContextApi();
            var returnAddress = returnAddress_example;  // string |  (optional) 

            try
            {
                Context result = apiInstance.ContextGet(returnAddress);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ContextApi.ContextGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **returnAddress** | **string**|  | [optional] 

### Return type

[**Context**](Context.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="contextgetbysubalias"></a>
# **ContextGetBySubAlias**
> Context ContextGetBySubAlias (string alias, string subAlias, string returnAddress = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ContextGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new ContextApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var returnAddress = returnAddress_example;  // string |  (optional) 

            try
            {
                Context result = apiInstance.ContextGetBySubAlias(alias, subAlias, returnAddress);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ContextApi.ContextGetBySubAlias: " + e.Message );
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
 **returnAddress** | **string**|  | [optional] 

### Return type

[**Context**](Context.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

