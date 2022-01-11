using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppKuspyKreme.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
    }
}