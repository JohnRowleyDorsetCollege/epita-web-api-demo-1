$(function () {

    setup();

});

function setup() {
    console.log('Jquery is loaded');

    LoadUserProfiles()
}

function LoadUserProfiles() {

    const url = 'https://localhost:7033/api/v1/UserProfile';

    // async method
    $.getJSON(url, function (userprofiledata) {

        console.log(userprofiledata);

        RenderDataAsTable(userprofiledata)

    });

}

function RenderDataAsTable(data) {

}