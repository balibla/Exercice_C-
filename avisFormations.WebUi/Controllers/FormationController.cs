using AvisFormation.Data;
using avisFormations.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace avisFormations.WebUi.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        public ActionResult ToutesLesFormations()
        {
            
            var listFormation = new List<Formation>();
            using (var contexte = new AvisEntitis())
            {
                 listFormation = contexte.Formation.ToList();
            }
            
            
            return View(listFormation);
        }

        public ActionResult DetailsFormation(string nSeo = "none")
        {
            var formation = new Formation();
            ViewFormationAvisModel vm = new ViewFormationAvisModel();
            using (var context = new AvisEntitis())
            {
                formation = context.Formation.Where(f => f.NomSeo == nSeo).FirstOrDefault();
                if (formation == null)
                {
                    RedirectToAction("index", "Home");
                }
                else
                {
                    vm.id = formation.Id;
                    vm.nom = formation.Nom;
                    vm.url = formation.Url;
                    vm.description = formation.Description;
                    vm.nomseo = formation.NomSeo;
                    vm.nombreAvis = formation.Avis.Count;
                    if (formation.Avis.Count > 0)
                    {
                        vm.noteFormation = formation.Avis.Average(f => f.Note);
                    }
                    else
                    {
                        vm.noteFormation = 0;
                    }

                    vm.avis = formation.Avis.ToList();

                }
            }
            return View(vm);
        }
    }
}