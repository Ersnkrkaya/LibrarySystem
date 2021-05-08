using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;

namespace MvcKutuphaneUdemy.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();//sessiondan gelen bilgiler uyemail değişkenine aktarılır
            var mesajlar = db.TBLMESAJLAR.Where(x=>x.ALICI==uyemail.ToString()).ToList();//mesajlar tablosunda alıcı sütununda kişinin mesajları bulunur. Mesajlar tablosunda
            // alıcısı sessiondan gelen uyemail değişkeni olan kişinin bilgisi çekilir ve ekrana basılır.
            return View(mesajlar);
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();// sessiondan gelen bilgiler uyemail değişkenine aktarılır
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();//Mesajlar tablosunda ki gönderen sütununda gönderenin uyemail değişkeninde ki kişinin olduğu tabloları getir
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR p)
        {

            var uyemail = (string)Session["Mail"].ToString();// sessiondan gelen bilgiler uyemail değişkenine aktarılır
            p.GONDEREN= uyemail.ToString();//TBLMESAJLAR tablosunda ki p parametresinden aldığımız gönderen bilgisini sessiondan aldığımız bilgiyle eşleştiriyoruz
            p.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());//gönderim tarihi anlık tarih
            db.TBLMESAJLAR.Add(p);//TBLMESAJLAR tablosuna p parametresinden gelen verileri ekle
            db.SaveChanges();//değişikleri kaydet
            return RedirectToAction("Giden","Mesajlar");// Mesaj gönderildikten sonra Giden Tablosunda ki Mesajlar Controllerına yönlendir
        }

    }
}