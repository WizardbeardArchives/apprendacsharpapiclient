using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
