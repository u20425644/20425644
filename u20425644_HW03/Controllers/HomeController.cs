using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u20425644_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files) //INSIDE HOME
        {
            // Verify that the user selected a file
            // Not null and has a length


            if (files != null && files.ContentLength > 0)
            {
                // extract only the filename
                var RadioButtonSelectected = Request["Media"];
                var fileName = Path.GetFileName(files.FileName);

                if (RadioButtonSelectected == "Document")
                {
                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/App_Data/Media/Documents"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }

                if (RadioButtonSelectected == "Image")
                {
                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/App_Data/Media/Images"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }

                if (RadioButtonSelectected == "Video")
                {
                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/App_Data/Media/Videos"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
            }
            // redirect back to the index action to show the form once again

            return RedirectToAction("Index");
        }

    }
}

