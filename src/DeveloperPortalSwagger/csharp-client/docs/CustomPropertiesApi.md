# IO.Swagger.Api.CustomPropertiesApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CustomPropertiesDelete**](CustomPropertiesApi.md#custompropertiesdelete) | **DELETE** /api/v1/CustomProperties | 
[**CustomPropertiesDeleteByIdentifier**](CustomPropertiesApi.md#custompropertiesdeletebyidentifier) | **DELETE** /api/v1/CustomProperties/{alias}/{subAlias}/{identifier} | 
[**CustomPropertiesDeleteBySubAlias**](CustomPropertiesApi.md#custompropertiesdeletebysubalias) | **DELETE** /api/v1/CustomProperties/{alias}/{subAlias} | 
[**CustomPropertiesGet**](CustomPropertiesApi.md#custompropertiesget) | **GET** /api/v1/CustomProperties | 
[**CustomPropertiesGetByIdentifier**](CustomPropertiesApi.md#custompropertiesgetbyidentifier) | **GET** /api/v1/CustomProperties/{alias}/{subAlias}/{identifier} | 
[**CustomPropertiesGetBySubAlias**](CustomPropertiesApi.md#custompropertiesgetbysubalias) | **GET** /api/v1/CustomProperties/{alias}/{subAlias} | 
[**CustomPropertiesGetModel**](CustomPropertiesApi.md#custompropertiesgetmodel) | **GET** /api/v1/custompropertymodels/{modelName} | 
[**CustomPropertiesPut**](CustomPropertiesApi.md#custompropertiesput) | **PUT** /api/v1/CustomProperties | 
[**CustomPropertiesPutByIdentifier**](CustomPropertiesApi.md#custompropertiesputbyidentifier) | **PUT** /api/v1/CustomProperties/{alias}/{subAlias}/{identifier} | 
[**CustomPropertiesPutBySubAlias**](CustomPropertiesApi.md#custompropertiesputbysubalias) | **PUT** /api/v1/CustomProperties/{alias}/{subAlias} | 


<a name="custompropertiesdelete"></a>
# **CustomPropertiesDelete**
> void CustomPropertiesDelete (string alias, string subAlias, string propertyName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var propertyName = propertyName_example;  // string | 

            try
            {
                apiInstance.CustomPropertiesDelete(alias, subAlias, propertyName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesDelete: " + e.Message );
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
 **propertyName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesdeletebyidentifier"></a>
# **CustomPropertiesDeleteByIdentifier**
> void CustomPropertiesDeleteByIdentifier (string alias, string subAlias, string identifier, string propertyName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesDeleteByIdentifierExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var propertyName = propertyName_example;  // string | 

            try
            {
                apiInstance.CustomPropertiesDeleteByIdentifier(alias, subAlias, identifier, propertyName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesDeleteByIdentifier: " + e.Message );
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
 **propertyName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesdeletebysubalias"></a>
# **CustomPropertiesDeleteBySubAlias**
> void CustomPropertiesDeleteBySubAlias (string alias, string subAlias, string propertyName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesDeleteBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var propertyName = propertyName_example;  // string | 

            try
            {
                apiInstance.CustomPropertiesDeleteBySubAlias(alias, subAlias, propertyName);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesDeleteBySubAlias: " + e.Message );
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
 **propertyName** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesget"></a>
# **CustomPropertiesGet**
> List<CustomProperty> CustomPropertiesGet (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesGetExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;CustomProperty&gt; result = apiInstance.CustomPropertiesGet(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesGet: " + e.Message );
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

[**List<CustomProperty>**](CustomProperty.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesgetbyidentifier"></a>
# **CustomPropertiesGetByIdentifier**
> List<CustomProperty> CustomPropertiesGetByIdentifier (string alias, string subAlias, string identifier)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesGetByIdentifierExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 

            try
            {
                List&lt;CustomProperty&gt; result = apiInstance.CustomPropertiesGetByIdentifier(alias, subAlias, identifier);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesGetByIdentifier: " + e.Message );
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

[**List<CustomProperty>**](CustomProperty.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesgetbysubalias"></a>
# **CustomPropertiesGetBySubAlias**
> List<CustomProperty> CustomPropertiesGetBySubAlias (string alias, string subAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesGetBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 

            try
            {
                List&lt;CustomProperty&gt; result = apiInstance.CustomPropertiesGetBySubAlias(alias, subAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesGetBySubAlias: " + e.Message );
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

[**List<CustomProperty>**](CustomProperty.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesgetmodel"></a>
# **CustomPropertiesGetModel**
> CustomPropertyModel CustomPropertiesGetModel (string modelName)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesGetModelExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var modelName = modelName_example;  // string | 

            try
            {
                CustomPropertyModel result = apiInstance.CustomPropertiesGetModel(modelName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesGetModel: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modelName** | **string**|  | 

### Return type

[**CustomPropertyModel**](CustomPropertyModel.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesput"></a>
# **CustomPropertiesPut**
> void CustomPropertiesPut (string alias, string subAlias, CustomProperty customProperty)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesPutExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var customProperty = new CustomProperty(); // CustomProperty | 

            try
            {
                apiInstance.CustomPropertiesPut(alias, subAlias, customProperty);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesPut: " + e.Message );
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
 **customProperty** | [**CustomProperty**](CustomProperty.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesputbyidentifier"></a>
# **CustomPropertiesPutByIdentifier**
> void CustomPropertiesPutByIdentifier (string alias, string subAlias, string identifier, CustomProperty customProperty)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesPutByIdentifierExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var identifier = identifier_example;  // string | 
            var customProperty = new CustomProperty(); // CustomProperty | 

            try
            {
                apiInstance.CustomPropertiesPutByIdentifier(alias, subAlias, identifier, customProperty);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesPutByIdentifier: " + e.Message );
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
 **customProperty** | [**CustomProperty**](CustomProperty.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="custompropertiesputbysubalias"></a>
# **CustomPropertiesPutBySubAlias**
> void CustomPropertiesPutBySubAlias (string alias, string subAlias, CustomProperty customProperty)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CustomPropertiesPutBySubAliasExample
    {
        public void main()
        {
            
            var apiInstance = new CustomPropertiesApi();
            var alias = alias_example;  // string | 
            var subAlias = subAlias_example;  // string | 
            var customProperty = new CustomProperty(); // CustomProperty | 

            try
            {
                apiInstance.CustomPropertiesPutBySubAlias(alias, subAlias, customProperty);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CustomPropertiesApi.CustomPropertiesPutBySubAlias: " + e.Message );
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
 **customProperty** | [**CustomProperty**](CustomProperty.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

