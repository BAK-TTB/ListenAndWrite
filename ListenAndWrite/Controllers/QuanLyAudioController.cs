using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListenAndWrite.Models;
using PagedList;
using PagedList.Mvc;

namespace ListenAndWrite.Controllers
{
    public class QuanLyAudioController : Controller
    {
        // GET: QuanLyAudio
        QuanLyAudioEntities db = new QuanLyAudioEntities();
        public ActionResult Index(int? page)
        {
            List<audio> audio = db.audios.ToList();
            int pageNumber = (page ?? 1);
            int pageSize = audio.Count;
            return View(db.audios.ToList().OrderBy(n => n.idAudio).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dữ liệu vào dropdownlist
            ViewBag.idChuDe = new SelectList(db.chudes.ToList().OrderBy(n => n.chuDe), "idChuDe", "chuDe");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(audio audio, HttpPostedFileBase fileUpload)
        {
            //Đưa dữ liệu vào dropdownlist
            ViewBag.idChuDe = new SelectList(db.chudes.ToList().OrderBy(n => n.chuDe), "idChuDe", "chuDe");
            //kiểm tra đường dẫn url
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn File";
                return View();
            }
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/fileAudio"), fileName);
                //Kiểm tra file đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "File đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                audio.url = fileUpload.FileName;
                db.audios.Add(audio);
                db.SaveChanges();
            }
           
            return View();
        }

        //Chỉnh sửa audio
        [HttpGet]
        public ActionResult ChinhSua(int idAudio)
        {
            //Lấy ra đối tượng audio theo mã 
            audio audio = db.audios.SingleOrDefault(n => n.idAudio == idAudio);
            if (audio == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.idChuDe = new SelectList(db.chudes.ToList().OrderBy(n => n.idChuDe), "idChuDe", "chuDe", audio.idChuDe);
            return View(audio);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(audio audio, FormCollection f)
        {
            //Sach sach1 = db.Saches.SingleOrDefault(n => n.MaSach == sach.MaSach);
            //sach1.MoTa = sach.MoTa;
            //sach1.MoTa = f.Get("abc").ToString();
            //sach.MoTa = f["abc"].ToString();
            //db.SaveChanges();

            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(audio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.idChuDe = new SelectList(db.chudes.ToList().OrderBy(n => n.idChuDe), "idChuDe", "chuDe", audio.idChuDe);

            return RedirectToAction("Index");
        }
        //Hiển thị audio
        public ActionResult HienThi(int idAudio)
        {
            //Lấy ra đối tượng audio theo mã 
            audio audio = db.audios.SingleOrDefault(n => n.idAudio == idAudio);
            if (audio == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(audio);
        }
        //Xóa audio
        [HttpGet]
        public ActionResult Xoa(int idAudio)
        {
            //Lấy ra đối tượng audio theo mã 
            audio audio = db.audios.SingleOrDefault(n => n.idAudio == idAudio);
            if (audio == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(audio);
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa(int idAudio)
        {
            audio audio = db.audios.SingleOrDefault(n => n.idAudio == idAudio);
            if (audio == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.audios.Remove(audio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET chude
        public PartialViewResult ChuDePartial()
        {
            return PartialView(db.chudes.ToList());
        }

        //Thêm chủ đề
        [HttpGet]
        public ActionResult ThemMoiChuDe()
        {
            return View();
        }

        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult ThemMoiChuDe(chude cd)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                db.chudes.Add(cd);
                db.SaveChanges();
            }

            return View();
        }

        //Chỉnh sửa chude
        [HttpGet]
        public ActionResult ChinhSuaChuDe(int idChuDe)
        {
            //Lấy ra đối tượng audio theo mã 
            chude cd = db.chudes.SingleOrDefault(n => n.idChuDe == idChuDe);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            return View(cd);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSuaChuDe(chude cd, FormCollection f)
        {
            //Sach sach1 = db.Saches.SingleOrDefault(n => n.MaSach == sach.MaSach);
            //sach1.MoTa = sach.MoTa;
            //sach1.MoTa = f.Get("abc").ToString();
            //sach.MoTa = f["abc"].ToString();
            //db.SaveChanges();

            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(cd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        //Xóa chude
        [HttpGet]
        public ActionResult XoaChuDe(int idChuDe)
        {
            //Lấy ra đối tượng audio theo mã 
            chude cd = db.chudes.SingleOrDefault(n => n.idChuDe == idChuDe);
            //audio a = db.audios.SingleOrDefault(n => n.idChuDe == idChuDe);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(cd);
        }
        [HttpPost, ActionName("XoaChuDe")]

        public ActionResult XacNhanXoaChuDe(int idChuDe)
        {
            chude cd = db.chudes.SingleOrDefault(n => n.idChuDe == idChuDe);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var au = db.audios.Where(n => n.idChuDe == idChuDe).ToList();
            foreach (var n in au)
            {
                db.audios.Remove(n);
            }
            db.chudes.Remove(cd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}