$(document).ready(function () {
    $('#GetAboutUs').click(function (e) {
        $('#MainPartialViews').load('@Url.Action("AboutUsPage", "Home")')
    });
});