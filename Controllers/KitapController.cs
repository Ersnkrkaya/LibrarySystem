using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;
namespace MvcKutuphaneUdemy.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(string p)//Verilerin geldiği ActionResult'a bir parametre eklenir string tipinde 
        {
            var kitaplar = from k in db.TBLKITAP select k; // Sağ-> db de ki TBLKITAP tablosunda ki veriler seçilir ve bu veriler k değişkenine aktarılır. K değişkeni de
            //kitaplar değişkenine aktarılar.
            if (!string.IsNullOrEmpty(p))//gelen p parametresinin içi boş değilse 
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));// p değişkeninden gelen değer kitaplar tablosunda contains methoduyla AD sütununda ki değerle search edilir
            }
            //var kitaplar = db.TBLKITAP.ToList();
            
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List <SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()//TBLKATEGORI tablosundan gelen verileri listeleyerek i değişkenine aktar
                                            select new SelectListItem// hangi sütunların gelmesini istiyorsak seçiyoruz
                                            {
                                                Text=i.AD,// dropdown'un text'ine i.AD
                                                Value=i.ID.ToString()// value'sine ID bilgisinin gelmesini istiyoruz
                                            }).ToList();// gelen verileri listeliyoruz ve LİST methoduyla deger1 değişkenine aktarıyoruz
            ViewBag.dgr1=deger1;// Bir viewbag oluşturup dgr1 adını veriyoruz. Deger1 değişkeninden glene bilgileri buraya aktarıyoruz
            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD +' '+ i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            p.TBLYAZAR = yzr;
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                                                  select new SelectListItem
                                                                  {
                                                                      Text = i.AD + ' ' + i.SOYAD,
                                                                      Value = i.ID.ToString()
                                                                  }).ToList();
            ViewBag.dgr2 = deger2;
            var kitap = db.TBLKITAP.Find(id);
            return View("KitapGetir", kitap);
        }
        public ActionResult KitapGuncelle(TBLKITAP p)
        {
            var kitap = db.TBLKITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            kitap.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}