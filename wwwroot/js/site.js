﻿var COMP;
selectElement()

function val() {
    var venue = document.getElementById("select_id").value;
    var cookieValue = encodeURIComponent(venue);
    document.cookie = "venue=" + cookieValue;
    setCompetitions(venue);
}

function selectElement() {
    if (document.getElementById("select_id")) {
        let element = document.getElementById("select_id");
        element.value = getCookie("venue");
    }
}

function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}

function getSkater() {
    window.location.href = "Rijders/" + document.getElementById("name").value;
}

function getRelatienummer() {
    window.location.href = "Licentie/" + document.getElementById("relatienummer").value;
}

function getSeasonBest(skater) {
    var season = document.getElementById("season").value;
    $.get("https://speedskatingresults.com/api/json/season_bests?skater=" + skater + "&start=" + season).done(function (data) {
        try {
            setSeasonBest(data.seasons[0].records);
        }
        catch{
            console.error("no records found");
            document.getElementById("sb").innerHTML = "Deze rijder heeft in dit seizoen (nog) niet gereden";
        }
    }).fail(function () {
        console.error("no records found");
        document.getElementById("sb").innerHTML = "Deze rijder heeft in dit seizoen (nog) niet gereden";
    });
}

function setSeasonBest(sb) {
    output = "<table style='width: 100%'>";
    sb.forEach(element => output += "<tr><td>" + element.distance + "</td><td>" + element.time + "</td><td>" + createDateObject1(element.date) + "</td><td>" + element.location + "</td></tr>")
    output += "</table>"
    document.getElementById("sb").innerHTML = output;
}

function getSeasonResults(skater) {
    var season = document.getElementById("season").value;
    var distances = [100, 300, 500, 700, 1000, 1500, 3000, 5000, 10000]
    document.getElementById("results").innerHTML = "";
    for (var i = 0; i < distances.length; i++) {
        getSeasonResultsByDistance(skater, distances[i], season)
    }
}

function getSeasonResultsByDistance(skater, distance, season) {
    $.get("https://speedskatingresults.com/api/json/skater_results.php?skater=" + skater + "&distance=" + distance + "&season=" + season).done(function (data) {
        try {
            setSeasonResults(data.results, distance);
        }
        catch{
            console.error("no distance results found");
        }
    }).fail(function () {
        console.error("no distance results found");
    });
}

function setSeasonResults(results, distance) {
    if (results.length != 0) {
        output = "<h4>" + distance + " meter</h4><table style='width: 100%'>";
        for (var i = 0, len = results.length; i < len; i++) {
            output += "<tr><td style='width: 10%;'><strong>" + results[i].time + "</strong></td><td style='width: 20%;'>" + createDateObject1(results[i].date) + "</td><td style='width: 30%;'>" + results[i].location + "</td><td style='width: 40%;'><a target='_blank' href='" + results[i].link + "'>" + results[i].name + "</a></tr>"
        }
        output += "</table>"
        document.getElementById(distance).innerHTML = output;
    }
    else {
        document.getElementById(distance).innerHTML = "";
    }
}

function setVenueFromCookie() {
    var venue = getCookie("venue")
    if (venue != null) {
        document.getElementById("select_id").value = venue
    }
    else {
        document.getElementById("select_id").value = ""
    }
}

function createDateObject(date) {
    var newDate = new Date(date)
    var dd = newDate.getDate()
    var mo = ("0" + (newDate.getMonth() + 1)).slice(-2)
    var yyyy = newDate.getFullYear()
    var uu = newDate.getHours()
    var mm = newDate.getMinutes()

    if (dd < 10) {
        dd = "0" + dd
    }
    if (mm < 10) {
        mm = "0" + mm
    }
    if (uu < 10) {
        uu = "0" + uu
    }
    return dd + "-" + mo + "-" + yyyy + " " + uu + ":" + mm
}

function createDateObject1(date) {
    var newDate = new Date(date)
    var dd = newDate.getDate()
    var mm = ("0" + (newDate.getMonth() + 1)).slice(-2)
    var yyyy = newDate.getFullYear()

    if (dd < 10) {
        dd = "0" + dd
    }
    return dd + "-" + mm + "-" + yyyy
}


function getCompetitions(competitons) {
    var venue = getCookie("venue")
    var checkBox = document.getElementById("oldCompetitions");
    if (checkBox.checked == false) {
        var recentCompetitions = [];
        var today = new Date();
        var lastWeek = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 8);
        for (var i = 0, len = competitons.length; i < len; i++) {
            var competitionDate = new Date(competitons[i].starts);
            if (competitionDate.getTime() > lastWeek.getTime()) {
                recentCompetitions.push(competitons[i])
            }
        }
        COMP = recentCompetitions;
    }
    else {
        COMP = competitons;
    }
    setCompetitions(venue);
}

function setCompetitions(venue) {
    var style = "";
    var output = "<tbody>";

    //sort array by date
    COMP.sort(function (a, b) {
        return new Date(a.starts) - new Date(b.starts);
    });

    if (venue == null || venue == "") {
        output = filterWithoutVenue(style, output)
    }
    else {
        output = filterWithVenue(style, output, venue)
    }

    document.getElementById("competitions").innerHTML = output + "</tbody>";
}

