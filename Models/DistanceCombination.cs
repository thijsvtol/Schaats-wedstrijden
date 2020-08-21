using System;
using System.Collections.Generic;

namespace schaatswedstrijden.Models
{

    public class DistanceCombination
    {
        public string id { get; set; }
        public string distanceCombinationId { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public string classFilter { get; set; }
        public string categoryFilter { get; set; }
        public int classificationWeight { get; set; }
        public List<Distance> distances { get; set; }
        public string starts { get; set; }
        public int competitorsTotal { get; set; }
        public int competitorsPending { get; set; }
        public string competitorsConfirmed { get; set; }
        public int competitorsWithdrawn { get; set; }
        public string opens { get; set; }
        public string closes { get; set; }
        public string price { get; set; }
        public string maxCompetitors { get; set; }
        public bool requireVenueSubscription { get; set; }
        public string limitTimeDistanceValue { get; set; }
        public string limitTime { get; set; }
        public string clubCodeFilter { get; set; }
        public string homeVenueFilter { get; set; }
        public bool isClosed { get; set; }
        public string allowedRegistrations { get; set; }
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

    public class DistanceCombinationSettings
    {
        public DateTime opens { get; set; }
        public DateTime closes { get; set; }
        public DateTime withdrawUntil { get; set; }
        public bool isClosed { get; set; }
        public bool isRegularOpen { get; set; }
        public bool isLateOpen { get; set; }
        public string maxCompetitors { get; set; }
        public int competitorListGrouping { get; set; }
        public bool allowMultipleCombinations { get; set; }
        public List<DistanceCombination> distanceCombinations { get; set; }
        public string paymentProvider { get; set; }
        public string paymentProviderKey { get; set; }
        public string paymentReference { get; set; }
        public string extra { get; set; }
        public string currency { get; set; }
        public Contact contact { get; set; }
        public string invitationIntroduction { get; set; }
        public string invitationFooter { get; set; }
        public string temporaryLicenseSecret { get; set; }
    }
}
