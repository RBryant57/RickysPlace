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
    $('#Date').datepicker()
})