using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schaatswedstrijden.Models
{
    public class Skater
    {
        public int id { get; set; }
        public string familyname { get; set; }
        public string givenname { get; set; }
        public string suffix { get; set; }
        public string country { get; set; }
        public string gender { get; set; }
        public string category { get; set; }
    }

    public class Skaters
    {
        public List<Skater> skaters { get; set; }
    }

    public class Record
    {
        public int distance { get; set; }
        public string time { get; set; }
        public DateTime date { get; set; }
        public string location { get; set; }
    }

    public class Records
    {
        public int skater { get; set; }
        public List<Record> records { get; set; }
    }
}
