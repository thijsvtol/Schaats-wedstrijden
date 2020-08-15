﻿selectElement()

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
    sb.forEach(element => output += "<tr><td>"+element.distance + "</td><td>" + element.time + "</td><td>" + element.date + "</td><td>" + element.location + "</td></tr>")
    output += "</table>"
    document.getElementById("sb").innerHTML = output;
}