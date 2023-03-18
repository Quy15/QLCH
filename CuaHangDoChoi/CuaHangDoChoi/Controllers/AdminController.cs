using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangDoChoi.Models;

namespace CuaHangDoChoi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminIndex()
        {
            QLCHEntities db = new QLCHEntities();
            return View(db.Products.ToList());
        }

        public ActionResult LogoutAdmin()
        {
            Session.Clear();
            return RedirectToAction("Login", "Products");
        }

        public ActionResult ProductsManager()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult ProductsManager(Product prod, string tinhTrang)
        {
            //lưu dữ liệu
            if (string.IsNullOrEmpty(prod.tenSP) == true)
            {
               ViewBag.Error =  "Tên sản phẩm không được để trống";
                return View();
            }
            if (prod.giaBan < 1000)
            {
                ViewBag.Error = "Giá bán không được bé hơn 1000 đồng";
                return View();
            }

            QLCHEntities db = new QLCHEntities();
            prod.setTT(tinhTrang);
            db.Products.Add(prod);
            db.SaveChanges();
            ViewBag.Noti = "Thêm sản phẩm thành công";
            return View();
        }
    }
}