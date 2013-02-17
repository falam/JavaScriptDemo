(function () {
    $(document).ready(function () {
        var result = $("#result").text();
        if (result === undefined || result === null || result.length <= 0 || result === "Your name?") {
            $("#greeting").text("Please enter your name.");
            $("#result").hide();
        }
        else {
            $("#result").hide();
            $("#greeting").text("Good Day " + result);
        }
    });

    var highlight = function () {
        $("#greeting").css("color", "red");
    };

    $("#greeting").click(highlight);

    $("#ajax").click(function () {
        var result = $("#greeting").text();
        $.ajax({
            url: "/Demo/FormDemo",
            type: 'POST',
            dataType: "json",
            data: { "msg": result },
            success: function (response) { $("#result").show().text("Time: " + response.Date); }
        });
    });

    $("#convert").click(function () {
        var result = $("#temp").text();
        $.ajax({
            url: "/Demo/FormDemo",
            type: 'POST',
            dataType: "json",
            data: { "msg": result },
            success: function (response) { $("#result").show().text("Time: " + response.Date); }
        });
    });
    
})();