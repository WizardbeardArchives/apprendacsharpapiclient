# IO.Swagger.Api.ComponentsApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ComponentsDeleteCertificate**](ComponentsApi.md#componentsdeletecertificate) | **DELETE** /api/v1/components/{appAlias}/{versionAlias}/{componentAlias}/certificates/{fileName} | 
[**ComponentsGet**](ComponentsApi.md#componentsget) | **GET** /api/v1/Components | 
[**ComponentsGetByIDentifier**](ComponentsApi.md#componentsgetbyidentifier) | **GET** /api/v1/Components/{alias}/{subAlias}/{identifier} | 
[**ComponentsGetBySubAlias**](ComponentsApi.md#componentsgetbysubalias) | **GET** /api/v1/Components/{alias}/{subAlias} | 
[**ComponentsGetCertificate**](ComponentsApi.md#componentsgetcertificate) | **GET** /api/v1/components/{appAlias}/{versionAlias}/{componentAlias}/certificates/{fileName} | 
[**ComponentsGetFiles**](ComponentsApi.md#componentsgetfiles) | **GET** /api/v1/components/{appAlias}/{versionAlias}/{componentAlias}/files | 
[**ComponentsGetScaleByAlias**](ComponentsApi.md#componentsgetscalebyalias) | **GET** /api/v1/Components/{appAlias}/{versionAlias}/{componentAlias}/scale/{count} | 
[**ComponentsPost**](ComponentsApi.md#componentspost) | **POST** /api/v1/Components | 
[**ComponentsPostActionByIdentifier**](ComponentsApi.md#componentspostactionbyidentifier) | **POST** /api/v1/Components/{alias}/{subAlias}/{identifier} | 
[**ComponentsPostCertificate**](ComponentsApi.md#componentspostcertificate) | **POST** /api/v1/components/{appAlias}/{versionAlias}/{componentAlias}/certificates | 
[**ComponentsPostScaleByIdentifier**](ComponentsApi.md#componentspostscalebyidentifier) | **POST** /api/v1/Components/{appAlias}/{versionAlias}/{componentAlias}/scale/{count} | 
[**ComponentsPut**](ComponentsApi.md#componentsput) | **PUT** /api/v1/Components | 
[**ComponentsPutByAlias**](ComponentsApi.md#componentsputbyalias) | **PUT** /api/v1/Components/{alias}/{subAlias}/{identifier} | 
[**ComponentsPutCountByIdentifier**](ComponentsApi.md#componentsputcountbyidentifier) | **PUT** /api/v1/Components/{appAlias}/{versionAlias}/{componentAlias}/scale/{count} | 


<a name="componentsdeletecertificate"></a>
# **ComponentsDeleteCertificate**
> void ComponentsDeleteCertificate (string appAlias, string versionAlias, string componentAlias, string fileName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsDeleteCertificateExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var fileName = fileName_example;  // string | 

            try
            {
                apiInstance.ComponentsDeleteCertificate(appAlias, versionAlias, componentAlias, fileName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsDeleteCertificate: " + e.Message );
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
 **fileName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsget"></a>
# **ComponentsGet**
> List<Component> ComponentsGet (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsGetExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;Component&gt; result = apiInstance.ComponentsGet(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsGet: " + e.Message );
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

[**List<Component>**](Component.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsgetbyidentifier"></a>
# **ComponentsGetByIDentifier**
> EnrichedComponent ComponentsGetByIDentifier (string alias, string subAlias, string identifier)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsGetByIDentifierExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 

            try
            {
                EnrichedComponent result = apiInstance.ComponentsGetByIDentifier(alias, subAlias, identifier);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsGetByIDentifier: " + e.Message );
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
 **identifier** | **string**|  | 

### Return type

[**EnrichedComponent**](EnrichedComponent.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsgetbysubalias"></a>
# **ComponentsGetBySubAlias**
> List<Component> ComponentsGetBySubAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;Component&gt; result = apiInstance.ComponentsGetBySubAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsGetBySubAlias: " + e.Message );
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

[**List<Component>**](Component.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsgetcertificate"></a>
# **ComponentsGetCertificate**
> Certificate ComponentsGetCertificate (string appAlias, string versionAlias, string componentAlias, string fileName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsGetCertificateExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var fileName = fileName_example;  // string | 

            try
            {
                Certificate result = apiInstance.ComponentsGetCertificate(appAlias, versionAlias, componentAlias, fileName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsGetCertificate: " + e.Message );
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
 **fileName** | **string**|  | 

### Return type

[**Certificate**](Certificate.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsgetfiles"></a>
# **ComponentsGetFiles**
> List<ComponentResource> ComponentsGetFiles (string appAlias, string versionAlias, string componentAlias, string path = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsGetFilesExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var path = path_example;  // string |  (optional) 

            try
            {
                List&lt;ComponentResource&gt; result = apiInstance.ComponentsGetFiles(appAlias, versionAlias, componentAlias, path);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsGetFiles: " + e.Message );
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
 **path** | **string**|  | [optional] 

### Return type

[**List<ComponentResource>**](ComponentResource.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsgetscalebyalias"></a>
# **ComponentsGetScaleByAlias**
> List<Component> ComponentsGetScaleByAlias (string alias, string subAlias, string appAlias, string versionAlias, string componentAlias, string count)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsGetScaleByAliasExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var count = count_example;  // string | 

            try
            {
                List&lt;Component&gt; result = apiInstance.ComponentsGetScaleByAlias(alias, subAlias, appAlias, versionAlias, componentAlias, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsGetScaleByAlias: " + e.Message );
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
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 
 **componentAlias** | **string**|  | 
 **count** | **string**|  | 

### Return type

[**List<Component>**](Component.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentspost"></a>
# **ComponentsPost**
> void ComponentsPost (string alias, string subAlias, string identifier, string action, int? count = null, int? minCount = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsPostExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var action = action_example;  // string | 
            var count = 56;  // int? |  (optional) 
            var minCount = 56;  // int? |  (optional) 

            try
            {
                apiInstance.ComponentsPost(alias, subAlias, identifier, action, count, minCount);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsPost: " + e.Message );
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
 **identifier** | **string**|  | 
 **action** | **string**|  | 
 **count** | **int?**|  | [optional] 
 **minCount** | **int?**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentspostactionbyidentifier"></a>
# **ComponentsPostActionByIdentifier**
> void ComponentsPostActionByIdentifier (string alias, string subAlias, string identifier, string action, int? count = null, int? minCount = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsPostActionByIdentifierExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var action = action_example;  // string | 
            var count = 56;  // int? |  (optional) 
            var minCount = 56;  // int? |  (optional) 

            try
            {
                apiInstance.ComponentsPostActionByIdentifier(alias, subAlias, identifier, action, count, minCount);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsPostActionByIdentifier: " + e.Message );
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
 **identifier** | **string**|  | 
 **action** | **string**|  | 
 **count** | **int?**|  | [optional] 
 **minCount** | **int?**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentspostcertificate"></a>
# **ComponentsPostCertificate**
> List<Certificate> ComponentsPostCertificate (string appAlias, string versionAlias, string componentAlias, string url = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsPostCertificateExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var url = url_example;  // string |  (optional) 

            try
            {
                List&lt;Certificate&gt; result = apiInstance.ComponentsPostCertificate(appAlias, versionAlias, componentAlias, url);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsPostCertificate: " + e.Message );
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
 **url** | **string**|  | [optional] 

### Return type

[**List<Certificate>**](Certificate.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentspostscalebyidentifier"></a>
# **ComponentsPostScaleByIdentifier**
> void ComponentsPostScaleByIdentifier (string alias, string subAlias, string identifier, string action, int? count, string appAlias, string versionAlias, string componentAlias, int? minCount = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsPostScaleByIdentifierExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var action = action_example;  // string | 
            var count = 56;  // int? | 
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var minCount = 56;  // int? |  (optional) 

            try
            {
                apiInstance.ComponentsPostScaleByIdentifier(alias, subAlias, identifier, action, count, appAlias, versionAlias, componentAlias, minCount);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsPostScaleByIdentifier: " + e.Message );
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
 **identifier** | **string**|  | 
 **action** | **string**|  | 
 **count** | **int?**|  | 
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 
 **componentAlias** | **string**|  | 
 **minCount** | **int?**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsput"></a>
# **ComponentsPut**
> Object ComponentsPut (string alias, string subAlias, string identifier, EnrichedComponentModel component)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsPutExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var component = new EnrichedComponentModel(); // EnrichedComponentModel | 

            try
            {
                Object result = apiInstance.ComponentsPut(alias, subAlias, identifier, component);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsPut: " + e.Message );
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
 **identifier** | **string**|  | 
 **component** | [**EnrichedComponentModel**](EnrichedComponentModel.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsputbyalias"></a>
# **ComponentsPutByAlias**
> Object ComponentsPutByAlias (string alias, string subAlias, string identifier, EnrichedComponentModel component)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsPutByAliasExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var component = new EnrichedComponentModel(); // EnrichedComponentModel | 

            try
            {
                Object result = apiInstance.ComponentsPutByAlias(alias, subAlias, identifier, component);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsPutByAlias: " + e.Message );
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
 **identifier** | **string**|  | 
 **component** | [**EnrichedComponentModel**](EnrichedComponentModel.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="componentsputcountbyidentifier"></a>
# **ComponentsPutCountByIdentifier**
> Object ComponentsPutCountByIdentifier (string alias, string subAlias, string identifier, EnrichedComponentModel component, string appAlias, string versionAlias, string componentAlias, string count)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ComponentsPutCountByIdentifierExample
    {
        public void main()
        {
            
            var apiInstance = new ComponentsApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var component = new EnrichedComponentModel(); // EnrichedComponentModel | 
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 
            var componentAlias = componentAlias_example;  // string | 
            var count = count_example;  // string | 

            try
            {
                Object result = apiInstance.ComponentsPutCountByIdentifier(alias, subAlias, identifier, component, appAlias, versionAlias, componentAlias, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ComponentsApi.ComponentsPutCountByIdentifier: " + e.Message );
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
 **identifier** | **string**|  | 
 **component** | [**EnrichedComponentModel**](EnrichedComponentModel.md)|  | 
 **appAlias** | **string**|  | 
 **versionAlias** | **string**|  | 
 **componentAlias** | **string**|  | 
 **count** | **string**|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

