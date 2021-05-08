using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;
using System.Web.Security;
namespace MvcKutuphaneUdemy.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                //TempData["ad"] = bilgiler.AD.ToString();
                //TempData["soyad"] = bilgiler.SOYAD.ToString();
                //TempData["kullaniciadi"] = bilgiler.KULLANICIADI.ToString();
                //TempData["sifre"] = bilgiler.SIFRE.ToString();
                //TempData["okul"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index","Panelim");
            }
            else { 
                return View();
            }
        }
    }
}