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
    public class AudioController : Controller
    {
        // GET: Audio
        QuanLyAudioEntities db = new QuanLyAudioEntities();

        public ViewResult XemChiTiet(int id = 0)
        {
           chude chude = db.chudes.SingleOrDefault(n => n.idChuDe == id);
            if(chude == null)
            {
                //Tra ve trang bao loi
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }

        public ViewResult ListenFullMore(int id = 0, int? track = 1)
        {
            //kiểm tra chủ đề có tồn tại hay không
            chude cd = db.chudes.SingleOrDefault(n => n.idChuDe == id);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            int pageSize = 1;
            //Tao bien so trang
            int pageNumber = (track ?? 1);
            var lstAudio = db.audios.ToList().Where(n => n.idChuDe == id).OrderBy(n => n.idAudio).ToPagedList(pageNumber, pageSize);
            if (lstAudio.Count == 0)
            {
                //ViewBag là kiểu dữ liệu động, có thể gán được nhiều tham số, có thể là list, string, ..., dùng để truyền dữ liệu từ controller sang view
                ViewBag.audio = "Không có audio thuộc chủ đề này";
            }
            return View(lstAudio);
        }

        public ViewResult ListenNewMore(int id = 0, int? track =1)
        {
            chude cd = db.chudes.SingleOrDefault(n => n.idChuDe == id);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            int pageSize = 1;
            //Tao bien so trang
            int pageNumber = (track ?? 1);
            var lstAudio = db.audios.ToList().Where(n => n.idChuDe == id).OrderBy(n => n.idAudio).ToPagedList(pageNumber, pageSize);
            if (lstAudio.Count == 0)
            {
                //ViewBag là kiểu dữ liệu động, có thể gán được nhiều tham số, có thể là list, string, ..., dùng để truyền dữ liệu từ controller sang view
                ViewBag.audio = "Không có audio thuộc chủ đề này";
            }
            return View(lstAudio);
        }
    }
}