'use strict';

angular.module('demo.services', [])
    .factory('api', [function ($http, $resource) {
        var url = 'http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apiKey=vbp26ua7wx3yzd4429nz7e5a';
        
        //Looks like we are going to need to use JSONP for this due to "same origin policy"
        //See this article for explination: http://en.wikipedia.org/wiki/JSONP
        var api = function (itWorked, itBorked) {
            url += '&callback=?';
            $.ajax({
                type: "GET",
                url: url,
                //                                        ^
                // ---- note the ? symbol ----------------|
                // jQuery is responsible for replacing this symbol
                // with the name of the auto generated callback fn
                dataType: "jsonp",
                success: function (data) {
                    itWorked(data);
                },
                error: function(data) {
                    itBorked(data);
                }
            });
        };

        return api;

        /* this is how you would do it if the Web API were on a CORS supported server.
        //see this example: http://stackoverflow.com/questions/17328724/requesting-example-for-angular-js-http-or-resource-post-and-transformrequest
        var api = $resource(url, { });
        return api; //the controller 'or whatever' would then call api.query({apiKey:''});
        */
    }]);