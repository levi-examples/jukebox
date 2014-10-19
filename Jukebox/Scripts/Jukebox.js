var app = angular.module("jukebox", ["ui.bootstrap", "ngRoute"]);

app.config(function($routeProvider) {
    $routeProvider
        .when('/artists', {
            templateUrl: 'partials/artists.html',
            controller: 'ArtistCtrl'
        })
        .when('/artist/:id/albums', {
            templateUrl: 'partials/albums.html',
            controller: 'AlbumCtrl'
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

app.controller('AlbumCtrl', function($scope, $http, $routeParams) {
    $scope.albums = [];

    $scope.load = function() {
        $http.get("/artist/" + $routeParams.id + "/albums")
            .success(function (data, status, headers, config) {
                $scope.albums = data;
                $scope.artist = data[0].Artist;
            })
            .error(function (data, status, headers, config) {
                $scope.errors = data;
            });
    };
});
