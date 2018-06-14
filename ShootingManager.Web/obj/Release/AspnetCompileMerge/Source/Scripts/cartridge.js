$(function () {
    $("#CartridgeLoadId").change(function () {
        if ($("#CartridgeLoadId").val() != "" && $("#CartridgeLoadId").length > 0) {

            var path = location.pathname.substring(0, location.pathname.indexOf('Build'));
            var brassOptions = {};
            brassOptions.url = path + "Build/GetBrasses";
            brassOptions.type = "POST";
            brassOptions.data = JSON.stringify({ cartridgeLoadId: $("#CartridgeLoadId").val() });
            brassOptions.dataType = "json";
            brassOptions.contentType = "application/json";
            brassOptions.success = function (Brasses) {
                $("#BrassId").empty();
                for (var i = 0; i < Brasses.length; i++) {
                    var singleBrass = Brasses[i].split(":");
                    $("#BrassId").append("<option value=" + singleBrass[0] + ">" + singleBrass[1] + "</option>");
                }
                $("#BrassId").prop("disabled", false);
            };
            brassOptions.error = function () { alert("Error retrieving brasses!"); };
            $.ajax(brassOptions);

            var primerOptions = {};
            primerOptions.url = path  + "Build/GetPrimers";
            primerOptions.type = "POST";
            primerOptions.data = JSON.stringify({ cartridgeLoadId: $("#CartridgeLoadId").val() });
            primerOptions.dataType = "json";
            primerOptions.contentType = "application/json";
            primerOptions.success = function (Primers) {
                $("#PrimerId").empty();
                for (var i = 0; i < Primers.length; i++) {
                    var singlePrimer = Primers[i].split(":");
                    $("#PrimerId").append("<option value=" + singlePrimer[0] + ">" + singlePrimer[1] + "</option>");
                }
                $("#PrimerId").prop("disabled", false);
            };
            primerOptions.error = function () { alert("Error retrieving primers!"); };
            $.ajax(primerOptions);
        }
        else {
            $("#BrassId").empty();
            $("#BrassId").prop("disabled", true);
            $("#PrimerId").empty();
            $("#PrimerId").prop("disabled", true);
        }
    });
});