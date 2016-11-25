using game1.Models;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace game1.Controllers
{
    public class HelloWorldController : Controller
    {
        TelemetryClient tc = new TelemetryClient();
        // 
        // GET: /HelloWorld/

        [HttpPost]
        public ActionResult Index(string userName, int count)
        {
            FaceInfo fi = new FaceInfo();
            fi.Name = userName;
            fi.FaceCount = count;
            return RedirectToAction("Welcome",fi);
        }
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult About()
        {

            return View();
        }
        // 
        // GET: /HelloWorld/Welcome/ 

        //public string Welcome(string name, int ID = 1)
        //{
        //    tc.TrackEvent("welcome");
        //    return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        //}
        public ActionResult Welcome(FaceInfo fi)
        {
            tc.TrackEvent("Generating....");
            ViewData["Message"] = "Hello " + fi.Name;
            ViewData["FaceCount"] = fi.FaceCount;
            List<String> faces = DrawingHelper.Draw(fi.FaceCount).Select(t => t.ToString()).ToList();
            return View(faces);
        }
    }
}
