var KnockoutBasics = KnockoutBasics || {};

(function ($, APP) {
    // DOM Ready Function
    $(function () {
        //APP.Accordians.init();
    });

    APP.Accordians = {
        $posts: null,
        init: function () {
            var self = this;
            $posts = $(".post");            
            $posts.each(function () {
                $(this).accordion({ header: "> div > h4" })
                    .sortable({
                        axis: "y",
                        handle: "h4",
                        stop: function (event, ui) {
                            // IE doesn't register the blur when sorting
                            // so trigger focusout handlers to remove .ui-state-focus
                            ui.item.children("h4").triggerHandler("focusout");
                        }
                    });
            });
        }        
    };

    APP.Server = {
        postJson: function (blogs) {
            $.ajax({
                url: "/Knockout/Update",
                data: { json: JSON.stringify(blogs) },
                type: "POST",
                dataType: "json",
                complete: function(data) {
                    var title = (data.Error) ? "Error" : "Finished";
                    alert(title + " -- " + data.Message);
                }
            });
        }        
    };
}(jQuery, KnockoutBasics));
