'use strict';

/* Services */
// Demonstrate how to register services
// In this case it is a simple value service.
var blogSpaceService = angular.module('blogSpace.services', []);

blogSpaceService.factory('blogService', ['Restangular', function (Restangular) {
    return {
        GetBlogList: function (pageIndex) {
            var blogs = Restangular.one('blogs');
            return blogs.getList('', { pageIndex: pageIndex });
        },

        GetBlog: function (id, title) {
            var blogs = Restangular.one('blogs', id);
            return blogs.getList(title);
        },

        GetBlogListByCategory: function (category, pageIndex) {
            var blogs = Restangular.one('category', category);
            return blogs.getList('blogs', { pageIndex: pageIndex });
        },


        GetSearchBlogListByCategory: function (search, category) {
            var blogs = Restangular.one('blogs');
            return blogs.getList('', { category: category, search: search });
        },

        GetSearchBlogList: function (search) {
            var blogs = Restangular.one('blogs');
            return blogs.getList('', { search: search });
        }
    };
}]);


blogSpaceService.factory('sharedCategoryData', [function () {
    var categoryFilterTitle = 'Category Filter';

    return {
        GetCategoryFilter: function () {
            return categoryFilterTitle;
        },
        SetCategoryFilter: function (newFilterData) {
            categoryFilterTitle = newFilterData;
        }
    };
}]);


blogSpaceService.factory('categoryService', ['Restangular', function (Restangular) {
    return {
        GetCategoryList: function () {
            var blogCategories = Restangular.one('categories');
            return blogCategories.getList();
        }
    };
}]);

