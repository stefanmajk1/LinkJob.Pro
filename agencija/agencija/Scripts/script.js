$(document).ready(function () {
    $('#input').autocomplete
        ({
            source: '@Url.Action("Search","Home")'
        }
        );
})