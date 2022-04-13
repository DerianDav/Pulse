using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Pulse.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var imgCtx = new DBContext.ImageContext();
            List<Models.ImageModel> images = imgCtx.Image.ToList();
            return View(images);
        }

        public int ImageUpload(Models.ImageModelHTTP image)
        {
            System.Diagnostics.Debug.WriteLine("start upload");
            var file = image.ImageFile;
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                string fileNameNoEx = Path.GetFileNameWithoutExtension(file.FileName);

                if (fileNameNoEx.Length > 100)
                    return 2;

                Stream fileStream = file.InputStream;
                BinaryReader br = new BinaryReader(fileStream);
                byte[] imageArray = br.ReadBytes((Int32) fileStream.Length);

                if (imageArray.Length > 5 * 1024 * 1024)
                    return 3;

                string b64Image = Convert.ToBase64String(imageArray);
                string dateConverted = DateTime.Now.ToString();
                var imgCtx = new DBContext.ImageContext();
                imgCtx.Image.Add(new Models.ImageModel { Id = 1, Title = fileNameNoEx, ImageText = b64Image, DateConverted = dateConverted });
                imgCtx.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Uploaded Image");
                return 0;

            }
            System.Diagnostics.Debug.WriteLine("file is null");
            return 1;
        }
        
    }
}