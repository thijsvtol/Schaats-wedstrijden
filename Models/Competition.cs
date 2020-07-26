using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schaatswedstrijden.Models
{
    public class Name
    {
        public string initials { get; set; }
        public string firstName { get; set; }
        public string surnamePrefix { get; set; }
        public string surname { get; set; }

    }

    public class Address
    {
        public object line1 { get; set; }
        public object line2 { get; set; }
        public object stateOrProvince { get; set; }
        public object postalCode { get; set; }
        public object city { get; set; }
        public object countryCode { get; set; }

    }

    public class Contact
    {
        public string organizationName { get; set; }
        public Name name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
        public object extra { get; set; }
        public string url { get; set; }

    }

    public class Settings
    {
        public DateTime opens { get; set; }
        public DateTime closes { get; set; }
        public DateTime withdrawUntil { get; set; }
        public bool isClosed { get; set; }
        public bool isRegularOpen { get; set; }
        public bool isLateOpen { get; set; }
        public int? maxCompetitors { get; set; }
        public int competitorListGrouping { get; set; }
        public bool allowMultipleCombinations { get; set; }
        public List<object> distanceCombinations { get; set; }
        public string paymentProvider { get; set; }
        public string paymentProviderKey { get; set; }
        public string paymentReference { get; set; }
        public string extra { get; set; }
        public string currency { get; set; }
        public Contact contact { get; set; }
        public string invitationIntroduction { get; set; }
        public string invitationFooter { get; set; }
        public object temporaryLicenseSecret { get; set; }

    }

    public class Serie
    {
        public string id { get; set; }
        public string licenseIssuerId { get; set; }
        public string discipline { get; set; }
        public int season { get; set; }
        public string name { get; set; }
        public int competitionsCount { get; set; }

    }

    public class Address2
    {
        public string line1 { get; set; }
        public object line2 { get; set; }
        public string stateOrProvince { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string countryCode { get; set; }

    }

    public class Venue
    {
        public string name { get; set; }
        public string code { get; set; }
        public string discipline { get; set; }
        public Address2 address { get; set; }
        public string continentCode { get; set; }
        public List<object> tracks { get; set; }

    }

    public class Root
    {
        public Settings settings { get; set; }
        public Serie serie { get; set; }
        public Venue venue { get; set; }
        public int resultsStatus { get; set; }
        public DateTime? madeOfficial { get; set; }
        public string location { get; set; }
        public int locationFlags { get; set; }
        public string extra { get; set; }
        public string id { get; set; }
        public object providerKey { get; set; }
        public string discipline { get; set; }
        public string sponsor { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int classs { get; set; }
        public bool test { get; set; }
        public string culture { get; set; }
        public string timeZone { get; set; }
        public string licenseIssuerId { get; set; }
        public string reportTemplateName { get; set; }
        public DateTime starts { get; set; }
        public DateTime ends { get; set; }
        public string defaultStarter { get; set; }
        public string defaultReferee1 { get; set; }
        public string defaultReferee2 { get; set; }

    }
}
