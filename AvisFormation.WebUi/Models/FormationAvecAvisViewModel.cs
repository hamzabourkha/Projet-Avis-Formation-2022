using AvisFormation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisFormation.WebUi.Models
{
    public class FormationAvecAvisViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string NomSeo { get; set; }
        public double Note { get; set; }
        public int NombreAvis { get; set; }

        public List<Avi> Avis { get; set; }
    }
}