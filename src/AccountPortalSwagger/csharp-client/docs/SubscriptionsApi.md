# IO.Swagger.Api.SubscriptionsApi

All URIs are relative to *https://apps.apprenda.harp/account*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsGet**](SubscriptionsApi.md#apiv1applicationversionsapplicationversionkeysubscriptionsget) | **GET** /api/v1/applicationVersions/{applicationVersionKey}/subscriptions | Get all subscriptions of an application version
[**ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete**](SubscriptionsApi.md#apiv1applicationversionsapplicationversionkeysubscriptionslocatorassignedtodelete) | **DELETE** /api/v1/applicationVersions/{applicationVersionKey}/subscriptions/{locator}/assignedto | Unsubscribe user from subscription
[**ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost**](SubscriptionsApi.md#apiv1applicationversionsapplicationversionkeysubscriptionslocatorassignedtopost) | **POST** /api/v1/applicationVersions/{applicationVersionKey}/subscriptions/{locator}/assignedto | Subscribe user
[**ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorDelete**](SubscriptionsApi.md#apiv1applicationversionsapplicationversionkeysubscriptionslocatordelete) | **DELETE** /api/v1/applicationVersions/{applicationVersionKey}/subscriptions/{locator} | Cancel a subscription
[**ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorGet**](SubscriptionsApi.md#apiv1applicationversionsapplicationversionkeysubscriptionslocatorget) | **GET** /api/v1/applicationVersions/{applicationVersionKey}/subscriptions/{locator} | Get a subscription for an application version
[**ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsPost**](SubscriptionsApi.md#apiv1applicationversionsapplicationversionkeysubscriptionspost) | **POST** /api/v1/applicationVersions/{applicationVersionKey}/subscriptions | Create a new subscription


<a name="apiv1applicationversionsapplicationversionkeysubscriptionsget"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsGet**
> UnpagedResourceBaseSubscription ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsGet (string applicationVersionKey)

Get all subscriptions of an application version

Return all subscriptions associated with an application version.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsGetExample
    {
        public void main()
        {
            
            var apiInstance = new SubscriptionsApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'

            try
            {
                // Get all subscriptions of an application version
                UnpagedResourceBaseSubscription result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsGet(applicationVersionKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 

### Return type

[**UnpagedResourceBaseSubscription**](UnpagedResourceBaseSubscription.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysubscriptionslocatorassignedtodelete"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete**
> void ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete (string applicationVersionKey, string locator, string userId)

Unsubscribe user from subscription

Unsubscribe a user from the subscription.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new SubscriptionsApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var locator = locator_example;  // string | Required. Unique Platform assigned locator id of the securable
            var userId = userId_example;  // string | Required. Unique id of the user

            try
            {
                // Unsubscribe user from subscription
                apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete(applicationVersionKey, locator, userId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **locator** | **string**| Required. Unique Platform assigned locator id of the securable | 
 **userId** | **string**| Required. Unique id of the user | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysubscriptionslocatorassignedtopost"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost**
> void ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost (string applicationVersionKey, string locator, string userId)

Subscribe user

Assign a user to the subscription.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPostExample
    {
        public void main()
        {
            
            var apiInstance = new SubscriptionsApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var locator = locator_example;  // string | Required. Unique Platform assigned locator id of the securable
            var userId = userId_example;  // string | Required. Unique id of the user

            try
            {
                // Subscribe user
                apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost(applicationVersionKey, locator, userId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **locator** | **string**| Required. Unique Platform assigned locator id of the securable | 
 **userId** | **string**| Required. Unique id of the user | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysubscriptionslocatordelete"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorDelete**
> void ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorDelete (string applicationVersionKey, string locator)

Cancel a subscription

Cancel a subscription by locator id.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new SubscriptionsApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var locator = locator_example;  // string | Required. Unique Platform assigned locator id of the securable

            try
            {
                // Cancel a subscription
                apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorDelete(applicationVersionKey, locator);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **locator** | **string**| Required. Unique Platform assigned locator id of the securable | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysubscriptionslocatorget"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorGet**
> Subscription ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorGet (string applicationVersionKey, string locator)

Get a subscription for an application version

Return a subscription for an application version by its locator.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorGetExample
    {
        public void main()
        {
            
            var apiInstance = new SubscriptionsApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var locator = locator_example;  // string | Required. Unique Platform assigned locator id of the securable

            try
            {
                // Get a subscription for an application version
                Subscription result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorGet(applicationVersionKey, locator);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **locator** | **string**| Required. Unique Platform assigned locator id of the securable | 

### Return type

[**Subscription**](Subscription.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysubscriptionspost"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsPost**
> UnpagedResourceBaseSubscription ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsPost (string applicationVersionKey, SubscriptionRequest body = null)

Create a new subscription

Create plan subscriptions for an application version.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsPostExample
    {
        public void main()
        {
            
            var apiInstance = new SubscriptionsApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var body = new SubscriptionRequest(); // SubscriptionRequest | Array of plans and the number of new subscriptions to create for each plan (optional) 

            try
            {
                // Create a new subscription
                UnpagedResourceBaseSubscription result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsPost(applicationVersionKey, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SubscriptionsApi.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **body** | [**SubscriptionRequest**](SubscriptionRequest.md)| Array of plans and the number of new subscriptions to create for each plan | [optional] 

### Return type

[**UnpagedResourceBaseSubscription**](UnpagedResourceBaseSubscription.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

