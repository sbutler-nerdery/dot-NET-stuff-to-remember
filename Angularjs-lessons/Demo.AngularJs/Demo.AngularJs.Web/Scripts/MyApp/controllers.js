'use strict';
var movies;

angular.module('demo.controllers', ['demo.services'])
    .controller('mainController', ['$scope', 'api', function ($scope, api) {
        //Don't forget about this little jewel:
        //angular.element($('[ng-controller=main]')).scope() --> get the scope for an HTML element

        //$scope.movies = api.query({ apikey: 'vbp26ua7wx3yzd4429nz7e5a' });
        $scope.movies = [{ title: '', links: { self: '' }, posters: { thumbnail: 'http://java.llp2.dcc.ufmg.br/apiminer/static/images/loading.gif' } }]
        
        $scope.callbackSuccess = function (data) {
            //this took FOREVER to figure out! when the data is updated in the JS you have to let it know!
            $scope.$apply(function () {
                movies = data.movies;
                $scope.movies = data.movies;
            });
        };
        $scope.callbackError = function(data) {
            alert('it borked!');
        };
        
        api($scope.callbackSuccess, $scope.callbackError);
    }])
    .controller('detailController', ['$scope', '$location', '$routeParams', function ($scope, $location, $routeParams) {
        $scope.selectedMovie = _.filter(movies, function (movie) {
            return movie.id == $routeParams.movieId;
        })[0];
        $scope.back = function() {
            $location.path('/');
        };
    }]);