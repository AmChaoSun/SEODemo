using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEODemo.Models
{
    public class SEORequest
    {
        /// <summary>
        /// This is the name of engine,
        /// Currently only: "Google", "Bing", "InfoTrackGoogle" are allowed
        /// </summary>
        public string Engine { get; set; }

        /// <summary>
        /// Search string
        /// e.g. online title search
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// For what we are looking for in SEO
        /// </summary>
        public string Target { get; set; }
    }
}
