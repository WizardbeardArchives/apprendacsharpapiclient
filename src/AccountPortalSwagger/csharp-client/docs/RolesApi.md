# IO.Swagger.Api.RolesApi

All URIs are relative to *https://apps.apprenda.harp/account*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesDelete**](RolesApi.md#apiv1applicationversionsapplicationversionkeysecurablessecurableidrolesdelete) | **DELETE** /api/v1/applicationVersions/{applicationVersionKey}/securables/{securableId}/roles | Remove role from a securable
[**ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesGet**](RolesApi.md#apiv1applicationversionsapplicationversionkeysecurablessecurableidrolesget) | **GET** /api/v1/applicationVersions/{applicationVersionKey}/securables/{securableId}/roles | Get all roles using a securable
[**ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesPost**](RolesApi.md#apiv1applicationversionsapplicationversionkeysecurablessecurableidrolespost) | **POST** /api/v1/applicationVersions/{applicationVersionKey}/securables/{securableId}/roles | Assign role(s) to a securable
[**ApiV1RolesGet**](RolesApi.md#apiv1rolesget) | **GET** /api/v1/roles | Get all roles
[**ApiV1RolesPost**](RolesApi.md#apiv1rolespost) | **POST** /api/v1/roles | Create role
[**ApiV1RolesRoleIdDelete**](RolesApi.md#apiv1rolesroleiddelete) | **DELETE** /api/v1/roles/{roleId} | Remove role
[**ApiV1RolesRoleIdGet**](RolesApi.md#apiv1rolesroleidget) | **GET** /api/v1/roles/{roleId} | Get role
[**ApiV1RolesRoleIdPut**](RolesApi.md#apiv1rolesroleidput) | **PUT** /api/v1/roles/{roleId} | Update role
[**ApiV1RolesRoleIdRolesDelete**](RolesApi.md#apiv1rolesroleidrolesdelete) | **DELETE** /api/v1/roles/{roleId}/roles | Remove a sub-role from a role
[**ApiV1RolesRoleIdRolesGet**](RolesApi.md#apiv1rolesroleidrolesget) | **GET** /api/v1/roles/{roleId}/roles | Get all sub-roles assigned to a role
[**ApiV1RolesRoleIdRolesPost**](RolesApi.md#apiv1rolesroleidrolespost) | **POST** /api/v1/roles/{roleId}/roles | Make role a sub-role of another role
[**ApiV1RolesRoleIdSecurablesGet**](RolesApi.md#apiv1rolesroleidsecurablesget) | **GET** /api/v1/roles/{roleId}/securables | Get all securables for a role
[**ApiV1RolesRoleIdUsersDelete**](RolesApi.md#apiv1rolesroleidusersdelete) | **DELETE** /api/v1/roles/{roleId}/users | Remove a user from role
[**ApiV1RolesRoleIdUsersGet**](RolesApi.md#apiv1rolesroleidusersget) | **GET** /api/v1/roles/{roleId}/users | Get users of a role
[**ApiV1RolesRoleIdUsersPost**](RolesApi.md#apiv1rolesroleiduserspost) | **POST** /api/v1/roles/{roleId}/users | Add users to a role
[**ApiV1UserRolesDelete**](RolesApi.md#apiv1userrolesdelete) | **DELETE** /api/v1/userRoles | Remove a user from a role
[**ApiV1UserRolesGet**](RolesApi.md#apiv1userrolesget) | **GET** /api/v1/userRoles | Get the roles of a user
[**ApiV1UserRolesPost**](RolesApi.md#apiv1userrolespost) | **POST** /api/v1/userRoles | Assign a user to a role


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
            
            var apiInstance = new RolesApi();
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
                Debug.Print("Exception when calling RolesApi.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesDelete: " + e.Message );
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
            
            var apiInstance = new RolesApi();
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
                Debug.Print("Exception when calling RolesApi.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesGet: " + e.Message );
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
            
            var apiInstance = new RolesApi();
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
                Debug.Print("Exception when calling RolesApi.ApiV1ApplicationVersionsApplicationVersionKeySecurablesSecurableIdRolesPost: " + e.Message );
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

<a name="apiv1rolesget"></a>
# **ApiV1RolesGet**
> UnpagedResourceBaseRole ApiV1RolesGet ()

Get all roles

Returns all roles for your Tenant Account or Development Team.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesGetExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();

            try
            {
                // Get all roles
                UnpagedResourceBaseRole result = apiInstance.ApiV1RolesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**UnpagedResourceBaseRole**](UnpagedResourceBaseRole.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolespost"></a>
# **ApiV1RolesPost**
> Role ApiV1RolesPost (Role body = null)

Create role

Create new roles for your Tenant Account or Development Team.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesPostExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var body = new Role(); // Role | Array of role definitions to add (optional) 

            try
            {
                // Create role
                Role result = apiInstance.ApiV1RolesPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**Role**](Role.md)| Array of role definitions to add | [optional] 

### Return type

[**Role**](Role.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleiddelete"></a>
# **ApiV1RolesRoleIdDelete**
> void ApiV1RolesRoleIdDelete (string roleId)

Remove role

Remove a role from the Tenant Account.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role

            try
            {
                // Remove role
                apiInstance.ApiV1RolesRoleIdDelete(roleId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdDelete: " + e.Message );
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

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleidget"></a>
# **ApiV1RolesRoleIdGet**
> Role ApiV1RolesRoleIdGet (string roleId)

Get role

Returns imformation for a role for the given id.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role

            try
            {
                // Get role
                Role result = apiInstance.ApiV1RolesRoleIdGet(roleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdGet: " + e.Message );
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

[**Role**](Role.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleidput"></a>
# **ApiV1RolesRoleIdPut**
> Role ApiV1RolesRoleIdPut (string roleId, Role body = null)

Update role

Make updates to a role with the given role id. Making a request to this endpoint will update all fields for a role. You should always pass all input values in the body of the request, because any value that is not provided will be updated to the default value.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdPutExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role
            var body = new Role(); // Role | Array of role definitions to update. All fields should be passed in every request. (optional) 

            try
            {
                // Update role
                Role result = apiInstance.ApiV1RolesRoleIdPut(roleId, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleId** | **string**| Required. Unique Platform assigned id of a role | 
 **body** | [**Role**](Role.md)| Array of role definitions to update. All fields should be passed in every request. | [optional] 

### Return type

[**Role**](Role.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleidrolesdelete"></a>
# **ApiV1RolesRoleIdRolesDelete**
> void ApiV1RolesRoleIdRolesDelete (string roleId, List<string> body = null)

Remove a sub-role from a role

Remove a sub role from a role. Users assigned to the removed sub-role will no longer inherit securables from the parent role.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdRolesDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role
            var body = ;  // List<string> | Array of role ids to remove from the role (optional) 

            try
            {
                // Remove a sub-role from a role
                apiInstance.ApiV1RolesRoleIdRolesDelete(roleId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdRolesDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleId** | **string**| Required. Unique Platform assigned id of a role | 
 **body** | **List&lt;string&gt;**| Array of role ids to remove from the role | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleidrolesget"></a>
# **ApiV1RolesRoleIdRolesGet**
> UnpagedResourceBaseRole ApiV1RolesRoleIdRolesGet (string roleId)

Get all sub-roles assigned to a role

Returns all roles assigned to a given role.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdRolesGetExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role

            try
            {
                // Get all sub-roles assigned to a role
                UnpagedResourceBaseRole result = apiInstance.ApiV1RolesRoleIdRolesGet(roleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdRolesGet: " + e.Message );
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

[**UnpagedResourceBaseRole**](UnpagedResourceBaseRole.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleidrolespost"></a>
# **ApiV1RolesRoleIdRolesPost**
> void ApiV1RolesRoleIdRolesPost (string roleId, List<string> roleIds = null)

Make role a sub-role of another role

Add a role as a sub-role to another role. Users assigned to the sub-role will inherit securables assigned to the parent role.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdRolesPostExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role
            var roleIds = ;  // List<string> | Array of role ids to add to the role (optional) 

            try
            {
                // Make role a sub-role of another role
                apiInstance.ApiV1RolesRoleIdRolesPost(roleId, roleIds);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdRolesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleId** | **string**| Required. Unique Platform assigned id of a role | 
 **roleIds** | **List&lt;string&gt;**| Array of role ids to add to the role | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

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
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role

            try
            {
                // Get all securables for a role
                UnpagedResourceBaseSecurable result = apiInstance.ApiV1RolesRoleIdSecurablesGet(roleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdSecurablesGet: " + e.Message );
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

<a name="apiv1rolesroleidusersdelete"></a>
# **ApiV1RolesRoleIdUsersDelete**
> void ApiV1RolesRoleIdUsersDelete (string roleId, List<string> body = null)

Remove a user from role

Remove a user from a role.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdUsersDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role
            var body = ;  // List<string> | Array of user ids to remove from the role (optional) 

            try
            {
                // Remove a user from role
                apiInstance.ApiV1RolesRoleIdUsersDelete(roleId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdUsersDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleId** | **string**| Required. Unique Platform assigned id of a role | 
 **body** | **List&lt;string&gt;**| Array of user ids to remove from the role | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleidusersget"></a>
# **ApiV1RolesRoleIdUsersGet**
> UnpagedResourceBaseUser ApiV1RolesRoleIdUsersGet (string roleId)

Get users of a role

Get all users assigned to a role.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdUsersGetExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role

            try
            {
                // Get users of a role
                UnpagedResourceBaseUser result = apiInstance.ApiV1RolesRoleIdUsersGet(roleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdUsersGet: " + e.Message );
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

[**UnpagedResourceBaseUser**](UnpagedResourceBaseUser.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1rolesroleiduserspost"></a>
# **ApiV1RolesRoleIdUsersPost**
> void ApiV1RolesRoleIdUsersPost (string roleId, List<string> body = null)

Add users to a role

Add the user with the given id to a role.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1RolesRoleIdUsersPostExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role
            var body = ;  // List<string> | Array of user ids to add to the role (optional) 

            try
            {
                // Add users to a role
                apiInstance.ApiV1RolesRoleIdUsersPost(roleId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1RolesRoleIdUsersPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleId** | **string**| Required. Unique Platform assigned id of a role | 
 **body** | **List&lt;string&gt;**| Array of user ids to add to the role | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1userrolesdelete"></a>
# **ApiV1UserRolesDelete**
> void ApiV1UserRolesDelete (string userId, List<string> body = null)

Remove a user from a role

Remove a user from a role.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1UserRolesDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var userId = userId_example;  // string | Required. Unique id of the user
            var body = ;  // List<string> | Array of role ids to remove the user from (optional) 

            try
            {
                // Remove a user from a role
                apiInstance.ApiV1UserRolesDelete(userId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1UserRolesDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| Required. Unique id of the user | 
 **body** | **List&lt;string&gt;**| Array of role ids to remove the user from | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1userrolesget"></a>
# **ApiV1UserRolesGet**
> UnpagedResourceBaseRole ApiV1UserRolesGet (string userId)

Get the roles of a user

Returns a list of all roles a user is assigned to.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1UserRolesGetExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var userId = userId_example;  // string | Required. Unique id of the user

            try
            {
                // Get the roles of a user
                UnpagedResourceBaseRole result = apiInstance.ApiV1UserRolesGet(userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1UserRolesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| Required. Unique id of the user | 

### Return type

[**UnpagedResourceBaseRole**](UnpagedResourceBaseRole.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1userrolespost"></a>
# **ApiV1UserRolesPost**
> void ApiV1UserRolesPost (string userId, List<string> body = null)

Assign a user to a role

Assign a user to 1 or more roles.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1UserRolesPostExample
    {
        public void main()
        {
            
            var apiInstance = new RolesApi();
            var userId = userId_example;  // string | Required. Unique id of the user
            var body = ;  // List<string> | Array of role ids to add the user to (optional) 

            try
            {
                // Assign a user to a role
                apiInstance.ApiV1UserRolesPost(userId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RolesApi.ApiV1UserRolesPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| Required. Unique id of the user | 
 **body** | **List&lt;string&gt;**| Array of role ids to add the user to | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

