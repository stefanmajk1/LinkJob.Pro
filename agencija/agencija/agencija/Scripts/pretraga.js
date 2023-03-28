function setval(v) {
    $('#input').val(v);
    $("#ispiss").fadeOut();
}

$('#input').keyup(function () {
    var searchField = $('#input').val();
    var expression = RegExp(searchField, "i");

    $('#ispiss').remove();
    $.ajax({
        type: "GET",
        url: "/Home/Search",
        success: function (response) {
            var data = JSON.parse(response);
            console.log(data);
            if (searchField != "") {
                var html_Body =
                    `<div class="col-xs-6 col-md-3" id="ispiss">
                    </div>`;
            } $('#ispisati').append(html_Body);
            $.each(data, function (key, item) {
                if (item.naslov.search(expression) != -1 && searchField != "") {
                    var html_Search = `<div onclick="setval(this.firstChild.innerHTML)" style="width:250px;"><span id="ispiss">${item.naslov}</span></div>
                   `;

                    $('#ispiss').append(html_Search);
                }
            })
        }
    })
})

