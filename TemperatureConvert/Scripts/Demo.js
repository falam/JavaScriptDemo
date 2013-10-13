var Demo = (function () {
    var init = function() {
        $(document).ready(function() {
            var result = $("#result").text();
            if (result === undefined || result === null || result.length <= 0 || result === "Your name?") {
                $("#greeting").text("Please enter your name.");
                $("#result").hide();
            } else {
                $("#result").hide();
                $("#greeting").text("Good Day " + result);
            }
        });

        var highlight = function() {
            $("#greeting").css("color", "red");
        };

        $("#greeting").click(highlight);

        $("#ajax").click(function() {
            var result = $("#greeting").text();
            $.ajax({
                url: "/Demo/FormDemo",
                type: 'POST',
                dataType: "json",
                data: { "msg": result },
                success: function(response) { $("#result").show().text("Time: " + response.Date); }
            });
        });

        $("#convert").click(function() {
            var input = $("#temp").val();
            $.ajax({
                url: "/Demo/TemperatureConvert",
                type: 'POST',
                dataType: "json",
                data: { "tempInC": input },
                success: function(response) { $("#tempResult").show().text(response.Result); }
            });
        });

    };

    return {
        init: init
    };

})();


Demo.init();