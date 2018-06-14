$(function () {
    $('#CaliberId').change(function () {
        var caliber = $('#CaliberId option:selected').text();
        if (caliber != '') {
            caliber = 'td:contains("' + caliber + '")';
            var validDiameter = $(caliber).next().text().trim();
            validDiameter = validDiameter.substring(0, validDiameter.length - 1);
            $('#Length').val(validDiameter);
        }
        else {
            $('#Length').val('');
        }

        if ($("#CaliberId").val() != "" && $("#CaliberId").length > 0) {

            var path = location.pathname.substring(0, location.pathname.indexOf('Brass'));
            var brassOptions = {};
            brassOptions.url = path + "ShootingManagerBase/GetBrassesByCaliber";
            brassOptions.type = "POST";
            brassOptions.data = JSON.stringify({ caliberId: $("#CaliberId").val() });
            brassOptions.dataType = "json";
            brassOptions.contentType = "application/json";
            brassOptions.success = function (Brasses) {
                $("#ParentId").empty();
                $("#ParentId").append("<option value=''></option>");
                for (var i = 0; i < Brasses.length; i++) {
                    var singleBrass = Brasses[i].split(":");
                    $("#ParentId").append("<option value=" + singleBrass[0] + ">" + singleBrass[1] + "</option>");
                }
                $("#ParentId").prop("disabled", false);
            };
            
            $.ajax(brassOptions);

        }
        else {
            $("#ParentId").empty();
            $("#ParentId").prop("disabled", true);
        }
    }).change();
});
$(function () {
    $('#InventoryTypeId').change(function () {
        var inventoryType = $('#InventoryTypeId option:selected').text();
        if (inventoryType != 'Purchase') {
            $('#Price').hide();
        }
        else {
            $('#Price').show();
        }
    }).change();
});
$(document).ready(function () {
    $('#Date').datepicker()//.datepicker.formatDate('mm/dd/yyyy', new Date());  //({ dateFormat: 'yy-mm-dd' });
})