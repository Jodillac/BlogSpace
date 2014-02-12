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

