using proficiencytoday.Models.Business_logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proficiencytoday.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private ProductEntities db = new ProductEntities();
        public ActionResult ViewCart()
        {
            return View();
        }
        public ActionResult AddtoCart(int id)
        {
            List<Product> productList = new List<Product>();
            Product product = db.Products.Find(id);
            if (Session["ProductList"] != null)
            {
                productList = (List<Product>)Session["ProductList"];
                productList.Add(product);
                Session["ProductList"] = productList;
                Session["CartCount"] = productList.Count();
                TempData["MessagetoUser"] = "Productadded Successfully";
            }
            else
            {
             
                productList.Add(product);
                Session["ProductList"] = productList;
                Session["CartCount"] = productList.Count();
                TempData["MessagetoUser"] = "Productadded Successfully";
            }

            return RedirectToAction("ViewCart");
        }
        public ActionResult RemoveCart(int id)
        {
            List<Product> productList = new List<Product>();
            Product product = db.Products.Find(id);
            if (Session["ProductList"] != null)
            {
                productList = (List<Product>)Session["ProductList"];
                var p1 = productList.Find(t => t.ProductId==id);
                productList.Remove(p1);
                Session["ProductList"] = productList;
                Session["CartCount"] = productList.Count();
                TempData["MessagetoUser"] = "Product Removed Successfully";
            }
            else
            {

                productList.Add(product);
                Session["ProductList"] = productList;
                Session["CartCount"] = productList.Count();
                TempData["MessagetoUser"] = "Product Removed Successfully";
            }

            return RedirectToAction("ViewCart");
        }
        //public ActionResult RemoveCart()
        //{
        //    return View();
        //}
    }
}