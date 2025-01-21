using AcunmedyaAkademiPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AcunmedyaAkademiPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        DbAcunMedyaAkedemiPortfolioEntities db = new DbAcunMedyaAkedemiPortfolioEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultBanner()
        {
            var values = db.TblBanners.ToList();

            return PartialView(values);
        }
        public PartialViewResult DefaultAbout()
        {
            //Burası yapılacak
            var birthday = db.TblAbouts.Select(x => x.Birthday).FirstOrDefault();

            ViewBag.Birthday = birthday;
            var city = db.TblAbouts.Select(x => x.City).FirstOrDefault().ToString();
            ViewBag.City = city;
            var degree = db.TblAbouts.Select(x => x.Degree).FirstOrDefault().ToString();
            ViewBag.Degree = degree;
            var age = db.TblAbouts.Select(x => x.Age).FirstOrDefault().ToString();
            ViewBag.Age = age;
            var phoneNumber = db.TblAbouts.Select(x => x.PhoneNumber).FirstOrDefault().ToString();
            ViewBag.PhoneNumber = phoneNumber;
            var email = db.TblAbouts.Select(x => x.Email).FirstOrDefault().ToString();
            ViewBag.Email = email;



            return PartialView();
        }
        public PartialViewResult DefaultStatistics()
        {
            ViewBag.projectCount = db.TblProjects.Count();
            ViewBag.skillCount=db.TblSkills.Count();
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessage model)
        {
            model.IsRead = false;
            db.TblMessages.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public PartialViewResult DefaultSkills()
        {
            var tablo = db.TblSkills.ToList();
            return PartialView(tablo);
        }
        public PartialViewResult DefaultResume()
        {
            var table = db.TblExperiences.ToList();
            return PartialView(table);
        }
        public PartialViewResult DefaultTestimonials()
        {
            var table = db.TblTestimonials.ToList();
            return PartialView(table);
        }
        public PartialViewResult DefaultContact()
        {
            var table = db.TblContacts.ToList();
            return PartialView(table);
            
        }
    }
}