function filterWithVenue(style, output, venue) {
    var counter = 0;
    //loop through array
    for (var i = 0, len = COMP.length; i < len; i++) {
        if (COMP[i].discipline == "SpeedSkating.LongTrack" && COMP[i].venue.code == venue) {
            var output1 = "";

            if (counter % 2 == 0) {
                style = "tg-buh4";
            }
            else {
                style = "tg-0lax";
            }

            if (COMP[i].test == true) {
                output1 += "<span class='lbl warning'>Verborgen</span> ";
            }

            output += "<tr><td class='" + style + "' style='max-width:400px;'>" + output1 + "<a href='Home/Wedstrijd/" + COMP[i].id + "'>" + COMP[i].name + "</a></td>";

            try {
                output += "<td class='" + style + " nowrap'>" + COMP[i].venue.address.city + "</td>";
            }
            catch{
                console.error("No city founded for competition: " + COMP[i].id)
            }

            var startDateTime = createDateObject(COMP[i].starts)

            output += "<td class='" + style + " nowrap'>" + startDateTime + "</td>";

            if (COMP[i].resultsStatus == 2 || new Date(COMP[i].settings.closes) < new Date()) {
                output += "<td class='" + style + "'>gesloten</td>";
                output += "<td class='" + style + " nowrap'><a href='Home/Deelnemers/" + COMP[i].id + "'>&#9924 Deelnemers</a></td>";
                output += "<td class='" + style + " nowrap'>";
                if (COMP[i].resultsStatus == 2) {
                    output += "<a href='https://emandovantage.com/api/competitions/" + COMP[i].id + "/reports/Results/Pdf?optionalColumns=ClubShortName'>&#9782 Uitslag</a>";
                }
                output += "</td>";
            }
            else if (new Date(COMP[i].settings.opens) < new Date()) {
                output += "<td class='" + style + " nowrap'><a href='https://inschrijven.schaatsen.nl/#/wedstrijd/" + COMP[i].id + "/inschrijven/kies-licentie'>&#9998 Inschrijven</a></td>";
                output += "<td class='" + style + " nowrap'><a href='Home/Deelnemers/" + COMP[i].id + "'>&#9924 Deelnemers</a></td>";
                output += "<td colspan='2' class='" + style + " nowrap'></td>";
            }
            else {
                output += "<td colspan='3' class='" + style + " nowrap'>";
                var closesDateTime = createDateObject(COMP[i].settings.opens)
                output += "Open om " + closesDateTime + "</td>";
            }
            counter++;
        }
    }
    return output
}

function filterWithoutVenue(style, output) {
    //loop through array
    for (var i = 0, len = COMP.length; i < len; i++) {
        if (COMP[i].discipline == "SpeedSkating.LongTrack") {
            var output1 = "";

            if (i % 2 == 0) {
                style = "tg-buh4";
            }
            else {
                style = "tg-0lax";
            }

            if (COMP[i].test == true) {
                output1 += "<span class='lbl warning'>Verborgen</span> ";
            }

            output += "<tr><td class='" + style + "' style='max-width:400px;'>" + output1 + "<a href='Home/Wedstrijd/" + COMP[i].id + "'>" + COMP[i].name + "</a></td>";

            try {
                output += "<td class='" + style + " nowrap'>" + COMP[i].venue.address.city + "</td>";
            }
            catch{
                console.error("No city founded for competition: " + COMP[i].id)
            }

            var startDateTime = createDateObject(COMP[i].starts)

            output += "<td class='" + style + " nowrap'>" + startDateTime + "</td>";

            if (COMP[i].resultsStatus == 2 || new Date(COMP[i].settings.closes) < new Date()) {
                output += "<td class='" + style + "'>gesloten</td>";
                output += "<td class='" + style + " nowrap'><a href='Home/Deelnemers/" + COMP[i].id + "'>&#9924 Deelnemers</a></td>";
                output += "<td class='" + style + " nowrap'>";
                if (COMP[i].resultsStatus == 2) {
                    output += "<a href='https://emandovantage.com/api/competitions/" + COMP[i].id + "/reports/Results/Pdf?optionalColumns=ClubShortName'>&#9782 Uitslag</a>";
                }
                output += "</td>";
            }
            else if (new Date(COMP[i].settings.opens) < new Date()) {
                output += "<td class='" + style + " nowrap'><a href='https://inschrijven.schaatsen.nl/#/wedstrijd/" + COMP[i].id + "/inschrijven/kies-licentie'>&#9998 Inschrijven</a></td>";
                output += "<td class='" + style + " nowrap'><a href='Home/Deelnemers/" + COMP[i].id + "'>&#9924 Deelnemers</a></td>";
                output += "<td colspan='2' class='" + style + " nowrap'></td>";
            }
            else {
                output += "<td colspan='3' class='" + style + " nowrap'>";
                var closesDateTime = createDateObject(COMP[i].settings.opens)
                output += "Open om " + closesDateTime + "</td>";
            }
        }
    }
    return output
}