using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;
namespace MvcKutuphaneUdemy.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Kayit()
        {
            return View();
        }
    }
}