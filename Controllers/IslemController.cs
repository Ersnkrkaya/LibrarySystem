using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphaneUdemy.Models.Entity;
namespace MvcKutuphaneUdemy.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var hareket = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(hareket);
        }
    }
}