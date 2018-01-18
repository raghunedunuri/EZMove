/// <reference path="../angular.js" />
var ezmoveapp = angular.module('ezmoveapp', ['ui.router', 'xeditable', 'ui.bootstrap']);
ezmoveapp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
        // Tabs states
        .state('home', {
            url: '/',
            templateUrl: location.protocol + '//' + location.host + "/Scripts/app/partials/Default.html"
        })
        .state('Request', {
            url: '/Request',
            templateUrl: location.protocol + '//' + location.host + "/Scripts/app/partials/Request.html"
        })
        .state('Communication', {
            url: '/Communication',
            templateUrl: location.protocol + '//' + location.host + "/Scripts/app/partials/Communication.html"
        })
        .state('employees', {
            url: '/employees',
            templateUrl: location.protocol + '//' + location.host + "/Scripts/app/partials/Employee/List.html"
        })
        .state('employees.details', {
            url: '/details',
            templateUrl: location.protocol + '//' + location.host + "/Scripts/app/partials/Employee/Details.html"
        })
        .state('employees.details.edit', {
            url: '/edit',
            templateUrl: location.protocol + '//' + location.host + "/Scripts/app/partials/Employee/Edit.html"
        });

})