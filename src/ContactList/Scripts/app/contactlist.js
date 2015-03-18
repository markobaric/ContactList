var ContactListApp = angular.module("ContactListApp", ["ngRoute"]).
    config(function ($routeProvider, $locationProvider, $httpProvider) {
        $routeProvider.
            when('/new', { controller: 'DetailsController', templateUrl: 'Views/Details.html' }).
            when('/edit/:contactId', { controller: 'DetailsController', templateUrl: 'Views/Details.html' }).
            when('/', { controller: 'ListController', templateUrl: 'Views/List.html' }).
            otherwise({ redirectTo: '/' });
    });

