using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListenAndWrite.Models;

namespace ListenAndWrite.Controllers
{
    public class AudioController : Controller
    {
        // GET: Audio
        QuanLyAudioEntities db = new QuanLyAudioEntities();

        public ViewResult XemChiTiet(int id = 0)
        {
            Audio audio = db.Audios.SingleOrDefault(n => n.id == id);
            if(audio == null)
            {
                //Tra ve trang bao loi
                Response.StatusCode = 404;
                return null;
            }
            return View(audio);
        }

        public ViewResult ListenFullMore(int id = 0)
        {
            Audio audio = db.Audios.SingleOrDefault(n => n.id == id);
            if (audio == null)
            {
                //Tra ve trang bao loi
                Response.StatusCode = 404;
                return null;
            }
            return View(audio);
        }

        public ViewResult ListenNewMore(int id = 0)
        {
            Audio audio = db.Audios.SingleOrDefault(n => n.id == id);
            if (audio == null)
            {
                //Tra ve trang bao loi
                Response.StatusCode = 404;
                return null;
            }
            return View(audio);
        }
    }
}