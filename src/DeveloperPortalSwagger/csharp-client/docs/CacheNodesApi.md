# IO.Swagger.Api.CacheNodesApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CacheNodesGet**](CacheNodesApi.md#cachenodesget) | **GET** /api/v1/CacheNodes/{id} | 
[**CacheNodesGetBySubAlias**](CacheNodesApi.md#cachenodesgetbysubalias) | **GET** /api/v1/CacheNodes/{alias}/{subAlias} | 


<a name="cachenodesget"></a>
# **CacheNodesGet**
> List<CacheNode> CacheNodesGet (string id)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CacheNodesGetExample
    {
        public void main()
        {
            
            var apiInstance = new CacheNodesApi();
            var id = id_example;  // string | 

            try
            {
                List&lt;CacheNode&gt; result = apiInstance.CacheNodesGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CacheNodesApi.CacheNodesGet: " + e.Message );
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

[**List<CacheNode>**](CacheNode.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="cachenodesgetbysubalias"></a>
# **CacheNodesGetBySubAlias**
> List<CacheNode> CacheNodesGetBySubAlias (string id, string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CacheNodesGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new CacheNodesApi();
            var id = id_example;  // string | 
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;CacheNode&gt; result = apiInstance.CacheNodesGetBySubAlias(id, alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CacheNodesApi.CacheNodesGetBySubAlias: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **alias** | **string**|  | 
 **subAlias** | **string**|  | 

### Return type

[**List<CacheNode>**](CacheNode.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

