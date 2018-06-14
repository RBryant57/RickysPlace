$(function () {
    $("#GunId").change(function () {
        if ($("#GunId").val() != "" && $("#GunId").length > 0) {

            var path = location.pathname.substring(0, location.pathname.indexOf('ShootingSession'));
            var cartridgeOptions = {};
            cartridgeOptions.url = path + "ShootingSession/GetCartridges";
            cartridgeOptions.type = "POST";
            cartridgeOptions.data = JSON.stringify({ gunId: $("#GunId").val() });
            cartridgeOptions.dataType = "json";
            cartridgeOptions.contentType = "application/json";
            cartridgeOptions.success = function (Cartridges) {
                $("#CartridgeId").empty();
                for (var i = 0; i < Cartridges.length; i++) {
                    var singleCartridge = Cartridges[i].split(":");
                    $("#CartridgeId").append("<option value=" + singleCartridge[0] + ">" + singleCartridge[1] + "</option>");
                }
                $("#CartridgeId").prop("disabled", false);
            };
            
            $.ajax(cartridgeOptions);
        }
        else {
            $("#CartridgeId").empty();
            $("#CartridgeId").prop("disabled", true);
        }
    });
});

$(document).ready(function () {

})