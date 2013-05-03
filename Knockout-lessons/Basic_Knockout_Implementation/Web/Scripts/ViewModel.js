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
        
        //Non mapped properties
        var defaultEditText = (self.blogId() == 0) ? "Save" : "Edit Blog";
        self.isInEditMode = ko.observable((self.blogId() == 0));
        self.editModeText = ko.observable(defaultEditText);

        //Non mapped methods
        self.toggleEditMode = function () {
            self.isInEditMode(!self.isInEditMode());
            self.editModeText((self.isInEditMode()) ? "Save" : defaultEditText);
        };

        self.addPost = function () {
            var newPost = { postId: 0, title: "New Post", content: "Put new content here..." };
            self.posts.unshift(new KnockoutBasics.ViewModels.post(newPost));
        };

        self.removePost = function(post) {
            self.posts.remove(post);
        };

        return self;
    };
    
    KnockoutBasics.ViewModels.post = function (data) {
        var self = this;
        ko.mapping.fromJS(data, {}, self);
        
        //Non mapped properties
        var defaultEditText = (self.postId() == 0) ? "Save" : "Edit Post";
        self.isInEditMode = ko.observable((self.postId() == 0));
        self.editModeText = ko.observable(defaultEditText);
        
        //Non mapped methods
        self.toggleEditMode = function () {
            self.isInEditMode(!self.isInEditMode());
            self.editModeText((self.isInEditMode()) ? "Save" : defaultEditText);
        };

        return self;
    };

    KnockoutBasics.ViewModels.ContentViewModel = function(blogsJson) {
        var self = this;
        self.blogs = ko.observableArray();

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

        self.save = function () {
            var blogs = ko.mapping.toJS(self.blogs);
            KnockoutBasics.Server.postJson(blogs);
        };

        self.addBlog = function () {
            var newBlog = { blogId: 0, name: "New Blog", posts: [] };
            self.blogs.unshift(new KnockoutBasics.ViewModels.blog(newBlog));
        };

        self.removeBlog = function(blog) {
            self.blogs.remove(blog);
        };
        
        return self;
    };
}(jQuery, KnockoutBasics));
