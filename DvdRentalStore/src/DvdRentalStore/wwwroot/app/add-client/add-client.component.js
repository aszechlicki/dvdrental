angular.module('add-client')
    .component('addClient',
    {
        templateUrl: 'app/add-client/add-client.template.html',
        controller: [
            'Client', function (Client) {
                var self = this;
                this.save = save;

                this.model = {
                    name: ''
                };

                function save() {
                    Client.save(self.model);
                }
            }
        ]
    });
