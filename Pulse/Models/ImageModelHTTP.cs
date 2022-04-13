using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pulse.Models
{
    public class ImageModelHTTP
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageText { get; set; }
        public string DateConverted { get; set; }
        public bool isSelected { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
    }
}