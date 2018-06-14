$(function () {
    $("#CaliberId").change(function () {
        if ($("#CaliberId").val() != "" && $("#CaliberId").length > 0) {

            var path = location.pathname.substring(0, location.pathname.indexOf('Build'));
            var bulletOptions = {};
            bulletOptions.url = path + "Build/GetBullets";
            bulletOptions.type = "POST";
            bulletOptions.data = JSON.stringify({ caliberId: $("#CaliberId").val() });
            bulletOptions.dataType = "json";
            bulletOptions.contentType = "application/json";
            bulletOptions.success = function (Bullets) {
                $("#BulletId").empty();
                for (var i = 0; i < Bullets.length; i++) {
                    var singleBullet = Bullets[i].split(":");
                    $("#BulletId").append("<option value=" + singleBullet[0] + ">" + singleBullet[1] + "</option>");
                }
                $("#BulletId").prop("disabled", false);
            };
            bulletOptions.error = function () { alert("Error retrieving bullets!"); };
            $.ajax(bulletOptions);
        }
        else {
            $("#BulletId").empty();
            $("#BulletId").prop("disabled", true);
        }
    });
});