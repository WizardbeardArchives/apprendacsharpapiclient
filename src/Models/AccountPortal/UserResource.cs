using System;

namespace ApprendaAPIClient.Models.AccountPortal
{
    public class UserResource
    {
        public string Href { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public bool IsEnabled { get; set; }
        public ResourceBase Roles { get; set; }
    }
}
