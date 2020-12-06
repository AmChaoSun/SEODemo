using SEODemo.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEODemo.Data.Repositories
{
    public class SEORepository : Repository<SEOResult>, ISEORepository
    {
        public SEORepository(SEOContext context) : base(context) { }
        
        //Currenly no other methods
    }
}
