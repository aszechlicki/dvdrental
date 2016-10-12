angular.module('core.rental').factory('Rental', ['$resource', function ($resource) {
    return $resource('/api/rentals/:rentalId', {}, {});
}]);
