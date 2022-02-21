using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.Models
{
    public class Report
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? Email { get; set; }
        public string? MissingProperty { get; set; }
        public bool IsDeleted { get; set; }

    }
}
