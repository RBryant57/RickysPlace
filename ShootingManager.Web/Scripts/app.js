var ViewModel = function () {
    var self = this;
    self.guns = ko.observableArray();
    self.error = ko.observable();

    var gunsUri = 'http://localhost:9000/api/gun/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllGuns() {
        ajaxHelper(gunsUri, 'GET').done(function (data) {
            self.guns(data);
        });
    }

    // Fetch the initial data.
    getAllGuns();
};

ko.applyBindings(new ViewModel());