using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApprendaAPIClient.Services
{
    internal class ClientUriBuilder
    {
        public UriBuilder Builder { get; }

        public ClientUriBuilder(UriBuilder builder)
        {
            Builder = builder;
        }

        public Uri BuildUri(string uriFormat, object[] pathValues = null, object parameters = null)
        {
            Builder.Path += BuildPath(uriFormat, pathValues);
            Builder.Query = BuildQueryString(parameters);

            return Builder.Uri;
        }

        private static string BuildPath(string uriFormat, object[] pathValues)
        {
            return pathValues != null ? string.Format(uriFormat, pathValues) : uriFormat;
        }

        private static string BuildQueryString(object parameters)
        {
            if (parameters == null)
            {
                return string.Empty;
            }

            var httpValueCollection = HttpUtility.ParseQueryString(string.Empty);
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(parameters))
            {
                var name = prop.Name.ToLower();
                var value = prop.GetValue(parameters);

                if (value == null)
                {
                    continue;
                }

                httpValueCollection[name] = value.ToString();
            }
            return httpValueCollection.ToString();
        }
    }
}
