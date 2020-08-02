using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schaatswedstrijden.Models
{
    public class CompetitorInfo
    {
        public string id { get; set; }
        public string listId { get; set; }
        public int startNumber { get; set; }
        public string legNumber { get; set; }
        public string nationalityCode { get; set; }
        public string licenseDiscipline { get; set; }
        public string licenseKey { get; set; }
        public int licenseFlags { get; set; }
        public int status { get; set; }
        public string category { get; set; }
        public string classs { get; set; }
        public string sponsor { get; set; }
        public string clubCountryCode { get; set; }
        public string clubCode { get; set; }
        public string clubShortName { get; set; }
        public string clubFullName { get; set; }
        public string from { get; set; }
        public string transponder1 { get; set; }
        public string transponder2 { get; set; }
        public string fullName { get; set; }
        public string shortName { get; set; }
        public int gender { get; set; }
        public DateTime added { get; set; }
        public int source { get; set; }
        public string typeName { get; set; }
    }

    public class Competitor
    {
        public CompetitorInfo competitor { get; set; }
        public string reserve { get; set; }
        public int status { get; set; }
    }

    public class DistanceCombinationCompetitors
    {
        public string id { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public string classFilter { get; set; }
        public string categoryFilter { get; set; }
        public List<Competitor> competitors { get; set; }
    }
}