# IO.Swagger.Api.MonitoringSubscriptionsApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**MonitoringSubscriptionsDelete**](MonitoringSubscriptionsApi.md#monitoringsubscriptionsdelete) | **DELETE** /api/v1/monitoringsubscriptions/{appAlias}/{versionAlias}/{componentAlias}/{locator} | 
[**MonitoringSubscriptionsGet**](MonitoringSubscriptionsApi.md#monitoringsubscriptionsget) | **GET** /api/v1/monitoringsubscriptions/{appAlias}/{versionAlias} | 
[**MonitoringSubscriptionsGetByComponent**](MonitoringSubscriptionsApi.md#monitoringsubscriptionsgetbycomponent) | **GET** /api/v1/monitoringsubscriptions/{appAlias}/{versionAlias}/{componentAlias} | 
[**MonitoringSubscriptionsGetByLocator**](MonitoringSubscriptionsApi.md#monitoringsubscriptionsgetbylocator) | **GET** /api/v1/monitoringsubscriptions/{appAlias}/{versionAlias}/{componentAlias}/{locator} | 
[**MonitoringSubscriptionsPost**](MonitoringSubscriptionsApi.md#monitoringsubscriptionspost) | **POST** /api/v1/monitoringsubscriptions/{appAlias}/{versionAlias}/{componentAlias} | 
[**MonitoringSubscriptionsPut**](MonitoringSubscriptionsApi.md#monitoringsubscriptionsput) | **PUT** /api/v1/monitoringsubscriptions/{appAlias}/{versionAlias}/{componentAlias}/{locator} | 


<a name="monitoringsubscriptionsdelete"></a>
# **MonitoringSubscriptionsDelete**
> void MonitoringSubscriptionsDelete (string appAlias, string versionAlias, string componentAlias, Guid? locator)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MonitoringSubscriptionsDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new MonitoringSubscriptionsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var locator = locator_example;  // Guid? | 

            try
            {
                apiInstance.MonitoringSubscriptionsDelete(appAlias, versionAlias, componentAlias, locator);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MonitoringSubscriptionsApi.MonitoringSubscriptionsDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 
 **componentAlias** | **string**|  | 
 **locator** | **Guid?**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="monitoringsubscriptionsget"></a>
# **MonitoringSubscriptionsGet**
> List<MonitoringSubscription> MonitoringSubscriptionsGet (string appAlias, string versionAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MonitoringSubscriptionsGetExample
    {
        public void main()
        {
            
            var apiInstance = new MonitoringSubscriptionsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 

            try
            {
                List&lt;MonitoringSubscription&gt; result = apiInstance.MonitoringSubscriptionsGet(appAlias, versionAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MonitoringSubscriptionsApi.MonitoringSubscriptionsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 

### Return type

[**List<MonitoringSubscription>**](MonitoringSubscription.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="monitoringsubscriptionsgetbycomponent"></a>
# **MonitoringSubscriptionsGetByComponent**
> List<MonitoringSubscription> MonitoringSubscriptionsGetByComponent (string appAlias, string versionAlias, string componentAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MonitoringSubscriptionsGetByComponentExample
    {
        public void main()
        {
            
            var apiInstance = new MonitoringSubscriptionsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 

            try
            {
                List&lt;MonitoringSubscription&gt; result = apiInstance.MonitoringSubscriptionsGetByComponent(appAlias, versionAlias, componentAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MonitoringSubscriptionsApi.MonitoringSubscriptionsGetByComponent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 
 **componentAlias** | **string**|  | 

### Return type

[**List<MonitoringSubscription>**](MonitoringSubscription.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="monitoringsubscriptionsgetbylocator"></a>
# **MonitoringSubscriptionsGetByLocator**
> MonitoringSubscription MonitoringSubscriptionsGetByLocator (string appAlias, string versionAlias, string componentAlias, Guid? locator)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MonitoringSubscriptionsGetByLocatorExample
    {
        public void main()
        {
            
            var apiInstance = new MonitoringSubscriptionsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var locator = locator_example;  // Guid? | 

            try
            {
                MonitoringSubscription result = apiInstance.MonitoringSubscriptionsGetByLocator(appAlias, versionAlias, componentAlias, locator);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MonitoringSubscriptionsApi.MonitoringSubscriptionsGetByLocator: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 
 **componentAlias** | **string**|  | 
 **locator** | **Guid?**|  | 

### Return type

[**MonitoringSubscription**](MonitoringSubscription.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="monitoringsubscriptionspost"></a>
# **MonitoringSubscriptionsPost**
> MonitoringSubscription MonitoringSubscriptionsPost (string appAlias, string versionAlias, string componentAlias, MonitoringSubscription monitoringSubscription)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MonitoringSubscriptionsPostExample
    {
        public void main()
        {
            
            var apiInstance = new MonitoringSubscriptionsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var monitoringSubscription = new MonitoringSubscription(); // MonitoringSubscription | 

            try
            {
                MonitoringSubscription result = apiInstance.MonitoringSubscriptionsPost(appAlias, versionAlias, componentAlias, monitoringSubscription);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MonitoringSubscriptionsApi.MonitoringSubscriptionsPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 
 **componentAlias** | **string**|  | 
 **monitoringSubscription** | [**MonitoringSubscription**](MonitoringSubscription.md)|  | 

### Return type

[**MonitoringSubscription**](MonitoringSubscription.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="monitoringsubscriptionsput"></a>
# **MonitoringSubscriptionsPut**
> void MonitoringSubscriptionsPut (string appAlias, string versionAlias, string componentAlias, Guid? locator, MonitoringSubscription monitoringSubscription)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MonitoringSubscriptionsPutExample
    {
        public void main()
        {
            
            var apiInstance = new MonitoringSubscriptionsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var locator = locator_example;  // Guid? | 
            var monitoringSubscription = new MonitoringSubscription(); // MonitoringSubscription | 

            try
            {
                apiInstance.MonitoringSubscriptionsPut(appAlias, versionAlias, componentAlias, locator, monitoringSubscription);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MonitoringSubscriptionsApi.MonitoringSubscriptionsPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 
 **componentAlias** | **string**|  | 
 **locator** | **Guid?**|  | 
 **monitoringSubscription** | [**MonitoringSubscription**](MonitoringSubscription.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

