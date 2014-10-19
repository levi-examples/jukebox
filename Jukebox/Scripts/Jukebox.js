var app = angular.module("jukebox", ["ui.bootstrap", "ngRoute"]);

app.config(function($routeProvider) {
    $routeProvider
        .when('/artists', {
            templateUrl: 'partials/artists.html',
            controller: 'ArtistCtrl'
        })
        .otherwise({
            redirectTo: '/artists'
        });
});

app.controller('ArtistCtrl', function ($scope, $http) {
    $scope.artists = [];

    $scope.load = function () {
        $http.get("/Home/Artists")
            .success(function (data, status, headers, config) {
                $scope.artists = data;
            })
            .error(function (data, status, headers, config) {
                $scope.errors = data;
            });
    };
});
