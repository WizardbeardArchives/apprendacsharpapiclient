# IO.Swagger.Api.RegistryApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**RegistryGet**](RegistryApi.md#registryget) | **GET** /api/v1/Registry | 
[**RegistryGetByAlias**](RegistryApi.md#registrygetbyalias) | **GET** /api/v1/Registry/{alias}/{subAlias} | 
[**RegistryGetById**](RegistryApi.md#registrygetbyid) | **GET** /api/v1/Registry/{id} | 


<a name="registryget"></a>
# **RegistryGet**
> List<RegistrySettingBase> RegistryGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegistryGetExample
    {
        public void main()
        {
            
            var apiInstance = new RegistryApi();

            try
            {
                List&lt;RegistrySettingBase&gt; result = apiInstance.RegistryGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RegistryApi.RegistryGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<RegistrySettingBase>**](RegistrySettingBase.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="registrygetbyalias"></a>
# **RegistryGetByAlias**
> List<RegistrySettingBase> RegistryGetByAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegistryGetByAliasExample
    {
        public void main()
        {
            
            var apiInstance = new RegistryApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;RegistrySettingBase&gt; result = apiInstance.RegistryGetByAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RegistryApi.RegistryGetByAlias: " + e.Message );
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

[**List<RegistrySettingBase>**](RegistrySettingBase.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="registrygetbyid"></a>
# **RegistryGetById**
> RegistrySettingBase RegistryGetById (string id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RegistryGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new RegistryApi();
            var id = id_example;  // string | 

            try
            {
                RegistrySettingBase result = apiInstance.RegistryGetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RegistryApi.RegistryGetById: " + e.Message );
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

[**RegistrySettingBase**](RegistrySettingBase.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

