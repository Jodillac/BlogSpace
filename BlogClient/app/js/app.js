'use strict';

// Declare app level module which depends on filters, and services
angular.module('blogSpace', [
  'ngRoute',
  'ngSanitize',
  'blogSpace.filters',
  'blogSpace.services',
  'blogSpace.directives',
  'blogSpace.controllers',
  'blogSpace.restModule',
  'infinite-scroll',
  'ui.bootstrap'
]).
config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/blog', { templateUrl: 'partials/blog-list.html', controller: 'BlogController' });
    $routeProvider.when('/blogcategory/:category', { templateUrl: 'partials/blog-list.html', controller: 'BlogController' });
    $routeProvider.when('/blogdetail/:id/:title', { templateUrl: 'partials/blog-detail.html', controller: 'BlogDetailController' });
    $routeProvider.when('/blogsearch/:search', { templateUrl: 'partials/blog-list-search.html', controller: 'BlogSearchController' });
    $routeProvider.when('/profile', { templateUrl: 'partials/profile.html', controller: 'CarouselDemoCtrl' });
    $routeProvider.otherwise({ redirectTo: '/blog' });
}]);

var restModule = angular.module('blogSpace.restModule', ['restangular']);

restModule.config(function (RestangularProvider) {

    //Local
    RestangularProvider.setBaseUrl('http://localhost/api/api/');
    //Prod
    //RestangularProvider.setBaseUrl('http://http://blogspace.cloudapp.net/api/api/');

    RestangularProvider.setErrorInterceptor(
         function (resp) {
             if (resp.config.method == 'GET' && resp.status == 401) {
                 handleUnAuthorize();
                 return false; // stop the promise chain
             }
             // stop the promise chain
         });
});

function handleUnAuthorize() {
    var e = document.getElementsByTagName('form');
    var injector = angular.element(e).injector();
    var location = injector.get('$location');
    location.path("/UnAuthorize");
}
