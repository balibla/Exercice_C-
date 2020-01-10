using AvisFormation.Data;
using AvisFormation.logique;
using avisFormations.WebUi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avisFormations.WebUi.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis

           [Authorize]
        public ActionResult LaisserUnAvis(String nSeo)
        {
            LaisserUnAvisViewModel vm = new LaisserUnAvisViewModel();

            vm.formationNseo = nSeo;
            using (var context = new AvisEntitis())
            {
                var formation = context.Formation.FirstOrDefault(f => f.NomSeo == nSeo);
                if (formation == null)
                {
                    RedirectToAction("ToutesLesFormations", "Formation");
                }

                vm.formationName = formation.Nom;
            }
            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult SaveComment(string name, string note, string description, string nSeo)
        {
            PersonManager mgr = new PersonManager();
            string user_id = User.Identity.GetUserId();

            Avis nouveAvis = new Avis();
            nouveAvis.DateAvis = DateTime.Now;
            nouveAvis.Description = description;
            nouveAvis.Nom = name;
            nouveAvis.UserId = "";
            //
            double dNote = 0;
            if (!double.TryParse(note, out dNote))
            {
                throw new Exception("Parse Invalid");
            }
            else
            {
                nouveAvis.Note = dNote;
            }

            using (var context = new AvisEntitis())
            {
                var formation = context.Formation.FirstOrDefault(f => f.NomSeo == nSeo);
                nouveAvis.IdFormation = formation.Id;
                nouveAvis.Nom = mgr.GetNameByUserId(user_id);
                PersonManager mngr = new PersonManager();
                if (mngr.IsExiste(User.Identity.GetUserId(), nouveAvis.IdFormation) == false)
                {
                    context.Avis.Add(nouveAvis);
                    context.SaveChanges();
                }

                   
            }

            /// RedirectToAction("DetailsFormation", "Formations", new { nSeo = nSeo });

            return RedirectToAction("DetailsFormation", "Formation", new { nSeo = nSeo });

        }
        public ActionResult Test(String nSeo=null)
        {
            return View();
        }


    }
}