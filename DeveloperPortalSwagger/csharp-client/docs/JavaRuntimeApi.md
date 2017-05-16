# IO.Swagger.Api.JavaRuntimeApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**JavaRuntimeGet**](JavaRuntimeApi.md#javaruntimeget) | **GET** /api/v1/JavaRuntime | 
[**JavaRuntimeGetBySubAlias**](JavaRuntimeApi.md#javaruntimegetbysubalias) | **GET** /api/v1/JavaRuntime/{alias}/{subAlias} | 


<a name="javaruntimeget"></a>
# **JavaRuntimeGet**
> List<JavaRuntimeReturn> JavaRuntimeGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class JavaRuntimeGetExample
    {
        public void main()
        {
            
            var apiInstance = new JavaRuntimeApi();

            try
            {
                List&lt;JavaRuntimeReturn&gt; result = apiInstance.JavaRuntimeGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JavaRuntimeApi.JavaRuntimeGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<JavaRuntimeReturn>**](JavaRuntimeReturn.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="javaruntimegetbysubalias"></a>
# **JavaRuntimeGetBySubAlias**
> List<JavaRuntimeReturn> JavaRuntimeGetBySubAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class JavaRuntimeGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new JavaRuntimeApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;JavaRuntimeReturn&gt; result = apiInstance.JavaRuntimeGetBySubAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JavaRuntimeApi.JavaRuntimeGetBySubAlias: " + e.Message );
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

[**List<JavaRuntimeReturn>**](JavaRuntimeReturn.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

