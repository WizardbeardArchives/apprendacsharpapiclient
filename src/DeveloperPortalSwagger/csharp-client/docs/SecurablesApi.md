# IO.Swagger.Api.SecurablesApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SecurablesGet**](SecurablesApi.md#securablesget) | **GET** /api/v1/Securables | 
[**SecurablesGetById**](SecurablesApi.md#securablesgetbyid) | **GET** /api/v1/Securables/{id} | 
[**SecurablesGetBySubAlias**](SecurablesApi.md#securablesgetbysubalias) | **GET** /api/v1/Securables/{alias}/{subAlias} | 


<a name="securablesget"></a>
# **SecurablesGet**
> List<SecurableAccess> SecurablesGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SecurablesGetExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();

            try
            {
                List&lt;SecurableAccess&gt; result = apiInstance.SecurablesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.SecurablesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<SecurableAccess>**](SecurableAccess.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="securablesgetbyid"></a>
# **SecurablesGetById**
> SecurableAccess SecurablesGetById (string id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SecurablesGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();
            var id = id_example;  // string | 

            try
            {
                SecurableAccess result = apiInstance.SecurablesGetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.SecurablesGetById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**SecurableAccess**](SecurableAccess.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="securablesgetbysubalias"></a>
# **SecurablesGetBySubAlias**
> List<SecurableAccess> SecurablesGetBySubAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SecurablesGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;SecurableAccess&gt; result = apiInstance.SecurablesGetBySubAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.SecurablesGetBySubAlias: " + e.Message );
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

[**List<SecurableAccess>**](SecurableAccess.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

