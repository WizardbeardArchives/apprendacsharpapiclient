# IO.Swagger.Api.VersionReportCardsApi

All URIs are relative to *https://apps.apprenda.msterling/developer*

Method | HTTP request | Description
------------- | ------------- | -------------
[**VersionReportCardsGet**](VersionReportCardsApi.md#versionreportcardsget) | **GET** /api/v1/versions/{appAlias}/{versionAlias}/reportCards | 
[**VersionReportCardsGetLatest**](VersionReportCardsApi.md#versionreportcardsgetlatest) | **GET** /api/v1/versions/{appAlias}/{versionAlias}/reportCards/latest | 


<a name="versionreportcardsget"></a>
# **VersionReportCardsGet**
> List<ReportCard> VersionReportCardsGet (string appAlias, string versionAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class VersionReportCardsGetExample
    {
        public void main()
        {
            
            var apiInstance = new VersionReportCardsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 

            try
            {
                List&lt;ReportCard&gt; result = apiInstance.VersionReportCardsGet(appAlias, versionAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionReportCardsApi.VersionReportCardsGet: " + e.Message );
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

[**List<ReportCard>**](ReportCard.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="versionreportcardsgetlatest"></a>
# **VersionReportCardsGetLatest**
> List<ReportCard> VersionReportCardsGetLatest (string appAlias, string versionAlias)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class VersionReportCardsGetLatestExample
    {
        public void main()
        {
            
            var apiInstance = new VersionReportCardsApi();
            var appAlias = appAlias_example;  // string | 
            var versionAlias = versionAlias_example;  // string | 

            try
            {
                List&lt;ReportCard&gt; result = apiInstance.VersionReportCardsGetLatest(appAlias, versionAlias);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VersionReportCardsApi.VersionReportCardsGetLatest: " + e.Message );
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

[**List<ReportCard>**](ReportCard.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

