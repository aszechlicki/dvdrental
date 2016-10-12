angular.module('app')
    .config([
        '$locationProvider', '$routeProvider', function config($locationProvider, $routeProvider) {
            $locationProvider.hashPrefix('!');

            $routeProvider.when('/add-movie',
                {
                    template: '<add-movie></add-movie>'
                })
                .when('/add-client',
                {
                    template: '<add-client></add-client>'
                })
                .when('/return-movie',
                {
                    template: '<return-movie></return-movie>'
                })
                .when('/rent-movie',
                {
                    template: '<rent-movie></rent-movie>'
                })
                .otherwise('/rent-movie');
        }
    ]);
