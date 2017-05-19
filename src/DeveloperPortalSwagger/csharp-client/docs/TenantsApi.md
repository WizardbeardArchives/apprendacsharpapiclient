# IO.Swagger.Api.TenantsApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**TenantsGet**](TenantsApi.md#tenantsget) | **GET** /api/v1/Tenants | 
[**TenantsGetByIdentifier**](TenantsApi.md#tenantsgetbyidentifier) | **GET** /api/v1/Tenants/{alias}/{subAlias}/{identifier} | 
[**TenantsGetBySubAlias**](TenantsApi.md#tenantsgetbysubalias) | **GET** /api/v1/Tenants/{alias}/{subAlias} | 


<a name="tenantsget"></a>
# **TenantsGet**
> PagedResourceBaseSubscribedTenant TenantsGet (string alias, string subAlias, int? page, int? pageSize)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class TenantsGetExample
    {
        public void main()
        {
            
            var apiInstance = new TenantsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var page = 56;  // int? | 
            var pageSize = 56;  // int? | 

            try
            {
                PagedResourceBaseSubscribedTenant result = apiInstance.TenantsGet(alias, subAlias, page, pageSize);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TenantsApi.TenantsGet: " + e.Message );
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
 **page** | **int?**|  | 
 **pageSize** | **int?**|  | 

### Return type

[**PagedResourceBaseSubscribedTenant**](PagedResourceBaseSubscribedTenant.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="tenantsgetbyidentifier"></a>
# **TenantsGetByIdentifier**
> PagedResourceBaseSubscribedUser TenantsGetByIdentifier (string alias, string subAlias, string identifier, int? page, int? pageSize)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class TenantsGetByIdentifierExample
    {
        public void main()
        {
            
            var apiInstance = new TenantsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var page = 56;  // int? | 
            var pageSize = 56;  // int? | 

            try
            {
                PagedResourceBaseSubscribedUser result = apiInstance.TenantsGetByIdentifier(alias, subAlias, identifier, page, pageSize);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TenantsApi.TenantsGetByIdentifier: " + e.Message );
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
 **identifier** | **string**|  | 
 **page** | **int?**|  | 
 **pageSize** | **int?**|  | 

### Return type

[**PagedResourceBaseSubscribedUser**](PagedResourceBaseSubscribedUser.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="tenantsgetbysubalias"></a>
# **TenantsGetBySubAlias**
> PagedResourceBaseSubscribedTenant TenantsGetBySubAlias (string alias, string subAlias, int? page, int? pageSize)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class TenantsGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new TenantsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var page = 56;  // int? | 
            var pageSize = 56;  // int? | 

            try
            {
                PagedResourceBaseSubscribedTenant result = apiInstance.TenantsGetBySubAlias(alias, subAlias, page, pageSize);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TenantsApi.TenantsGetBySubAlias: " + e.Message );
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
 **page** | **int?**|  | 
 **pageSize** | **int?**|  | 

### Return type

[**PagedResourceBaseSubscribedTenant**](PagedResourceBaseSubscribedTenant.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

