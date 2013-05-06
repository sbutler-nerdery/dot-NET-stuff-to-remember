/*Knockout validation example: http://jsfiddle.net/alexdresko/KHFn8/2403/ */

var KnockoutBasics = KnockoutBasics || {};
KnockoutBasics.ViewModels = KnockoutBasics.ViewModels || {};

//Make sure that validation decorates elements with classes.
//also, insertMessages = false will keep it from creating span tags with error messages.
ko.validation.configure({ decorateElement: true });

(function ($, KnockoutBasics) {
    KnockoutBasics.ViewModels.blog = function (data) {
        var self = this;
        var editText = "Edit Blog";
        var doneText = "Done";

        var mappingOptions = {
            posts: {
                create: function (options) {
                    return new KnockoutBasics.ViewModels.post(options.data);
                }
            }
        };

        ko.mapping.fromJS(data, mappingOptions, self);
        //Add validation...
        self.name.extend({ required: { message: "Blog name cannot be blank" } });

        //Non mapped properties
        self.isInEditMode = ko.observable();
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

        self.removePost = function (post) {
            self.posts.remove(post);
        };

        return self;
    };

    KnockoutBasics.ViewModels.post = function (data) {
        var self = this;
        var defaultEditText = "Edit Post";
        var doneText = "Done";

        ko.mapping.fromJS(data, {}, self);

        //Add validation
        self.title.extend({ required: { message: ' ' } }); //validation with no message
        self.content.extend({ required: true }); //validation with default message

        //Non mapped properties
        self.isInEditMode = ko.observable((self.postId() == 0));
        self.editModeText = ko.observable((self.postId() == 0) ? doneText : defaultEditText);

        //Non mapped methods
        self.toggleEditMode = function () {
            self.isInEditMode(!self.isInEditMode());
            self.editModeText((self.isInEditMode()) ? doneText : defaultEditText);
        };

        return self;
    };

    KnockoutBasics.ViewModels.ContentViewModel = function (blogsJson) {
        var self = this;
        self.blogs = ko.observableArray();
        self.serverMessage = ko.observable("");

        var mappingOptions = {
            create: function (options) {
                return new KnockoutBasics.ViewModels.blog(options.data);
            }
        };

        ko.mapping.fromJS(blogsJson, mappingOptions, self.blogs);

        //Setup validation
        self.errorMessages = ko.validation.group(self.blogs(), { deep: true });

        //Methods
        self.applyBindings = function () {
            ko.applyBindings(self);
        };

        self.save = function () {
            if (self.errorMessages().length == 0) {
                var blogs = ko.mapping.toJS(self.blogs);
                KnockoutBasics.Server.postJson(blogs, self.reloadData);
            }
        };

        self.reloadData = function (updatedObjects, message) {
            ko.mapping.fromJS(updatedObjects, mappingOptions, self.blogs);
            self.serverMessage(message);
            $(".serverMessage").show();
            KnockoutBasics.Timer.doOnce(function () { $(".serverMessage").fadeOut({ duration: 1000 }); }, 3000);
        };

        self.addBlog = function () {
            var newBlog = { blogId: 0, name: "New Blog", posts: [] };
            self.blogs.unshift(new KnockoutBasics.ViewModels.blog(newBlog));
        };

        self.removeBlog = function (blog) {
            self.blogs.remove(blog);
        };

        return self;
    };
}(jQuery, KnockoutBasics));