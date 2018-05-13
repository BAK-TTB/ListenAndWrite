using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListenAndWrite.Models;

namespace ListenAndWrite.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        QuanLyAudioEntities db = new QuanLyAudioEntities();

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult DangKy(user us)
        {
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu vào bảng khách hàng
                db.users.Add(us);
                //Lưu vào csdl 
                db.SaveChanges();
            }
            return RedirectToAction("DangNhap"); 
        }

        [HttpGet]
        public ActionResult DangNhap()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            user u = db.users.SingleOrDefault(n => n.Email == sTaiKhoan && n.Password == sMatKhau);
            if (u != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công !";
                Session["TaiKhoan"] = u;
                return RedirectToAction("../");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        }

        public ActionResult DangXuat()
        {
            Session.Clear();
            // or Session["TaiKhoan"] = null;
            return RedirectToAction("../");
        }
    }
}