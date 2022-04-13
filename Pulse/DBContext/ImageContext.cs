using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Pulse.DBContext
{
    public class ImageContext: DbContext
    {
        public ImageContext() 
        {


       }

        public DbSet<Models.ImageModel> Image { get; set; }
    }
}