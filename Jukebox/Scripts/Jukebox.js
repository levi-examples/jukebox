var app = angular.module("jukebox", ["ui.bootstrap"]);
app.controller("artists", function ($scope, $http) {
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


//app.controller("albums", function ($scope, $http) {
//    $scope.albums = [];

//    $scope.load = function () {
//        $http.get("/Home/Albums/")
//            .success(function (data, status, headers, config) {
//                $scope.albums = data;
//            })
//            .error(function (data, status, headers, config) {
//                $scope.errors = data;
//            });
//    };
//});