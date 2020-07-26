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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Root> GetCompetitions()
        {
            WebRequest request = WebRequest.Create("https://knsbregistrations.azurewebsites.net/api/competitions");
            WebResponse response = request.GetResponse();
            List<Root> dataObjects;

            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                dataObjects = JsonConvert.DeserializeObject<List<Root>>(responseFromServer);
                foreach (Root competition in dataObjects.ToList())
                {
                    if(competition.discipline != "SpeedSkating.LongTrack")
                    {
                        dataObjects.Remove(competition);
                    }
                }
            }

            // Close the response.
            response.Close();
            List<Root> sortedList = dataObjects.OrderBy(x => x.ends).ToList();

            return sortedList;
        }
    }
}
