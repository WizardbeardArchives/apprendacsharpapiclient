using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprendaAPIClient.Models
{
    public class PagedResourceBase<T> : ResourceBase
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public long TotalItems { get; set; }

        public IEnumerable<T> Items { get; set; }

        public ResourceBase NextPage { get; set; }
        public ResourceBase PreviousPage { get; set; }
    }
}
