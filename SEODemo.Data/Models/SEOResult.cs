using System;
using System.Collections.Generic;
using System.Text;

namespace SEODemo.Data.Models
{
    public class SEOResult
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public string Target { get; set; }
        public string Engine { get; set; }
        public string Result { get; set; }
        public DateTime DateTime { get; set; }
    }
}
