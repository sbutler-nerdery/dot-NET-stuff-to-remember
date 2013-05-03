/*Knockout validation example: http://jsfiddle.net/alexdresko/KHFn8/2403/ */

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
        //Add validation...
        self.name.extend({ required: true }); //{ message:"Blog name cannot be blank" }

        self.isInEditMode = ko.observable();
        
        //Non mapped properties
        var editText = "Edit Blog";
        var doneText = "Done";
        self.isInEditMode = ko.observable((self.blogId() == 0));
        self.editModeText = ko.observable((self.blogId() == 0) ? doneText : editText);

        //Non mapped methods
        self.toggleEditMode = function () {
            self.isInEditMode(!self.isInEditMode());
            self.editModeText((self.isInEditMode()) ? doneText : editText);
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
        var defaultEditText = "Edit Post";
        var doneText = "Done";
        self.isInEditMode = ko.observable((self.postId() == 0));
        self.editModeText = ko.observable((self.postId() == 0) ? doneText : defaultEditText);
        self.errors = ko.computed = function () {
            var validationGroup = ko.validation.group(self);
            return (validationGroup.showAllMessages() != "");
        };
        
        //Non mapped methods
        self.toggleEditMode = function () {
            self.isInEditMode(!self.isInEditMode());
            self.editModeText((self.isInEditMode()) ? doneText : defaultEditText);
        };

        return self;
    };

    KnockoutBasics.ViewModels.ContentViewModel = function(blogsJson) {
        var self = this;
        self.blogs = ko.observableArray();
        self.serverMessage = ko.observable("");
        self.errors = ko.computed = function() {
            var validationGroup = ko.validation.group(self, { deep: true });
            return (validationGroup.showAllMessages() != "");
        };

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
            if (!self.errors()) {
                var blogs = ko.mapping.toJS(self.blogs);
                KnockoutBasics.Server.postJson(blogs, self.reloadData);
            }
        };

        self.submit = function () {
            if (self.errors().length != 0) {
                self.errors.showAllMessages();
            }
        };

        self.reloadData = function (updatedObjects, message) {
            ko.mapping.fromJS(updatedObjects, mappingOptions, self.blogs);
            self.serverMessage(message);
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
