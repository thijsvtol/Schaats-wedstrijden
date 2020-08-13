using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using schaatswedstrijden.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace schaatswedstrijden.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Wedstrijd(string ID)
        {
            return View();
        }

        public ActionResult Deelnemers(string ID)
        {
            return View();
        }

        public ActionResult Rijders(string name)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ranglijsten(string seizoen, string afstanden, string categorie, string thuisbaan, string geredenbaan, string optioneel, string type, string maxdeelnemers, string maxpunten)
        {
            string klasse;
            string gender;
            if(categorie[0] == 'H')
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            if(maxdeelnemers == null)
            {
                maxdeelnemers = "null";
            }

            if (maxpunten == null)
            {
                maxpunten = "null";
            }

            if(geredenbaan == "null")
            {
                geredenbaan = null;
            }

            if (afstanden == "100" || afstanden == "300" || afstanden == "100%2B300" || afstanden == "100%2B500" || afstanden == "100%2B300%2B500"){
                klasse = "100";
            }
            else{
                klasse = "500";
            }

            string bestandsnaam = afstanden + " " + categorie + " " + seizoen;
            ViewBag.Link = "https://www.emandovantage.com/api/reports/rankings/KNSB/SpeedSkating.LongTrack/SpeedSkating.LongTrack.PairsDistance.Individual/"+type+"?distanceValues="+afstanden+"&classificationWeight="+klasse+"&optionalColumns="+optioneel+"&cultureName=nl-NL&genders="+gender+"&categories="+categorie+"&countries=NED&homeVenues="+thuisbaan+"&venues="+geredenbaan+"&fixedSeason="+seizoen+"&count="+maxdeelnemers+"&maxPoints="+maxpunten+"&fileName="+bestandsnaam;
            return View();
        }

        [HttpGet]
        public ActionResult Ranglijsten()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
