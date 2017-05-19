using System.Collections.Generic;

namespace ApprendaAPIClient.Models
{
    public class UnpagedResourceBase<TEntity> : ResourceBase
    {
        public UnpagedResourceBase(string href) : base(href)
        {
        }

        public List<TEntity> Items { get; set; }
    }
}
