using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEODemo.Data
{
    public class SEOContext : DbContext
    {
        public SEOContext(DbContextOptions<SEOContext> options)
        : base(options) { }

        public DbSet<Models.SEOResult> SEOResults { get; set; }
    }
}
