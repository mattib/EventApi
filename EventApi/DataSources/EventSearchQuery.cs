using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApi.DataSource
{
    public class EventSearchQuery
    {
        public int? TaskId { get; set; }
        public int? UserId { get; set; }
        public DateTime? LastModified { get; set; }
        public int? RowStatus { get; set; }
    }
}