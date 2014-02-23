    'use strict';

/* Controllers */

var blogSpaceController = angular.module('blogSpace.controllers', []);

blogSpaceController.controller('BlogCategoryController', ['$scope', 'categoryService', '$location','sharedCategoryData','$rootScope',
function ($scope, categoryService, $location, sharedCategoryData, $rootScope) {
    $scope.Categories = [];

    $scope.onFormSubmit = function () {
        $location.path('/blogsearch/' + $scope.searchText);
    }

    categoryService.GetCategoryList().then(function (Categories) {
        $scope.Categories = Categories
    });

    $scope.categoryfilter = sharedCategoryData.GetCategoryFilter();

    $scope.setFilter = function (filtertext) {
        sharedCategoryData.SetCategoryFilter(filtertext);
        $scope.categoryfilter = sharedCategoryData.GetCategoryFilter();
        
    };

    $scope.$on('sharedCategoryData.update', function (event, categoryFilterTitle) {
        $scope.categoryfilter = categoryFilterTitle;
    });

    $scope.isActive = function (category) {
        return $scope.categoryfilter == category;
    };

    $scope.Search = function () {
        if ($scope.categoryfilter != 'Category Filter') {
            $location.path('#/blogsearchbycategory/' + $scope.categoryfilter + '/' + $scope.searchText);
        }
        else {
            $location.path('#/blogsearch/' + $scope.searchText);
        }

    };
}]);

blogSpaceController.controller('BlogController', ['$scope', 'blogService', '$routeParams', '$location', 'sharedCategoryData','$rootScope',
function ($scope, blogService, $routeParams, $location, sharedCategoryData,$rootScope) {

        $scope.Blogs = [];
        $scope.category = $routeParams.category;
        $scope.busy = false;
        $scope.after = '';
        $scope.searchText = "";
        $scope.pageIndex = -1;
        $scope.lastPageSize = -1;

        $scope.navigateToCategory = function (category) {
            sharedCategoryData.SetCategoryFilter(category);
            $location.path('/blogcategory/' + category);
        };



        $scope.LoadNextBlogs = function () {
            if ($scope.lastPageSize == 0) return;
            if ($scope.busy) return;
            $scope.busy = true;

            if (typeof ($scope.category) != 'undefined') {
                $scope.pageIndex++;
                blogService.GetBlogListByCategory($scope.category, $scope.pageIndex).then(function (Blogs) {
                    if (Blogs.length == 0) {
                        $scope.lastPageSize = 0;
                    }
                    else {
                        for (var i = 0; i < Blogs.length; i++) {
                            $scope.Blogs.push(Blogs[i]);
                        }
                    }
                    $scope.busy = false;

                });
            }
            else {
                $scope.pageIndex++;
                blogService.GetBlogList($scope.pageIndex).then(function (Blogs) {
                    if (Blogs.length == 0) {
                        $scope.lastPageSize = 0;
                    }
                    else {
                        for (var i = 0; i < Blogs.length; i++) {
                            $scope.Blogs.push(Blogs[i]);
                        }
                    }
                    $scope.busy = false;
                });
            }
        };
    }]);

blogSpaceController.controller('BlogDetailController', ['$scope', 'blogService', '$routeParams',
    function ($scope, blogService, $routeParams) {

        $scope.Blog = null;
        $scope.id = $routeParams.id;
        $scope.title = $routeParams.title;

        blogService.GetBlog($routeParams.id, $scope.title).then(function (Blog) {
            $scope.Blog = Blog;
        });
    }
]);

blogSpaceController.controller('BlogSearchController', ['$scope', 'blogService', '$routeParams', '$location',
    function ($scope, blogService, $routeParams, $location) {
        $scope.Blogs = [];
        $scope.searchText = $routeParams.search;

        if (typeof ($scope.searchText) != 'undefined') {
            if (typeof ($scope.category) != 'undefined') {
                blogService.GetSearchBlogListByCategory($scope.searchText, $scope.category).then(function (Blogs) {
                    for (var i = 0; i < Blogs.length; i++) {
                        $scope.Blogs.push(Blogs[i]);
                    }
                });
            }
            else {
                blogService.GetSearchBlogList($scope.searchText).then(function (Blogs) {
                    for (var i = 0; i < Blogs.length; i++) {
                        $scope.Blogs.push(Blogs[i]);
                    }

                });
            }
        };
    }]);
