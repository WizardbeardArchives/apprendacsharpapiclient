# IO.Swagger.Api.LogSummaryApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**LogSummaryGet**](LogSummaryApi.md#logsummaryget) | **GET** /api/v1/LogSummary | 
[**LogSummaryGetById**](LogSummaryApi.md#logsummarygetbyid) | **GET** /api/v1/LogSummary/{id} | 
[**LogSummaryGetBySubAlias**](LogSummaryApi.md#logsummarygetbysubalias) | **GET** /api/v1/LogSummary/{alias}/{subAlias} | 


<a name="logsummaryget"></a>
# **LogSummaryGet**
> AggregateLogData LogSummaryGet (DateTime? startTime, DateTime? endTime = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LogSummaryGetExample
    {
        public void main()
        {
            
            var apiInstance = new LogSummaryApi();
            var startTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 
            var endTime = 2013-10-20T19:20:30+01:00;  // DateTime? |  (optional) 

            try
            {
                AggregateLogData result = apiInstance.LogSummaryGet(startTime, endTime);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LogSummaryApi.LogSummaryGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **startTime** | **DateTime?**|  | 
 **endTime** | **DateTime?**|  | [optional] 

### Return type

[**AggregateLogData**](AggregateLogData.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="logsummarygetbyid"></a>
# **LogSummaryGetById**
> AggregateLogData LogSummaryGetById (string id, DateTime? startTime, DateTime? endTime = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LogSummaryGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new LogSummaryApi();
            var id = id_example;  // string | 
            var startTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 
            var endTime = 2013-10-20T19:20:30+01:00;  // DateTime? |  (optional) 

            try
            {
                AggregateLogData result = apiInstance.LogSummaryGetById(id, startTime, endTime);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LogSummaryApi.LogSummaryGetById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **startTime** | **DateTime?**|  | 
 **endTime** | **DateTime?**|  | [optional] 

### Return type

[**AggregateLogData**](AggregateLogData.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="logsummarygetbysubalias"></a>
# **LogSummaryGetBySubAlias**
> AggregateLogData LogSummaryGetBySubAlias (string id, DateTime? startTime, string alias, string subAlias, DateTime? endTime = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LogSummaryGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new LogSummaryApi();
            var id = id_example;  // string | 
            var startTime = 2013-10-20T19:20:30+01:00;  // DateTime? | 
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var endTime = 2013-10-20T19:20:30+01:00;  // DateTime? |  (optional) 

            try
            {
                AggregateLogData result = apiInstance.LogSummaryGetBySubAlias(id, startTime, alias, subAlias, endTime);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LogSummaryApi.LogSummaryGetBySubAlias: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **startTime** | **DateTime?**|  | 
 **alias** | **string**|  | 
 **subAlias** | **string**|  | 
 **endTime** | **DateTime?**|  | [optional] 

### Return type

[**AggregateLogData**](AggregateLogData.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

