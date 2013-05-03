var KnockoutBasics = KnockoutBasics || {};
KnockoutBasics.ViewModels = KnockoutBasics.ViewModels || {};

(function ($, KnockoutBasics) {
    KnockoutBasics.ViewModels.blog = function (data) {
        var self = this;
        
        var mappingOptions = {
            posts: {
                create: function (options) {
                    return new KnockoutBasics.ViewModels.post(options.data);
                }
            }
        };

        ko.mapping.fromJS(data, mappingOptions, self);
        self.isInEditMode = ko.observable();
        
        //Additional properties
        var defaultEditText = "Edit Blog";
        self.isInEditMode = ko.observable(false);
        self.editModeText = ko.observable(defaultEditText);

        //Additional methods
        self.toggleEditMode = function () {
            self.isInEditMode(!self.isInEditMode());
            self.editModeText((self.isInEditMode()) ? "Save" : defaultEditText);
        };

        return self;
    };
    
    KnockoutBasics.ViewModels.post = function (data) {
        var self = this;
        ko.mapping.fromJS(data, {}, self);
        
        //Additional properties
        var defaultEditText = "Edit Post";
        self.isInEditMode = ko.observable(false);
        self.editModeText = ko.observable(defaultEditText);
        
        //Additional methods
        self.toggleEditMode = function () {
            self.isInEditMode(!self.isInEditMode());
            self.editModeText((self.isInEditMode()) ? "Save" : defaultEditText);
        };

        return self;
    };

    KnockoutBasics.ViewModels.ContentViewModel = function(blogsJson) {
        var self = this;
        self.blogs = ko.observableArray();
        //self.page = ko.observable(0);
        //self.pageSize = ko.observable(10);

        var mappingOptions = {
            create: function (options) {
                return new KnockoutBasics.ViewModels.blog(options.data);
            }
        };

        ko.mapping.fromJS(blogsJson, mappingOptions, self.blogs);

        //Methods
        self.applyBindings = function() {
            ko.applyBindings(self);
        };
        
        return self;
    };
}(jQuery, KnockoutBasics));
