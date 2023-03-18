using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangDoChoi.Models;
using PagedList;

namespace CuaHangDoChoi.Controllers
{
    
    public class ProductsController : Controller
    {
        
        // GET: Products
        public ActionResult Index(string searchString = "")
        {
             QLCHEntities db = new QLCHEntities();
            //Lấy ds sản phẩm

            //List<Product> pro = db.Products.ToList();
            var pro = from p in db.Products select p;


            if (searchString != "")
            {
                var find = db.Products.Where(p => p.tenSP.ToUpper().Contains(searchString.ToUpper()));
                return View(find.ToList());
            }
            else
            {
                Product prod = new Product();
                Session["idSP"] = prod.id.ToString();
                ViewBag.Message = "Không tìm thấy sản phẩm này";
            }
            return View(pro.ToList());
        }

        public ActionResult Details(int id)
        {
            QLCHEntities db = new QLCHEntities();
            Product details = db.Products.Find(id);
            return View(details);
        }
    }
}