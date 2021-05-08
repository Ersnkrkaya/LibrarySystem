using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcKutuphaneUdemy.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcKutuphaneUdemy.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa=1)
        {
            var uye = db.TBLUYELER.ToList().ToPagedList(sayfa,3);
            //var uye = db.TBLUYELER.ToList();
            return View(uye);
        }
        public ActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUye(TBLUYELER p)
        {
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var deger = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var deger = db.TBLUYELER.Find(id);
            return View("UyeGetir", deger);
        }
        public ActionResult Guncelle(TBLUYELER p)
        {
            var deger = db.TBLUYELER.Find(p.ID);
            deger.AD = p.AD;
            deger.SOYAD = p.SOYAD;
            deger.MAIL = p.MAIL;
            deger.KULLANICIADI = p.KULLANICIADI;
            deger.SIFRE = p.SIFRE;
            deger.FOTOGRAF = p.FOTOGRAF;
            deger.TELEFON = p.TELEFON;
            deger.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgcms = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBLUYELER.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.uyegcmss = uyekit;
            return View(ktpgcms);
        }
    }
}