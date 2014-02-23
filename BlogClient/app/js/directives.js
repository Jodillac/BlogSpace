'use strict';
/* Directives */

var blogSpaceDirective = angular.module('blogSpace.directives', []);

blogSpaceDirective.directive('blogSearch', function ($rootScope) {
    return {
        restrict: 'AE',
        replace: true,
        templateUrl: 'partials/blog-search.html'
    };
});

blogSpaceDirective.directive('blogHeaderList', function ($rootScope) {

    return {
        restrict: 'AE',
        transclude: true,
        templateUrl: 'partials/blog-header-strip.html'

    };
});
