# IO.Swagger.Api.UtilizationApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**UtilizationGet**](UtilizationApi.md#utilizationget) | **GET** /api/v1/Utilization/{id} | 
[**UtilizationGetSubAlias**](UtilizationApi.md#utilizationgetsubalias) | **GET** /api/v1/Utilization/{alias}/{subAlias} | 


<a name="utilizationget"></a>
# **UtilizationGet**
> UtilizationAggregate UtilizationGet (int? id, DateTime? startTime, DateTime? endTime)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UtilizationGetExample
    {
        public void main()
        {
            
            var apiInstance = new UtilizationApi();
            var id = 56;  // int? | 
            var startTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 
            var endTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 

            try
            {
                UtilizationAggregate result = apiInstance.UtilizationGet(id, startTime, endTime);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UtilizationApi.UtilizationGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **startTime** | **DateTime?**|  | 
 **endTime** | **DateTime?**|  | 

### Return type

[**UtilizationAggregate**](UtilizationAggregate.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="utilizationgetsubalias"></a>
# **UtilizationGetSubAlias**
> UtilizationAggregate UtilizationGetSubAlias (int? id, DateTime? startTime, DateTime? endTime, string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UtilizationGetSubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new UtilizationApi();
            var id = 56;  // int? | 
            var startTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 
            var endTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                UtilizationAggregate result = apiInstance.UtilizationGetSubAlias(id, startTime, endTime, alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UtilizationApi.UtilizationGetSubAlias: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 
 **startTime** | **DateTime?**|  | 
 **endTime** | **DateTime?**|  | 
 **alias** | **string**|  | 
 **subAlias** | **string**|  | 

### Return type

[**UtilizationAggregate**](UtilizationAggregate.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

