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
            
            $.ajax(brassOptions);

            var primerOptions = {};
            primerOptions.url = path  + "Build/GetPrimers";
            primerOptions.type = "POST";
            primerOptions.data = JSON.stringify({ cartridgeLoadId: $("#CartridgeLoadId").val() });
            primerOptions.dataType = "json";
            primerOptions.contentType = "application/json";
            primerOptions.success = function (Primers) {
                $("#PrimerId").empty();
                $("#PrimerId").append("<option></option>");
                for (var i = 0; i < Primers.length; i++) {
                    var singlePrimer = Primers[i].split(":");
                    $("#PrimerId").append("<option value=" + singlePrimer[0] + ">" + singlePrimer[1] + "</option>");
                }
                $("#PrimerId").prop("disabled", false);
            };
            
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

$(function () {
    $("#CaliberId").change(function () {
        if ($("#CaliberId").val() != "" && $("#CaliberId").length > 0) {

            var path = location.pathname.substring(0, location.pathname.indexOf('Build'));
            var cartridgeLoadOptions = {};
            cartridgeLoadOptions.url = path + "Build/GetCartridgeLoads";
            cartridgeLoadOptions.type = "POST";
            cartridgeLoadOptions.data = JSON.stringify({ caliberId: $("#CaliberId").val() });
            cartridgeLoadOptions.dataType = "json";
            cartridgeLoadOptions.contentType = "application/json";
            cartridgeLoadOptions.success = function (CartridgeLoads) {
                $("#CartridgeLoadId").empty();
                for (var i = 0; i < CartridgeLoads.length; i++) {
                    var singleCartridgeLoad = CartridgeLoads[i].split(":");
                    $("#CartridgeLoadId").append("<option value=" + singleCartridgeLoad[0] + ">" + singleCartridgeLoad[1] + "</option>");
                }
                $("#CartridgeLoadId").prop("disabled", false);
            };
            
            $.ajax(cartridgeLoadOptions);

            var brassOptions = {};
            brassOptions.url = path + "ShootingManagerBase/GetBrassesByCaliber";
            brassOptions.type = "POST";
            brassOptions.data = JSON.stringify({ caliberId: $("#CaliberId").val() });
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
            
            $.ajax(brassOptions);

            var primerOptions = {};
            primerOptions.url = path + "Build/GetPrimersByCaliber";
            primerOptions.type = "POST";
            primerOptions.data = JSON.stringify({ caliberId: $("#CaliberId").val() });
            primerOptions.dataType = "json";
            primerOptions.contentType = "application/json";
            primerOptions.success = function (Primers) {
                $("#PrimerId").empty();
                $("#PrimerId").append("<option></option>");
                for (var i = 0; i < Primers.length; i++) {
                    var singlePrimer = Primers[i].split(":");
                    $("#PrimerId").append("<option value=" + singlePrimer[0] + ">" + singlePrimer[1] + "</option>");
                }
                $("#PrimerId").prop("disabled", false);
            };
            
            $.ajax(primerOptions);
        }
        else {
            $("#CartridgeLoadId").empty();
            $("#CartridgeLoadId").prop("disabled", true);
            $("#BrassId").empty();
            $("#BrassId").prop("disabled", true);
            $("#PrimerId").empty();
            $("#PrimerId").prop("disabled", true);
        }
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
});
$(function () {
    $('#AddToStore').click(function () {
        var $this = $(this);

        if ($this.is(':checked')) {
            $('#Quantity').removeAttr("disabled");
            $('#Cost').removeAttr("disabled");
        } else {
            $('#Quantity').val('');
            $('#Quantity').attr("disabled", "disabled");
            $('#Cost').attr("disabled", "disabled");
            $('#Cost').val('');
        }
    });
});
function validate_form() {
    if ($('#Name').val().length > 0
        && $('#CaliberId').val().length > 0
        && $('#BrassMaterialId').val().length > 0
        && $('#BulletTypeId').val().length > 0
        && $('#BulletMaterialId').val().length > 0
        && $('#Mass').val().length > 0
        && $('#ManufacturerId').val().length > 0
        && $('#MassUnitId').val().length > 0
        && $('#COL').val().length > 0
        && $('#COLUnitId').val().length > 0) {
        if ($('AddToStore').val() == 'true') {
            if ($('#Cost').val().length == 0 && $('#Quantity').val().length == 0) {
                $('#Create').attr("disabled", "disabled");
                return;
            }
        }
        $('#Create').removeAttr("disabled");
    }
    else {
        $('#Create').attr("disabled", "disabled");
    }
}
$(function () {
    $('#AddToStore').click(function () {
        validate_form();
    });
});
$(function () {
    $('#Name').change(function () {
        validate_form();
    });
});
$(function () {
    $('#CaliberId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#BrassMaterialId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#BulletTypeId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#BulletMaterialId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#Mass').change(function () {
        validate_form();
    });
});
$(function () {
    $('#MassUnitId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#ManufacturerId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#COL').change(function () {
        validate_form();
    });
});
$(function () {
    $('#COLUnitId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#Velocity').change(function () {
        validate_form();
    });
});
$(function () {
    $('#VelocityUnitId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#Pressure').change(function () {
        validate_form();
    });
});
$(function () {
    $('#PressureUnitId').change(function () {
        validate_form();
    });
});
$(function () {
    $('#Notes').change(function () {
        validate_form();
    });
}); 
$(function () {
    $('#Quantity').change(function () {
        validate_form();
    });
});
$(function () {
    $('#Cost').change(function () {
        validate_form();
    });
});
//$(function () {
//    $("#EntityId").change(function () {
//        if ($("#EntityId").val() != "" && $("#EntityId").length > 0) {

//            var path = location.pathname.substring(0, location.pathname.indexOf('Inventory'));
//            var brassOptions = {};
//            brassOptions.url = path + "Inventory/GetBrassesByCartridgeId";
//            brassOptions.type = "POST";
//            brassOptions.data = JSON.stringify({ cartridgeId: $("#EntityId").val() });
//            brassOptions.dataType = "json";
//            brassOptions.contentType = "application/json";
//            brassOptions.success = function (Brasses) {
//                $("#BrassId").empty();
//                for (var i = 0; i < Brasses.length; i++) {
//                    var singleBrass = Brasses[i].split(":");
//                    $("#BrassId").append("<option value=" + singleBrass[0] + ">" + singleBrass[1] + "</option>");
//                }
//                $("#BrassId").prop("disabled", false);
//            };

//            $.ajax(brassOptions);

//            var primerOptions = {};
//            primerOptions.url = path + "Inventory/GetPrimersByCartridgeId";
//            primerOptions.type = "POST";
//            primerOptions.data = JSON.stringify({ cartridgeId: $("#EntityId").val() });
//            primerOptions.dataType = "json";
//            primerOptions.contentType = "application/json";
//            primerOptions.success = function (Primers) {
//                $("#PrimerId").empty();
//                $("#PrimerId").append("<option></option>");
//                for (var i = 0; i < Primers.length; i++) {
//                    var singlePrimer = Primers[i].split(":");
//                    $("#PrimerId").append("<option value=" + singlePrimer[0] + ">" + singlePrimer[1] + "</option>");
//                }
//                $("#PrimerId").prop("disabled", false);
//            };

//            $.ajax(primerOptions);
//        }
//        else {
//            $("#BrassId").empty();
//            $("#BrassId").prop("disabled", true);
//            $("#PrimerId").empty();
//            $("#PrimerId").prop("disabled", true);
//        }
//    });
//});

$(document).ready(function () {
    $('#Quantity').attr("disabled", "disabled");
    $('#Cost').attr("disabled", "disabled");
    $('#Create').attr("disabled", "disabled");
})