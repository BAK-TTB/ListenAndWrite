using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListenAndWrite.Models;
using PagedList;
using PagedList.Mvc;

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

        public PartialViewResult TrangChuPartial(int? page)
        {
            //Tao ra một biến là số chủ đề trên trang
            int pageSize = 2;
            //Tao bien so trang
            int pageNumber = (page ?? 1);
            var listChuDe = db.chudes.ToList().OrderBy(n => n.levels).ToPagedList(pageNumber, pageSize);
            return PartialView(listChuDe);
        }
    }
}