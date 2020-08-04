using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using schaatswedstrijden.Models;

namespace schaatswedstrijden.Controllers
{
    public class CompetitionController
    {
        public List<Root> GetAllCompetitions()
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
                    if (competition.discipline != "SpeedSkating.LongTrack")
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

        public Root GetCompetition(string id)
        {
            WebRequest request = WebRequest.Create("https://knsbregistrations.azurewebsites.net/api/competitions/" + id);
            WebResponse response = request.GetResponse();
            Root competition;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                competition = JsonConvert.DeserializeObject<Root>(responseFromServer);
            }

            return competition;
        }

        public List<DistanceCombinationCompetitors> GetCompetitors(string id)
        {
            WebRequest request = WebRequest.Create("https://knsbregistrations.azurewebsites.net/api/competitions/" + id + "/competitors");
            WebResponse response = request.GetResponse();
            List<DistanceCombinationCompetitors> competitors;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                competitors = JsonConvert.DeserializeObject<List<DistanceCombinationCompetitors>>(responseFromServer);
            }

            return competitors;
        }

        
    }
}