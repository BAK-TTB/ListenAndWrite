using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListenAndWrite.Models;

namespace ListenAndWrite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLyAudioEntities db = new QuanLyAudioEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult TrangChuPartial()
        {
            var listAudio = db.Audios.ToList();
            return PartialView(listAudio);
        }
    }
}