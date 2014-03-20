var app = angular.module('pickEm', ['ngRoute']);
app.config(function($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'angular/pages/home.html',
            controller: 'mainController'
        })
        .when('/about', {
            templateUrl: 'angular/pages/about.html',
            controller: 'aboutController'
        })
        .when('/teams', {
            templateUrl: 'angular/pages/teams.html',
            controller: 'teamController'
        })
        .when('/team/:id', {
            templateUrl: 'angular/pages/team.html',
            controller: 'teamProfileController'
        });

});

//services
// define team service
app.service('teamService', function ($http) {
    this.getTeams = function (callbackFunc) {
        $http({
            url: 'api/team'
        }).success(function (data) {
            // With the data succesfully returned, call our callback
            callbackFunc(data);
        }).error(function () {
            alert("error");
        });
    };
    this.getTeam = function (callbackFunc, id) {
        $http({
            url: 'api/team/' + id
        }).success(function (data) {
            // With the data succesfully returned, call our callback
            callbackFunc(data);
        }).error(function () {
            alert("error");
        });
    };
});


app.controller('mainController', function ($scope, $route, $routeParams, $location) {
    $scope.message = 'Welcome';
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
});

app.controller('aboutController', function ($scope, $routeParams) {
    $scope.params = $routeParams;
});

app.controller('teamController', function ($scope, $routeParams, teamService) {
    $scope.teams = null;
    $scope.params = $routeParams;

    // get all teams
    teamService.getTeams(function (dataResponse) {
        $scope.teams = dataResponse;
    });
});

app.controller('teamProfileController', function ($scope, $routeParams, teamService) {
    $scope.team = null;
    $scope.id = $routeParams.id;
    
    // get single team
    teamService.getTeam(function(response) {
        $scope.team = response;
    }, $scope.id);
    console.log($scope.id);
});
