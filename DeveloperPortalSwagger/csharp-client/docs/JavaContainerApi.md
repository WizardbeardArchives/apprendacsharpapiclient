# IO.Swagger.Api.JavaContainerApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**JavaContainerGet**](JavaContainerApi.md#javacontainerget) | **GET** /api/v1/JavaContainer | 
[**JavaContainerGetBySubAlias**](JavaContainerApi.md#javacontainergetbysubalias) | **GET** /api/v1/JavaContainer/{alias}/{subAlias} | 


<a name="javacontainerget"></a>
# **JavaContainerGet**
> List<JavaContainerDTO> JavaContainerGet ()



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class JavaContainerGetExample
    {
        public void main()
        {
            
            var apiInstance = new JavaContainerApi();

            try
            {
                List&lt;JavaContainerDTO&gt; result = apiInstance.JavaContainerGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JavaContainerApi.JavaContainerGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<JavaContainerDTO>**](JavaContainerDTO.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="javacontainergetbysubalias"></a>
# **JavaContainerGetBySubAlias**
> List<JavaContainerDTO> JavaContainerGetBySubAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class JavaContainerGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new JavaContainerApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;JavaContainerDTO&gt; result = apiInstance.JavaContainerGetBySubAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling JavaContainerApi.JavaContainerGetBySubAlias: " + e.Message );
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

[**List<JavaContainerDTO>**](JavaContainerDTO.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

