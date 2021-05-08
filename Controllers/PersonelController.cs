using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;
namespace MvcKutuphaneUdemy.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var personel = db.TBLPERSONEL.ToList();
            return View(personel);
        }
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonel(TBLPERSONEL p)
        {
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var deger = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var deger = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", deger);
        }
        public ActionResult Guncelle(TBLPERSONEL p)
        {
            var deger = db.TBLPERSONEL.Find(p.ID);
            deger.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}