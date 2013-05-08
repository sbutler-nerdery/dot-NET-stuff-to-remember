var KnockoutBasics = KnockoutBasics || {};

(function ($, APP) {
    // DOM Ready Function
    $(function () {
        //You can put things here to auto load when the DOM loads!
    });

    APP.Timer = {
        doOnce: function (callback, interval) {
            var myTimer = null;
            myTimer = setInterval(function () { callback(); window.clearInterval(myTimer); }, interval);
        }
    },

    APP.Server = {
        postJson: function (blogs, callback) {
            $.ajax({
                url: "/Knockout/Update",
                data: { json: JSON.stringify(blogs) },
                type: "POST",
                dataType: "json",
                /*NOTE: if you use complete instead of success, you will get back a different json object!!! 
                Took me a while to figure that out. */
                success: function (data) {
                    //Pass the updated json back to the caller
                    try {
                        if (!data.Error) {
                            var json = JSON.parse(data.Updated.replace("'", "\'"));
                            callback(json, data.Message);
                        } else { //Return the old data... 
                            callback(blogs, data.Message);
                        }
                    } catch (err) {
                        callback(blogs, "Javascript error -- " + err);
                    }
                }
            });
        }
    };
}(jQuery, KnockoutBasics));
