using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category


        DbAcunMedyaAkedemiPortfolioEntities db = new DbAcunMedyaAkedemiPortfolioEntities();
        public ActionResult Index()
        {
            
            var values = db.TblCategories.ToList();
            return View(values);
        }

        [HttpGet]//Yüklendiği anda bize sadece view göster.
        public ActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]//Dışarıdan bir model alması lazım
        public ActionResult AddCategory(TblCategory model)
        {
            db.TblCategories.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = db.TblCategories.Find(id);
            db.TblCategories.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]//Güncelle butonuna bastığımız zaman Get methodu tetiklenir.
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategories.Find(id);
            return View(value);

        }
        [HttpPost] 
        public ActionResult UpdateCategory(TblCategory model)
        {
            var value = db.TblCategories.Find(model.CategoryId);
            value.CategoryName = model.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");

            

        }
        
        

        

    }
}