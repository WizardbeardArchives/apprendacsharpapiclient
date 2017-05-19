# IO.Swagger.Api.UsersApi

All URIs are relative to *https://apps.apprenda.harp/account*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete**](UsersApi.md#apiv1applicationversionsapplicationversionkeysubscriptionslocatorassignedtodelete) | **DELETE** /api/v1/applicationVersions/{applicationVersionKey}/subscriptions/{locator}/assignedto | Unsubscribe user from subscription
[**ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost**](UsersApi.md#apiv1applicationversionsapplicationversionkeysubscriptionslocatorassignedtopost) | **POST** /api/v1/applicationVersions/{applicationVersionKey}/subscriptions/{locator}/assignedto | Subscribe user
[**ApiV1RolesRoleIdUsersDelete**](UsersApi.md#apiv1rolesroleidusersdelete) | **DELETE** /api/v1/roles/{roleId}/users | Remove a user from role
[**ApiV1RolesRoleIdUsersGet**](UsersApi.md#apiv1rolesroleidusersget) | **GET** /api/v1/roles/{roleId}/users | Get users of a role
[**ApiV1RolesRoleIdUsersPost**](UsersApi.md#apiv1rolesroleiduserspost) | **POST** /api/v1/roles/{roleId}/users | Add users to a role
[**ApiV1UserRolesDelete**](UsersApi.md#apiv1userrolesdelete) | **DELETE** /api/v1/userRoles | Remove a user from a role
[**ApiV1UserRolesGet**](UsersApi.md#apiv1userrolesget) | **GET** /api/v1/userRoles | Get the roles of a user
[**ApiV1UserRolesPost**](UsersApi.md#apiv1userrolespost) | **POST** /api/v1/userRoles | Assign a user to a role
[**ApiV1UsersDelete**](UsersApi.md#apiv1usersdelete) | **DELETE** /api/v1/users | Delete user
[**ApiV1UsersGet**](UsersApi.md#apiv1usersget) | **GET** /api/v1/users | Get all users
[**ApiV1UsersPost**](UsersApi.md#apiv1userspost) | **POST** /api/v1/users | Add a user
[**ApiV1UsersPut**](UsersApi.md#apiv1usersput) | **PUT** /api/v1/users | Update a user


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
            
            var apiInstance = new UsersApi();
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
                Debug.Print("Exception when calling UsersApi.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete: " + e.Message );
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
            
            var apiInstance = new UsersApi();
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
                Debug.Print("Exception when calling UsersApi.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost: " + e.Message );
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
            
            var apiInstance = new UsersApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role
            var body = ;  // List<string> | Array of user ids to remove from the role (optional) 

            try
            {
                // Remove a user from role
                apiInstance.ApiV1RolesRoleIdUsersDelete(roleId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1RolesRoleIdUsersDelete: " + e.Message );
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
            
            var apiInstance = new UsersApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role

            try
            {
                // Get users of a role
                UnpagedResourceBaseUser result = apiInstance.ApiV1RolesRoleIdUsersGet(roleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1RolesRoleIdUsersGet: " + e.Message );
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
            
            var apiInstance = new UsersApi();
            var roleId = roleId_example;  // string | Required. Unique Platform assigned id of a role
            var body = ;  // List<string> | Array of user ids to add to the role (optional) 

            try
            {
                // Add users to a role
                apiInstance.ApiV1RolesRoleIdUsersPost(roleId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1RolesRoleIdUsersPost: " + e.Message );
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
            
            var apiInstance = new UsersApi();
            var userId = userId_example;  // string | Required. Unique id of the user
            var body = ;  // List<string> | Array of role ids to remove the user from (optional) 

            try
            {
                // Remove a user from a role
                apiInstance.ApiV1UserRolesDelete(userId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1UserRolesDelete: " + e.Message );
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
            
            var apiInstance = new UsersApi();
            var userId = userId_example;  // string | Required. Unique id of the user

            try
            {
                // Get the roles of a user
                UnpagedResourceBaseRole result = apiInstance.ApiV1UserRolesGet(userId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1UserRolesGet: " + e.Message );
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
            
            var apiInstance = new UsersApi();
            var userId = userId_example;  // string | Required. Unique id of the user
            var body = ;  // List<string> | Array of role ids to add the user to (optional) 

            try
            {
                // Assign a user to a role
                apiInstance.ApiV1UserRolesPost(userId, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1UserRolesPost: " + e.Message );
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

<a name="apiv1usersdelete"></a>
# **ApiV1UsersDelete**
> void ApiV1UsersDelete (string userId)

Delete user

Remove a user from the Platform.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1UsersDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new UsersApi();
            var userId = userId_example;  // string | Required. Unique id of the user

            try
            {
                // Delete user
                apiInstance.ApiV1UsersDelete(userId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1UsersDelete: " + e.Message );
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

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1usersget"></a>
# **ApiV1UsersGet**
> PagedResourceBaseUser ApiV1UsersGet (string userId = null, string search = null, string pageSize = null, string pageNumber = null, string sortBy = null, string sortOrder = null, string correlationId = null)

Get all users

Return a list of all users in the Tenant Account or Development Team.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1UsersGetExample
    {
        public void main()
        {
            
            var apiInstance = new UsersApi();
            var userId = userId_example;  // string | Required. Unique id of the user (optional) 
            var search = search_example;  // string |  (optional) 
            var pageSize = pageSize_example;  // string | Number of results to return in a single request. All results will be grouped into pages of this size. Default 20 (optional) 
            var pageNumber = pageNumber_example;  // string | The page of results to return. Defaults to 0, the first page (optional) 
            var sortBy = sortBy_example;  // string |  (optional) 
            var sortOrder = sortOrder_example;  // string | How results should be sorted. Allowed values: ascending, descending (optional) 
            var correlationId = correlationId_example;  // string |  (optional) 

            try
            {
                // Get all users
                PagedResourceBaseUser result = apiInstance.ApiV1UsersGet(userId, search, pageSize, pageNumber, sortBy, sortOrder, correlationId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1UsersGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**| Required. Unique id of the user | [optional] 
 **search** | **string**|  | [optional] 
 **pageSize** | **string**| Number of results to return in a single request. All results will be grouped into pages of this size. Default 20 | [optional] 
 **pageNumber** | **string**| The page of results to return. Defaults to 0, the first page | [optional] 
 **sortBy** | **string**|  | [optional] 
 **sortOrder** | **string**| How results should be sorted. Allowed values: ascending, descending | [optional] 
 **correlationId** | **string**|  | [optional] 

### Return type

[**PagedResourceBaseUser**](PagedResourceBaseUser.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1userspost"></a>
# **ApiV1UsersPost**
> User ApiV1UsersPost (User body = null)

Add a user

Add a user to the Platform.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1UsersPostExample
    {
        public void main()
        {
            
            var apiInstance = new UsersApi();
            var body = new User(); // User | User definitions to add (optional) 

            try
            {
                // Add a user
                User result = apiInstance.ApiV1UsersPost(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1UsersPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**User**](User.md)| User definitions to add | [optional] 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiv1usersput"></a>
# **ApiV1UsersPut**
> User ApiV1UsersPut (string userId, User body = null)

Update a user

Update user information for the given user id. Making a request to this endpoint will update all fields for a user. You should always pass all input values in the body of the request, because any value that is not provided will be updated to the default value.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiV1UsersPutExample
    {
        public void main()
        {
            
            var apiInstance = new UsersApi();
            var userId = userId_example;  // string | 
            var body = new User(); // User |  (optional) 

            try
            {
                // Update a user
                User result = apiInstance.ApiV1UsersPut(userId, body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UsersApi.ApiV1UsersPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **string**|  | 
 **body** | [**User**](User.md)|  | [optional] 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

