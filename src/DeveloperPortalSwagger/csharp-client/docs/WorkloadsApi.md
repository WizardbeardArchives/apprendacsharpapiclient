# IO.Swagger.Api.WorkloadsApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**WorkloadsGet**](WorkloadsApi.md#workloadsget) | **GET** /api/v1/Workloads | 
[**WorkloadsGetById**](WorkloadsApi.md#workloadsgetbyid) | **GET** /api/v1/Workloads/{id} | 
[**WorkloadsGetByIdentifier**](WorkloadsApi.md#workloadsgetbyidentifier) | **GET** /api/v1/Workloads/{alias}/{subAlias}/{identifier} | 
[**WorkloadsGetBySubAlias**](WorkloadsApi.md#workloadsgetbysubalias) | **GET** /api/v1/Workloads/{alias}/{subAlias} | 
[**WorkloadsPost**](WorkloadsApi.md#workloadspost) | **POST** /api/v1/Workloads/{alias}/{subAlias} | 
[**WorkloadsPostById**](WorkloadsApi.md#workloadspostbyid) | **POST** /api/v1/Workloads/{id} | 


<a name="workloadsget"></a>
# **WorkloadsGet**
> List<Workload> WorkloadsGet (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class WorkloadsGetExample
    {
        public void main()
        {
            
            var apiInstance = new WorkloadsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;Workload&gt; result = apiInstance.WorkloadsGet(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkloadsApi.WorkloadsGet: " + e.Message );
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

[**List<Workload>**](Workload.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workloadsgetbyid"></a>
# **WorkloadsGetById**
> Workload WorkloadsGetById (int? id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class WorkloadsGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new WorkloadsApi();
            var id = 56;  // int? | 

            try
            {
                Workload result = apiInstance.WorkloadsGetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkloadsApi.WorkloadsGetById: " + e.Message );
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

[**Workload**](Workload.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workloadsgetbyidentifier"></a>
# **WorkloadsGetByIdentifier**
> List<Workload> WorkloadsGetByIdentifier (string alias, string subAlias, string identifier)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class WorkloadsGetByIdentifierExample
    {
        public void main()
        {
            
            var apiInstance = new WorkloadsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 

            try
            {
                List&lt;Workload&gt; result = apiInstance.WorkloadsGetByIdentifier(alias, subAlias, identifier);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkloadsApi.WorkloadsGetByIdentifier: " + e.Message );
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

### Return type

[**List<Workload>**](Workload.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workloadsgetbysubalias"></a>
# **WorkloadsGetBySubAlias**
> List<Workload> WorkloadsGetBySubAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class WorkloadsGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new WorkloadsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;Workload&gt; result = apiInstance.WorkloadsGetBySubAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkloadsApi.WorkloadsGetBySubAlias: " + e.Message );
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

[**List<Workload>**](Workload.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workloadspost"></a>
# **WorkloadsPost**
> void WorkloadsPost (int? id, string alias, string subAlias, string action = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class WorkloadsPostExample
    {
        public void main()
        {
            
            var apiInstance = new WorkloadsApi();
            var id = 56;  // int? | 
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var action = action_example;  // string |  (optional) 

            try
            {
                apiInstance.WorkloadsPost(id, alias, subAlias, action);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkloadsApi.WorkloadsPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **alias** | **string**|  | 
 **subAlias** | **string**|  | 
 **action** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workloadspostbyid"></a>
# **WorkloadsPostById**
> void WorkloadsPostById (int? id, string action = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class WorkloadsPostByIdExample
    {
        public void main()
        {
            
            var apiInstance = new WorkloadsApi();
            var id = 56;  // int? | 
            var action = action_example;  // string |  (optional) 

            try
            {
                apiInstance.WorkloadsPostById(id, action);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkloadsApi.WorkloadsPostById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **action** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

