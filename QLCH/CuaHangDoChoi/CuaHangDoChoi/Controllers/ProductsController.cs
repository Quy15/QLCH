using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangDoChoi.Models;

namespace CuaHangDoChoi.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            QLCHEntities db = new QLCHEntities();
            //Lấy ds sản phẩm

            List<Product> pro = db.Products.ToList();
            return View(pro);
        }

        public ActionResult Details(int id)
        {
            QLCHEntities db = new QLCHEntities();
            Product details = db.Products.Find(id);
            return View(details);
        }


    }
}