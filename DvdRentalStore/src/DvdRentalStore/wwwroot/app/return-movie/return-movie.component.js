angular.module('return-movie')
    .component('returnMovie',
    {
        templateUrl: 'app/return-movie/return-movie.template.html',
        controller: [
            'Rental', function (Rental) {
                var self = this;
                this.remove = remove;
                this.toggleRental = toggleRental;

                this.rental = null;

                getRentals();

                function remove() {
                    if (!self.rental) {
                        return;
                    }
                    Rental.delete({ rentalId: self.rental.id }, function() {
                        getRentals();
                    });
                }

                function getRentals() {
                    self.rentals = Rental.query();
                }

                function toggleRental(rental) {
                    if (self.rental === rental) {
                        self.rental = null;
                    } else {
                        self.rental = rental;
                    }
                }
            }
        ]
    });
