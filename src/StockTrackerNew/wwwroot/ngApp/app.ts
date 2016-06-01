namespace StockTrackerNew {

    angular.module('StockTrackerNew', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/stocks.html',
                controller: StockTrackerNew.Controllers.StocksController,
                controllerAs: 'controller'
            })
            /*
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: StockTrackerNew.Controllers.HomeController,
                controllerAs: 'controller'
            })
            */
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: StockTrackerNew.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: StockTrackerNew.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: StockTrackerNew.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: StockTrackerNew.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: StockTrackerNew.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('stock', {
                url: '/stock/:id',
                templateUrl: '/ngApp/views/stock.html',
                controller: StockTrackerNew.Controllers.StockController,
                controllerAs: 'controller'
            })
            .state('stocks', {
                url: '/stocks',
                templateUrl: '/ngApp/views/stocks.html',
                controller: StockTrackerNew.Controllers.StocksController,
                controllerAs: 'controller'
            })
            .state('stocksadd', {
                url: '/stocksadd',
                templateUrl: '/ngApp/views/stocksadd.html',
                controller: StockTrackerNew.Controllers.StocksAddController,
                controllerAs: 'controller'
            })
            .state('stocksaddwatchlist', {
                url: '/stocksadd/watchlist/:id',
                templateUrl: '/ngApp/views/watchlistaddstocks.html',
                controller: StockTrackerNew.Controllers.StocksAddWatchListController,
                controllerAs: 'controller'
            })
            .state('stocksedit', {
                url: '/stocksedit/:id',
                templateUrl: '/ngApp/views/stocksadd.html',
                controller: StockTrackerNew.Controllers.StocksEditController,
                controllerAs: 'controller'
            })
            .state('watchlist', {
                url: '/watchlist/:id',
                templateUrl: '/ngApp/views/watchlist.html',
                controller: StockTrackerNew.Controllers.WatchListController,
                controllerAs: 'controller'
            })
            .state('watchlists', {
                url: '/watchlists',
                templateUrl: '/ngApp/views/watchlists.html',
                controller: StockTrackerNew.Controllers.WatchListsController,
                controllerAs: 'controller'
            })
            .state('watchlistadd', {
                url: '/watchlistsadd',
                templateUrl: '/ngApp/views/watchlistsadd.html',
                controller: StockTrackerNew.Controllers.WatchListsAddController,
                controllerAs: 'controller'
            })
            .state('watchlistedit', {
                url: '/watchlistsedit',
                templateUrl: '/ngApp/views/watchlistsadd.html',
                controller: StockTrackerNew.Controllers.WatchListsEditController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('StockTrackerNew').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('StockTrackerNew').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
