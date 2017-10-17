using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.UI.Models
{
    public class PageInfo
    {
        public int totalItems { get; set; }
        public int itemsPerPage { get; set; }
        public int currentPage { get; set; }
        public int totalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)totalItems / itemsPerPage);
            }
        }
    }
}