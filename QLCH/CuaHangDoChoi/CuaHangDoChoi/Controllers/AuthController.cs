using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangDoChoi.Models;
using System.Security.Cryptography;
using System.Web.Helpers;

namespace CuaHangDoChoi.Controllers
{
    public class AuthController : Controller
    {
        QLCHEntities db = new QLCHEntities();

        // GET: Auth
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            if (db.Customers.Any(x => x.taiKhoan == cust.taiKhoan))
            {
                ViewBag.Notification = "Tài khoản này đã được sử dụng";
                return View();
            }
            else
            {
                cust.xacNhan = cust.matKhau;
                db.Customers.Add(cust);
                db.SaveChanges();
                ViewBag.Message = cust.taiKhoan + " được tạo thành công";
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer user)
        {
            var usr = db.Customers.Where(u => u.taiKhoan.Equals(user.taiKhoan) && u.matKhau.Equals(user.matKhau)).FirstOrDefault();
            if (usr != null)
            {
                Session["idUser"] = user.id.ToString();
                Session["taiKhoan"] = user.taiKhoan.ToString();
                return RedirectToAction("Index", "Products");
            }
            else
            {
                ViewBag.Message = "Tài khoản hoặc mật khẩu sai";
            }
            return View();
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}