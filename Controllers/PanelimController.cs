using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;
using System.Web.Security;
namespace MvcKutuphaneUdemy.Controllers
{
    public class PanelimController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Panelim
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TBLUYELER p)
        {
            var kullanici = (string)Session["Mail"];//mail session'undan gelen bilgiyi kullanici değişkenine atadık
            var uye = db.TBLUYELER.FirstOrDefault(x=>x.MAIL==kullanici);//kullanıcının id'sini aldık
            uye.SIFRE = p.SIFRE;//uyenin sifre,ad, fotograf vb. bilgilerini TBLUYELER'den gelen p parametresiyle eşleştirip güncelledik
            uye.AD = p.AD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return View();
        }
        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];//sessionda ki oturumu kullanıcı değişkenine atadık
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z=>z.ID).FirstOrDefault();//üyeler tablosunda mail adresi kullanıcı olan kişinin id'sini çektik
            var hareket = db.TBLHAREKET.Where(x => x.UYE==id).ToList();//id'si belirli kişinin hareket tablosundan geçmiş kitaplarını aldık
            return View(hareket);
        }
       
    }
}