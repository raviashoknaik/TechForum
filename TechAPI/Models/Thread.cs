using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechAPI.Models
{
    public class Thread: HttpResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? StatusID { get; set; }
        public int? TagID { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}