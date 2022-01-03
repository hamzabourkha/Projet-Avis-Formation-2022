using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvisFormation.Data;
using AvisFormation.WebUi.Models;

namespace AvisFormation.WebUi.Controllers
{
    public class FormationController : Controller
    {
        // GET: Formation
        
        public ActionResult ListeDesFormations()
        {
            var listDesFormations = new List<Formation>();
            var listAVM = new List<AccueilViewModel>();
            using (var context = new AvisFormationDbEntities())
            {
                listDesFormations = context.Formations.ToList();
                foreach(var f in listDesFormations)
                {
                    var avm = new AccueilViewModel();
                    avm.Id = f.Id;
                    avm.Nom = f.Nom;
                    avm.Url = f.Url;
                    avm.Description = f.Description;
                    avm.NomSeo = f.NomSeo;
                    if (f.Avis.Count > 0)
                    {
                        avm.Note = f.Avis.Average(a => a.Note);
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

            
        
        
        
        public ActionResult ToutesLesFormations()
        {
            var listFormations = new List<Formation>();
            var listVM = new List<FormationAvecAvisViewModel>();
            using (var context = new AvisFormationDbEntities())
            {
                listFormations = context.Formations.ToList();
                foreach (var formationEntity in listFormations)
                {
                    var vm = new FormationAvecAvisViewModel();
                    vm.Nom = formationEntity.Nom;
                    vm.Id = formationEntity.Id;
                    vm.Url = formationEntity.Url;
                    vm.Description = formationEntity.Description;
                    vm.NomSeo = formationEntity.NomSeo;

                    if (formationEntity.Avis.Count > 0)
                    {
                        vm.Note = Math.Round(formationEntity.Avis.Average(a => a.Note),2);
                        vm.NombreAvis = formationEntity.Avis.Count;
                    }
                    else
                    {
                        vm.Note = 0;
                        vm.NombreAvis = 0;
                    }
                    vm.Avis = formationEntity.Avis.ToList();
                    listVM.Add(vm);

                }

            }
            
            

            return View(listVM);
        }
        public ActionResult DetailsFormations(string nomSeo)
        {
            var vm = new FormationAvecAvisViewModel();
            var formationEntity = new Formation();
            using (var context = new AvisFormationDbEntities())
            {
                formationEntity = context.Formations.Where(f => f.NomSeo == nomSeo).FirstOrDefault();
                if (formationEntity == null)
                    return RedirectToAction("Index", "Home");
                vm.Nom = formationEntity.Nom;
                vm.Id = formationEntity.Id;
                vm.Url = formationEntity.Url;
                vm.Description = formationEntity.Description;
                vm.NomSeo = formationEntity.NomSeo;

                if (formationEntity.Avis.Count > 0)
                {
                    vm.Note = Math.Round(formationEntity.Avis.Average(a => a.Note),2);
                    vm.NombreAvis = formationEntity.Avis.Count;
                }
                else
                {
                    vm.Note = 0;
                    vm.NombreAvis = 0;
                }
                vm.Avis = formationEntity.Avis.ToList();
            }
            return View(vm);
        }
    }

    
}