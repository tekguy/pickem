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
        .when('/login', {
            templateUrl: 'angular/pages/login.html',
            controller: 'loginController'
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


app.controller('mainController', function ($scope, $route, $routeParams, $location, USER_ROLES, AuthService) {
    $scope.message = 'Welcome';
    $scope.$route = $route;
    $scope.$location = $location;
    $scope.$routeParams = $routeParams;
    
    $scope.currentUser = null;
    $scope.userRoles = USER_ROLES;
    $scope.isAuthorized = AuthService.isAuthorized;
});

app.controller('aboutController', function ($scope, $routeParams) {
    $scope.params = $routeParams;
});

app.controller('loginController', function ($scope, $rootScope, $routeParams,  AUTH_EVENTS, AuthService ) {
    $scope.params = $routeParams;

    $scope.credentials = {
        username: '',
        password: ''
    };

    $scope.login = function login(credentials) {
        AuthService.login(credentials).then(function () {
            $rootScope.$broadcast(AUTH_EVENTS.loginSuccess);
        }, function () {
            $rootScope.$broadcast(AUTH_EVENTS.loginFailed);
        });
    };

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


app.constant('AUTH_EVENTS', {
    loginSuccess: 'auth-login-success',
    loginFailed: 'auth-login-failed',
    logoutSuccess: 'auth-logout-success',
    sessionTimeout: 'auth-session-timeout',
    notAuthenticated: 'auth-not-authenticated',
    notAuthorized: 'auth-not-authorized'
});

app.constant('USER_ROLES', {
    all: '*',
    admin: 'admin',
    editor: 'editor',
    guest: 'guest'
});

app.factory('AuthService', function($http, Session) {
    return {
        login: function(credentials) {
            return $http
                .post('/login', credentials)
                .error(function (data) {
                    alert('Error');
                    Session.destroy();
                })
                .success(function(res) {
                    Session.create(res.id, res.userid, res.role);
                });
        },
        isAuthenticated: function () {
            console.log(Session);
            return !!Session.userId;
        },
        isAuthorized: function(authorizedRoles) {
            if (!angular.isArray(authorizedRoles)) {
                authorizedRoles = [authorizedRoles];
            }
            return (this.isAuthenticated() &&
                authorizedRoles.indexOf(Session.userRole) !== -1);
        }
    };
});

app.service('Session', function() {
    this.create = function(sessionId, userId, userRole) {
        this.id = sessionId;
        this.userId = userId;
        this.userRole = userRole;
    };
    this.destroy = function() {
        this.id = null;
        this.userId = null;
        this.userRole = null;
    };
    return this;
});