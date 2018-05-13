using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ListenAndWrite.Models;
using PagedList;
using PagedList.Mvc;

namespace ListenAndWrite.Controllers
{
    public class LevelsController : Controller
    {
        // GET: Levels
        QuanLyAudioEntities db = new QuanLyAudioEntities();

        public ViewResult Levels(int level = 1, int? page = 1)
        {
            //Tao ra một biến là số chủ đề trên trang
            int pageSize = 1;
            //Tao bien so trang
            int pageNumber = (page ?? 1);
            var listLevels = db.chudes.ToList().Where(cd => cd.levels == level).OrderBy(n => n.levels).ToPagedList(pageNumber, pageSize);
            return View(listLevels);
        }

        public PartialViewResult NumberPartial()
        {
            return PartialView(db.chudes.OrderBy(n => n.levels).ToList());
        }

    }
}