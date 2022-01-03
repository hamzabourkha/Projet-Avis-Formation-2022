using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvisFormation.Data;
using AvisFormation.WebUi.Models;

namespace AvisFormation.WebUi.Controllers
{
    public class AvisController : Controller
    {
        // GET: Avis
        public ActionResult AjouterUnAvis(string nomSeo)
        {
            var vm = new AjouterUnAvisViewModel();
            using (var context = new AvisFormationDbEntities())
            {
                var formation = context.Formations.Where(f => f.NomSeo == nomSeo).FirstOrDefault();
                if (formation == null) return RedirectToAction("ToutesLesFormations", "Formation");
                vm.FormationSeo = formation.NomSeo;
                vm.FormationName = formation.Nom;
            }
                return View(vm);
        }

        [HttpPost]
        public ActionResult EnregistrerAvis(Commentaire c)
        {
            using(var context= new AvisFormationDbEntities())
            {
                var formationEntity = context.Formations.Where(f => f.NomSeo == c.nomSeo).FirstOrDefault();
                Avi a = new Avi();
                a.Nom = c.nom;
                a.Description = c.avis;
                a.UserId = "0";
                double dnote=0;
                if(!Double.TryParse(c.note,out dnote)){
                    throw new Exception("Valeur non convertible!");
                }
                a.Note = dnote;
                a.DateAvis = DateTime.Now;
                a.IdFormation = formationEntity.Id;
                context.Avis.Add(a);
                context.SaveChanges();
            }
            return RedirectToRoute("detailsformations", new {nomSeo=c.nomSeo });
        }
    }
}