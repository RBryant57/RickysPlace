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