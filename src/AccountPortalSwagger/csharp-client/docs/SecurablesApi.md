# IO.Swagger.Api.SecurablesApi

All URIs are relative to *https://apps.apprenda.harp/account*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiV1ApplicationVersionsApplicationVersionKeySecurablesGet**](SecurablesApi.md#apiv1applicationversionsapplicationversionkeysecurablesget) | **GET** /api/v1/applicationVersions/{applicationVersionKey}/securables | Get all securables for an application version
[**ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdGet**](SecurablesApi.md#apiv1applicationversionsapplicationversionkeysecurablessecurableidget) | **GET** /api/v1/applicationVersions/{applicationVersionKey}/securables/{securableId} | Get a securable for an application version
[**ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesDelete**](SecurablesApi.md#apiv1applicationversionsapplicationversionkeysecurablessecurableidrolesdelete) | **DELETE** /api/v1/applicationVersions/{applicationVersionKey}/securables/{securableId}/roles | Remove role from a securable
[**ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesGet**](SecurablesApi.md#apiv1applicationversionsapplicationversionkeysecurablessecurableidrolesget) | **GET** /api/v1/applicationVersions/{applicationVersionKey}/securables/{securableId}/roles | Get all roles using a securable
[**ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesPost**](SecurablesApi.md#apiv1applicationversionsapplicationversionkeysecurablessecurableidrolespost) | **POST** /api/v1/applicationVersions/{applicationVersionKey}/securables/{securableId}/roles | Assign role(s) to a securable
[**ApiV1RolesRoleIdSecurablesGet**](SecurablesApi.md#apiv1rolesroleidsecurablesget) | **GET** /api/v1/roles/{roleId}/securables | Get all securables for a role


<a name="apiv1applicationversionsapplicationversionkeysecurablesget"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySecurablesGet**
> UnpagedResourceBaseSecurable ApiV1ApplicationVersionsApplicationVersionKeySecurablesGet (string applicationVersionKey)

Get all securables for an application version

Returns a list of securables associated with an application version.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySecurablesGetExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'

            try
            {
                // Get all securables for an application version
                UnpagedResourceBaseSecurable result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySecurablesGet(applicationVersionKey);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.ApiV1ApplicationVersionsApplicationVersionKeySecurablesGet: " + e.Message );
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

[**UnpagedResourceBaseSecurable**](UnpagedResourceBaseSecurable.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysecurablessecurableidget"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdGet**
> Securable ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdGet (string applicationVersionKey, string securableId)

Get a securable for an application version

Returns a securable for the application version and securable id.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var securableId = securableId_example;  // string | Required. Unique Platform assigned id of a securable

            try
            {
                // Get a securable for an application version
                Securable result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdGet(applicationVersionKey, securableId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **securableId** | **string**| Required. Unique Platform assigned id of a securable | 

### Return type

[**Securable**](Securable.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysecurablessecurableidrolesdelete"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesDelete**
> void ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesDelete (string applicationVersionKey, string securableId, List<string> body = null)

Remove role from a securable

Remove the specified role(s) from a securable.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var securableId = securableId_example;  // string | Required. Unique Platform assigned id of a securable
            var body = ;  // List<string> | Array of role names to be removed from the securable (optional) 

            try
            {
                // Remove role from a securable
                apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesDelete(applicationVersionKey, securableId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **securableId** | **string**| Required. Unique Platform assigned id of a securable | 
 **body** | **List&lt;string&gt;**| Array of role names to be removed from the securable | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysecurablessecurableidrolesget"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesGet**
> UnpagedResourceBaseRole ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesGet (string applicationVersionKey, string securableId)

Get all roles using a securable

Returns the roles associated with the securable.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesGetExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var securableId = securableId_example;  // string | Required. Unique Platform assigned id of a securable

            try
            {
                // Get all roles using a securable
                UnpagedResourceBaseRole result = apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesGet(applicationVersionKey, securableId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **securableId** | **string**| Required. Unique Platform assigned id of a securable | 

### Return type

[**UnpagedResourceBaseRole**](UnpagedResourceBaseRole.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1applicationversionsapplicationversionkeysecurablessecurableidrolespost"></a>
# **ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesPost**
> void ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesPost (string applicationVersionKey, string securableId, List<string> body = null)

Assign role(s) to a securable

Assign role(s) to a securable.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesPostExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();
            var applicationVersionKey = applicationVersionKey_example;  // string | Required. Concatenation of application alias and version alias as 'AppAlias-VersionAlias'
            var securableId = securableId_example;  // string | Required. Unique Platform assigned id of a securable
            var body = ;  // List<string> | Array of role names that should be associated with this securable (optional) 

            try
            {
                // Assign role(s) to a securable
                apiInstance.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesPost(applicationVersionKey, securableId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationVersionKey** | **string**| Required. Concatenation of application alias and version alias as &#39;AppAlias-VersionAlias&#39; | 
 **securableId** | **string**| Required. Unique Platform assigned id of a securable | 
 **body** | **List&lt;string&gt;**| Array of role names that should be associated with this securable | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleidsecurablesget"></a>
# **ApiV1RolesRoleIdSecurablesGet**
> UnpagedResourceBaseSecurable ApiV1RolesRoleIdSecurablesGet (string roleId)

Get all securables for a role

Returns a list of all securables associated with a given role.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdSecurablesGetExample
    {
        public void main()
        {
            
            var apiInstance = new SecurablesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role

            try
            {
                // Get all securables for a role
                UnpagedResourceBaseSecurable result = apiInstance.ApiV1RolesRoleIdSecurablesGet(roleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SecurablesApi.ApiV1RolesRoleIdSecurablesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleId** | **string**| Required. Unique Platform assigned id of a role | 

### Return type

[**UnpagedResourceBaseSecurable**](UnpagedResourceBaseSecurable.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

