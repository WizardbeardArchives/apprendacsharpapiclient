/* 
 * Account Management REST API
 *
 * The Account Management REST API can be used to manage user accounts, roles, and securables for applications on the Platform. The endpoints of this API allow you to perform the same the functionality of the Platform's Account Portal for your Tenant's applications.   For more information, see our documentation on the [Account Portal](/current/account).     ## Authentication    Before making a request, you must be authenticated. Follow these instuctions [to get authenticated](/restapi/accountmanagement/v1/authentication). ## Making a Request   ### Prerequisites    * Installed Platform of version 6.6.0 or later    * An active user account assigned to an active Tenant Account or Developer Team    * Authentication token   ### Request URL    All requests must use **https**.       The URL for every request you make is the URL of your Platform followed by \"/account\" and the path structure of the endpoint. For example, if your Platform URL is https://apps.apprenda.harp and you want to get a list of all user accounts for your Tenant, the request URL will be https://apps.apprenda.harp/account/api/v1/users.     For more information, see our documentation on [using api resources](/restapi/accountmanagement/v1/using-resources) and [finding your Cloud URI](/current/clouduri).    ### Request Headers  Your authenication token must be passed in the header of all requests using the key **ApprendaSessionToken** (not case sensitive).    
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing UsersApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class UsersApiTests
    {
        private UsersApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new UsersApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of UsersApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' UsersApi
            //Assert.IsInstanceOfType(typeof(UsersApi), instance, "instance is a UsersApi");
        }

        
        /// <summary>
        /// Test ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete
        /// </summary>
        [Test]
        public void ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string applicationVersionKey = null;
            //string locator = null;
            //string userId = null;
            //instance.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoDelete(applicationVersionKey, locator, userId);
            
        }
        
        /// <summary>
        /// Test ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost
        /// </summary>
        [Test]
        public void ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string applicationVersionKey = null;
            //string locator = null;
            //string userId = null;
            //instance.ApiV1ApplicationVersionsApplicationVersionKeySubscriptionsLocatorAssignedtoPost(applicationVersionKey, locator, userId);
            
        }
        
        /// <summary>
        /// Test ApiV1RolesRoleIdUsersDelete
        /// </summary>
        [Test]
        public void ApiV1RolesRoleIdUsersDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string roleId = null;
            //List<string> body = null;
            //instance.ApiV1RolesRoleIdUsersDelete(roleId, body);
            
        }
        
        /// <summary>
        /// Test ApiV1RolesRoleIdUsersGet
        /// </summary>
        [Test]
        public void ApiV1RolesRoleIdUsersGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string roleId = null;
            //var response = instance.ApiV1RolesRoleIdUsersGet(roleId);
            //Assert.IsInstanceOf<UnpagedResourceBaseUser> (response, "response is UnpagedResourceBaseUser");
        }
        
        /// <summary>
        /// Test ApiV1RolesRoleIdUsersPost
        /// </summary>
        [Test]
        public void ApiV1RolesRoleIdUsersPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string roleId = null;
            //List<string> body = null;
            //instance.ApiV1RolesRoleIdUsersPost(roleId, body);
            
        }
        
        /// <summary>
        /// Test ApiV1UserRolesDelete
        /// </summary>
        [Test]
        public void ApiV1UserRolesDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //List<string> body = null;
            //instance.ApiV1UserRolesDelete(userId, body);
            
        }
        
        /// <summary>
        /// Test ApiV1UserRolesGet
        /// </summary>
        [Test]
        public void ApiV1UserRolesGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //var response = instance.ApiV1UserRolesGet(userId);
            //Assert.IsInstanceOf<UnpagedResourceBaseRole> (response, "response is UnpagedResourceBaseRole");
        }
        
        /// <summary>
        /// Test ApiV1UserRolesPost
        /// </summary>
        [Test]
        public void ApiV1UserRolesPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //List<string> body = null;
            //instance.ApiV1UserRolesPost(userId, body);
            
        }
        
        /// <summary>
        /// Test ApiV1UsersDelete
        /// </summary>
        [Test]
        public void ApiV1UsersDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //instance.ApiV1UsersDelete(userId);
            
        }
        
        /// <summary>
        /// Test ApiV1UsersGet
        /// </summary>
        [Test]
        public void ApiV1UsersGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //string search = null;
            //string pageSize = null;
            //string pageNumber = null;
            //string sortBy = null;
            //string sortOrder = null;
            //string correlationId = null;
            //var response = instance.ApiV1UsersGet(userId, search, pageSize, pageNumber, sortBy, sortOrder, correlationId);
            //Assert.IsInstanceOf<PagedResourceBaseUser> (response, "response is PagedResourceBaseUser");
        }
        
        /// <summary>
        /// Test ApiV1UsersPost
        /// </summary>
        [Test]
        public void ApiV1UsersPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //User body = null;
            //var response = instance.ApiV1UsersPost(body);
            //Assert.IsInstanceOf<User> (response, "response is User");
        }
        
        /// <summary>
        /// Test ApiV1UsersPut
        /// </summary>
        [Test]
        public void ApiV1UsersPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string userId = null;
            //User body = null;
            //var response = instance.ApiV1UsersPut(userId, body);
            //Assert.IsInstanceOf<User> (response, "response is User");
        }
        
    }

}