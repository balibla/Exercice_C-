using avisFormations.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avisFormations.WebUi.Controllers
{
    public class TotoController : Controller
    {
        // GET: Toto
        public ActionResult Index()
        {
            MyViewModel mv = new MyViewModel();
            mv.message = "Message dynamique";
            mv.nom = "Fouzia";
            return View(mv);
        }
        public ActionResult Contact()
        {
            MyViewModel cb = new MyViewModel();
            cb.nom = "Message de Fouzia";
            return View(cb);
        }
    }
}