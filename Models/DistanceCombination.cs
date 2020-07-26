using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schaatswedstrijden.Models
{

    public class DistanceCombination
    {
        public string id { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public object classFilter { get; set; }
        public string categoryFilter { get; set; }
        public int classificationWeight { get; set; }
        public List<Distance> distances { get; set; }
        public object starts { get; set; }
        public int competitorsTotal { get; set; }
        public int competitorsPending { get; set; }
        public int competitorsConfirmed { get; set; }
        public int competitorsWithdrawn { get; set; }
    }

    public class Distance
    {
        public string id { get; set; }
        public string discipline { get; set; }
        public int number { get; set; }
        public int value { get; set; }
        public int valueQuantity { get; set; }
        public string name { get; set; }
        public DateTime starts { get; set; }
    }
}
