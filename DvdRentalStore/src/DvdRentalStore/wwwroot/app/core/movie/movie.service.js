angular.module('core.movie').factory('Movie', ['$resource', function ($resource) {
    return $resource('/api/dvds/:dvdId', {}, {});
}]);
