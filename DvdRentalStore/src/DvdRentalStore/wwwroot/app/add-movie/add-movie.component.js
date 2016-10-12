angular.module('add-movie')
    .component('addMovie',
    {
        templateUrl: 'app/add-movie/add-movie.template.html',
        controller: [
            'Movie', function (Movie) {
                var self = this;
                this.save = save;

                this.model = {
                    title: '',
                    director: '',
                    copies: 0
                };

                function save() {
                    Movie.save(self.model);
                }
            }
        ]
    });
