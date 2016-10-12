angular.module('rent-movie')
    .component('rentMovie',
    {
        templateUrl: 'app/rent-movie/rent-movie.template.html',
        controller: [
            'Rental', 'Client', 'Movie', function (Rental, Client, Movie) {
                var self = this;
                this.save = save;
                this.isValid = isValid;
                this.toggleClient = toggleClient;
                this.toggleMovie = toggleMovie;

                this.model = {
                    client: null,
                    movie: null
                };
                getData();

                function getData() {
                    self.clients = Client.query();
                    self.movies = Movie.query();
                }

                function isValid() {
                    return self.model.client && self.model.movie;
                }

                function save() {
                    Rental.save({clientId: self.model.client.id, dvdId: self.model.movie.id}, function() {
                        getData();
                    });
                }

                function toggleMovie(item)
                {
                    if (item.availableCopies < 1) {
                        return;
                    }
                    if (self.model.movie === item.movie) {
                        self.model.movie = null;
                    } else {
                        self.model.movie = item.movie;
                    }
                }

                function toggleClient(client) {
                    if (self.model.client === client) {
                        self.model.client = null;
                    } else {
                        self.model.client = client;
                    }
                }
            }
        ]
    });
