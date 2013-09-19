'use strict';
var movies;

angular.module('demo.controllers', ['demo.services'])
    .controller('mainController', ['$scope', 'api', function ($scope, api) {
        //Don't forget about this little jewel:
        //angular.element($('[ng-controller=main]')).scope() --> get the scope for an HTML element
        $scope.movies = [{ title: '', links: { self: '' }, posters: { thumbnail: 'http://www.europcar.me/images/loading.gif' } }];
        $scope.itWorked = function (data) {
            $scope.$apply(function () {
                $scope.movies = JSON.parse(data.Data).movies;
                movies = $scope.movies;
            });
        };
        
        $scope.itHorked = function (data) {
            $scope.movies = [{ title: 'Error: ' + data.Data, links: { self: '' }, posters: { thumbnail: 'http://icons.iconarchive.com/icons/kyo-tux/phuzion/256/Sign-Error-icon.png' } }];
        };

        api($scope.itWorked, $scope.itHorked);
    }])
    .controller('detailController', ['$scope', '$location', '$routeParams', function ($scope, $location, $routeParams) {
        $scope.selectedMovie = _.filter(movies, function (movie) {
            return movie.id == $routeParams.movieId;
        })[0];
        $scope.back = function () {
            $location.path('/');
        };
    }]);