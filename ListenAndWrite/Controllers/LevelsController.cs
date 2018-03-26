using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListenAndWrite.Models;

namespace ListenAndWrite.Controllers
{
    public class LevelsController : Controller
    {
        // GET: Levels
        QuanLyAudioEntities db = new QuanLyAudioEntities();

        public ActionResult Levels()
        {
            return View(db.Audios.ToList());
        }
    }
}