using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;
namespace MvcKutuphaneUdemy.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORI.Where(x=>x.DURUM==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var deger = db.TBLKATEGORI.Find(id);
            //db.TBLKATEGORI.Remove(deger);
            deger.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var deger = db.TBLKATEGORI.Find(id);
            return View("KategoriGetir", deger);
        }
        public ActionResult Guncelle(TBLKATEGORI p)
        {
            var deger = db.TBLKATEGORI.Find(p.ID);
            deger.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}