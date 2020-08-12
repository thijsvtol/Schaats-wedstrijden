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