using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schaatswedstrijden.Models
{
    public class Licence
    {
        public PersonName personName { get; set; }
        public DateTime personBirthDate { get; set; }
        public string key { get; set; }
        public int flags { get; set; }
        public int season { get; set; }
        public object sponsor { get; set; }
        public Club club { get; set; }
        public DateTime validFrom { get; set; }
        public DateTime validTo { get; set; }
        public string category { get; set; }
        public object legNumber { get; set; }
        public object number { get; set; }
        public string venueCode { get; set; }
        public object transponder1 { get; set; }
        public object transponder2 { get; set; }
    }

    public class PersonName
    {
        public string initials { get; set; }
        public string firstName { get; set; }
        public string surnamePrefix { get; set; }
        public string surname { get; set; }
    }

    public class Club
    {
        public string countryCode { get; set; }
        public int code { get; set; }
        public string shortName { get; set; }
        public string fullName { get; set; }
    }

}
