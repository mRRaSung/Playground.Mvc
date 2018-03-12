using Playground.Enums;
using System;
using System.IO;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Playground.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if(file != null)
            {
                if(file.ContentLength > 0)
                {
                    ViewBag.FileName = file.FileName;

                    string savedName = Path.Combine(Server.MapPath("~/files"), file.FileName);

                    file.SaveAs(savedName);
                }
            }

            return View();
        }

        public ActionResult GetImage(ImageAction imageaction)
        {
            WebImage image = new WebImage(Server.MapPath("~/files/pancake.jpg"));

            switch (imageaction)
            {
                case ImageAction.Resize:
                    image = image.Resize(100, 100);
                    break;
                case ImageAction.FlipV:
                    image = image.FlipVertical();
                    break;
                case ImageAction.FlipH:
                    image = image.FlipHorizontal();
                    break;
                case ImageAction.WatermarkTxt:
                    image = image.AddTextWatermark("我是浮水印的拉", "#fff");
                    break;
                case ImageAction.WatermarkTxt2:
                    image = image.AddTextWatermark("我是浮水印的拉", "red", 24);
                    break;
                case ImageAction.WatermarkImg:
                    image = image.AddImageWatermark("~/files/guitar.jpg");
                    break;
                case ImageAction.Crop1:
                    image = image.Crop(0, 41, 0, 0);
                    break;
                case ImageAction.Crop2:
                    image = image.Crop(0, 0, 0, 180);
                    break;
                case ImageAction.Crop3:
                    image = image.Crop(10, 0, 10, 0);
                    break;
                default:
                    throw new ArgumentException("尚未實作");
            }

            return File(image.GetBytes(), "image/jpg");
        }
    }
}