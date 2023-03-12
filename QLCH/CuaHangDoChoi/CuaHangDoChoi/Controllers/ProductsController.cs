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


        public JsonResult GetSearchData(string searchBy, string searchValue)
        {
            QLCHEntities db = new QLCHEntities();
            List<Product> prod = new List<Product>();
            if (searchBy == "Tên sản phẩm")
            {
                try
                {
                    string tenSP = searchValue;
                    prod = db.Products.Where(x => x.tenSP.Contains(tenSP) || searchValue == null).ToList();
                }
                catch(FormatException)
                {
                    Console.WriteLine("Không có sản phẩm này");
                }
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
            else
            {
                prod = db.Products.Where(x => x.giaBan.Equals(searchValue) || searchValue == null).ToList();
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
        }

    }
}