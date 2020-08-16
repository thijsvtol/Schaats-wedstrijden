selectElement()

function val() {
    var venue = document.getElementById("select_id").value;
    var cookieValue = encodeURIComponent(venue);
    document.cookie = "venue=" + cookieValue;
    location.reload();
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
    window.location.href = "Rijders/"+document.getElementById("name").value;
}

function getRelatienummer() {
    window.location.href = "Licentie/" + document.getElementById("relatienummer").value;
}

function getSeasonBest(skater) {
    var season = document.getElementById("season").value;
    $.get("https://speedskatingresults.com/api/json/season_bests?skater=" + skater + "&start=" + season).done(function (data) {
        try {
            setSeasonBest(data.seasons[0].records);
            console.log(data.seasons[0].records);
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
    sb.forEach(element => output += "<tr><td>" + element.distance + "</td><td>" + element.time + "</td><td>" + createDateObject(element.date) + "</td><td>" + element.location + "</td></tr>")
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
            output += "<tr><td style='width: 10%;'>" + results[i].time + "</td><td style='width: 20%;'>" + createDateObject(results[i].date) + "</td><td style='width: 30%;'>" + results[i].location + "</td><td style='width: 40%;'><a target='_blank' href='" + results[i].link + "'>" + results[i].name + "</a></tr>"
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
    var mm = newDate.getMonth() + 1
    var yyyy = newDate.getFullYear()

    if (dd < 10) {
        dd = "0" + dd
    }
    if (mm < 10) {
        mm = "0" + mm
    }
    return dd + "-" + mm + "-" + yyyy
}