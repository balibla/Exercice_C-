using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AvisFormation.Data;

namespace avisFormations.WebUi.Models
{
    public class ViewFormationAvisModel
    {
        public int id { get; internal set; }
        public string nom { get; internal set; }
        public List<Avis> avis { get; internal set; }
    
        public string url { get; internal set; }
        public string description { get; internal set; }
        public string nomseo { get; internal set; }
        public int nombreAvis { get; internal set; }
        public double noteFormation { get; internal set; }
    }
}