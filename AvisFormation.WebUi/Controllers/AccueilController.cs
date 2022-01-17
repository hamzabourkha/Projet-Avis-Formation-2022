using AvisFormation.Data;
using AvisFormation.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvisFormation.WebUi.Controllers
{
    public class AccueilController : Controller
    {
        public ActionResult Index()
        {
            var listDesFormations=new List<Formation>();
            var listAVM = new List<AccueilViewModel>();
            using (var context = new AvisFormationDbEntities())
            {
                listDesFormations = context.Formations.OrderBy(f=>Guid.NewGuid()).Take(4).ToList();
                foreach (var f in listDesFormations)
                {
                    var avm = new AccueilViewModel();
                    avm.Id = f.Id;
                    avm.Nom = f.Nom;
                    avm.Url = f.Url;
                    avm.Description = f.Description;
                    avm.NomSeo = f.NomSeo;
                    if (f.Avis.Count > 0)
                    {
                        avm.Note = Math.Round(f.Avis.Average(a => a.Note),2);
                        avm.NombreAvis = f.Avis.Count;
                    }
                    else
                    {
                        avm.Note = 0;
                        avm.NombreAvis = 0;
                    }
                    listAVM.Add(avm);
                }

            }
            return View(listAVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}