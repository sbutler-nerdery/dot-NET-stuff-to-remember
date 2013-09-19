'use strict';

angular.module('demo.services', [])
    .factory('api', [function () {
        var url = '/Home/GetMovies';
        //see this example: http://stackoverflow.com/questions/17328724/requesting-example-for-angular-js-http-or-resource-post-and-transformrequest
        var api = function (itWorked, itBorked) {
            $.ajax({
                type: "POST",
                url: url,
                success: function (data) {
                    itWorked(data);
                },
                error: function (data) {
                    itBorked(data);
                }
            });
        };
        return api; //the controller 'or whatever' would then call api.query({apiKey:''});
    }]);