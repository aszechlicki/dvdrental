angular.module('core.client').factory('Client', ['$resource', function ($resource) {
    return $resource('/api/clients/:clientId', {}, {});
}]);
