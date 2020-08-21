using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using schaatswedstrijden.Models;

namespace schaatswedstrijden.Controllers
{
    public class DistanceCombinationController
    {
        public List<DistanceCombination> GetDistanceCombinations(string id)
        {
            WebRequest request = WebRequest.Create("https://knsbregistrations.azurewebsites.net/api/competitions/" + id + "/distancecombinations");
            WebResponse response = request.GetResponse();
            List<DistanceCombination> distanceCombinations;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                distanceCombinations = JsonConvert.DeserializeObject<List<DistanceCombination>>(responseFromServer);
            }

            distanceCombinations = GetDistanceCombinationsSettings(id, distanceCombinations);

            return distanceCombinations;
        }

        public List<DistanceCombination> GetDistanceCombinationsSettings(string id, List<DistanceCombination> distanceCombinations)
        {
            WebRequest request = WebRequest.Create("https://knsbregistrations.azurewebsites.net/api/competitions/" + id + "/settings/distancecombinations");
            WebResponse response = request.GetResponse();
            List<DistanceCombination> distanceCombinationsNew;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                distanceCombinationsNew = JsonConvert.DeserializeObject<List<DistanceCombination>>(responseFromServer);
            }

            foreach (DistanceCombination distanceCombination in distanceCombinations)
            {
                foreach (DistanceCombination distanceCombinationNew in distanceCombinationsNew)
                {
                    if(distanceCombination.id == distanceCombinationNew.distanceCombinationId)
                    {
                        distanceCombination.isClosed = distanceCombinationNew.isClosed;
                        distanceCombination.maxCompetitors = distanceCombinationNew.maxCompetitors;
                        distanceCombination.requireVenueSubscription = distanceCombinationNew.requireVenueSubscription;
                        distanceCombination.limitTimeDistanceValue = distanceCombinationNew.limitTimeDistanceValue;
                        distanceCombination.limitTime = distanceCombinationNew.limitTime;
                        distanceCombination.clubCodeFilter = distanceCombinationNew.clubCodeFilter;
                        distanceCombination.homeVenueFilter = distanceCombinationNew.homeVenueFilter;
                        distanceCombination.allowedRegistrations = distanceCombinationNew.allowedRegistrations;
                    }
                }
            }

            distanceCombinations = GetCompetitionSettings(id, distanceCombinations);

            return distanceCombinations;
        }

        public List<DistanceCombination> GetCompetitionSettings(string id, List<DistanceCombination> distanceCombinations)
        {
            WebRequest request = WebRequest.Create("https://knsbregistrations.azurewebsites.net/api/competitions/" + id + "/settings");
            WebResponse response = request.GetResponse();
            DistanceCombinationSettings distanceCombinationSettings;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                distanceCombinationSettings = JsonConvert.DeserializeObject<DistanceCombinationSettings>(responseFromServer);
            }

            foreach (DistanceCombination distanceCombination in distanceCombinations)
            {
                foreach (DistanceCombination distanceCombinationNew in distanceCombinationSettings.distanceCombinations)
                {
                    if (distanceCombination.id == distanceCombinationNew.distanceCombinationId)
                    {
                        distanceCombination.opens = distanceCombinationNew.opens;
                        distanceCombination.closes = distanceCombinationNew.closes;
                        distanceCombination.price = distanceCombinationNew.price;
                    }
                }
            }

            return distanceCombinations;
        }
    }
}
