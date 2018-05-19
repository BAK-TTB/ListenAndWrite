using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListenAndWrite.Models;
using PagedList.Mvc;
using PagedList;

namespace ListenAndWrite.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QuanLyAudioEntities db = new QuanLyAudioEntities();

        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page = 1)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<audio> lstKQTK = db.audios.Where(n => n.name.Contains(sTuKhoa)).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 7;
            if(lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả nào!";
                return View(db.audios.OrderBy(n => n.idAudio).ToPagedList(pageNumber, pageSize));
            }

            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.idAudio).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<audio> lstKQTK = db.audios.Where(n => n.name.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy kết quả nào";
                return View(db.audios.OrderBy(n => n.idAudio).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.idAudio).ToPagedList(pageNumber, pageSize));
        }
    }
}