/// <reference path="../app.js" />
ezmoveapp.factory('employeeservice', ['$resource', employeeservice]);

function employeeservice($resource) {
    return $resource(location.protocol + '//' + location.host + "/Api/Dashboard", {}, {
        getTLBInfo: {
            url: location.protocol + '//' + location.host + "/Api/Dashboard/GetTLBInfo",
            isArray: true
        },
        getOtherTLBInfo: {
            url: location.protocol + '//' + location.host + "/Api/Dashboard/GetOtherTLBInfo",
            isArray: true
        }
    });
}