'use strict';

// Declare app level module which depends on filters, and services
angular.module('demo', ['demo.services', 'demo.controllers', 'ngRoute'])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider
            .when('/', { controller: 'mainController', templateUrl: '/MoviesList.html' })
            .when('/movie/:movieId', { controller: 'detailController', templateUrl: '/MovieDetails.html' })
            .otherwise({ redirectTo: '/' });
    }]);