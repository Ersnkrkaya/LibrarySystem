using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;
using MvcKutuphaneUdemy.Models.Siniflarim;
namespace MvcKutuphaneUdemy.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        Class1 cs = new Class1();
        [HttpGet]
        public ActionResult Index()
        {
            cs.Deger1 = db.TBLKITAP.ToList();
            cs.Deger2 = db.TBLHAKKIMIZDA.ToList();
            //var kitap = db.TBLKITAP.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}