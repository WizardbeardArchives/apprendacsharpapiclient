/* 
 * Apprenda.DeveloperPortal.Web
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
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
    ///  Class for testing JavaRuntimeApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class JavaRuntimeApiTests
    {
        private JavaRuntimeApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new JavaRuntimeApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of JavaRuntimeApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' JavaRuntimeApi
            //Assert.IsInstanceOfType(typeof(JavaRuntimeApi), instance, "instance is a JavaRuntimeApi");
        }

        
        /// <summary>
        /// Test JavaRuntimeGet
        /// </summary>
        [Test]
        public void JavaRuntimeGetTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.JavaRuntimeGet();
            //Assert.IsInstanceOf<List<JavaRuntimeReturn>> (response, "response is List<JavaRuntimeReturn>");
        }
        
        /// <summary>
        /// Test JavaRuntimeGetBySubAlias
        /// </summary>
        [Test]
        public void JavaRuntimeGetBySubAliasTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string alias = null;
            //string subAlias = null;
            //var response = instance.JavaRuntimeGetBySubAlias(alias, subAlias);
            //Assert.IsInstanceOf<List<JavaRuntimeReturn>> (response, "response is List<JavaRuntimeReturn>");
        }
        
    }

}