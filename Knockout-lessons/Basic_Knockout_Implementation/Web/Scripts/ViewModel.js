﻿var KnockoutBasics = KnockoutBasics || {};
KnockoutBasics.ViewModels = KnockoutBasics.ViewModels || {};

(function ($, KnockoutBasics) {
    KnockoutBasics.ViewModels.Blog = function () {
        var self = this;
        self.BlogId = ko.observable();
        self.Name = ko.observable();
        self.Posts = ko.observableArray();
        return self;
    };
    
    KnockoutBasics.ViewModels.Post = function () {
        var self = this;
        self.PostId = ko.observable();
        self.Title = ko.observable();
        self.Content = ko.observable();
        self.IsInEditMode = ko.observable(false);
        
        //Methods
        self.toggleEditMode = function () {
            this.IsInEditMode(!this.IsInEditMode());
        };
        
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

        return self;
    };
}(jQuery, KnockoutBasics));