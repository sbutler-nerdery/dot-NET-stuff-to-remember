var KnockoutBasics = KnockoutBasics || {};
KnockoutBasics.ViewModels = KnockoutBasics.ViewModels || {};

(function ($, KnockoutBasics) {
    KnockoutBasics.ViewModels.Blog = function () {
        var self = this;
        self.blogId = ko.observable();
        self.name = ko.observable();
        self.posts = ko.observableArray();
        self.isInEditMode = ko.observable();
        
        return self;
    };
    
    KnockoutBasics.ViewModels.Post = function () {
        var self = this;
        self.postId = ko.observable();
        self.title = ko.observable();
        self.content = ko.observable();
        self.isInEditMode = ko.observable();
        
        return self;
    };

    KnockoutBasics.ViewModels.ContentViewModel = function(blogsJson) {
        var self = this;
        self.blogs = ko.observableArray();
        self.page = ko.observable(0);
        self.pageSize = ko.observable(10);

        ko.mapping.fromJS(blogsJson, {}, self.blogs);

        //Methods
        self.applyBindings = function() {
            ko.applyBindings(self);
        };
        
        self.toggleEditMode = function (model) {
            model.isInEditMode(!model.isInEditMode());
        };

        return self;
    };
}(jQuery, KnockoutBasics));
