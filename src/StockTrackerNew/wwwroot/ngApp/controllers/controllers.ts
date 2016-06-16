namespace StockTrackerNew.Controllers {


    export class AboutController {
        public message = 'Hello from the About Page!';
    }


    export class HomeController {
        public message = 'Hello from the Home Page!';
    }


    export class SecretController {
        public message = 'Hello from the Secrets Page!';
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets')
                .then((results) => { this.secrets = results.data; });
        }
    }


    export class StockController {
        public message = 'Hello from the Stock Page!';
        public errors;
        public stock;

        constructor(private $http: ng.IHttpService,
                    private $stateParams: ng.ui.IStateParamsService,
                    private $state: ng.ui.IStateService) {
            $http.get(`/api/stocks/${$stateParams['id']}`)
                .then((response) => { this.stock = response.data; })
                .catch((response) => { console.log(response); });

            setInterval(this.updatePrices.bind(this), 5000);
        }

        public updateData(): void {
            console.log(this.stock);
            this.$http.get(`/api/stocks/update/${this.stock.tickerSymbol}`)
                .then((response) => { this.stock = response.data })
                .catch((response) => { console.log('Whitney Houston,  we have a problem in the Stocks Update...'); });
        }

        public updatePrices(): void {
            this.$http.get(`/api/stocks/${this.$stateParams['id']}`)
                .then((response) => { this.stock = response.data; })
                .catch((response) => { console.log(response); });
        }

        public changeFollowing(): void {
            if (this.stock.follow == false) {
                this.stock.follow = true;
            }
            else {
                this.stock.follow = false;
            }

            this.$http.put(`/api/stocks/${this.$stateParams['id']}`, this.stock)
                .then((response) => {
                })
                .catch((response) => {
                this.errors = response.data;
                    console.log('Whitney Houston,  we have a problem posting the stock data...');
                });
        }
    }


    export class StocksController {
        public message = 'Hello from the Stocks Page!';
        public stocks;
        public searchstring;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/stocks')
                .then((results) => { this.stocks = results.data; })
                .catch((response) => { console.log(response); });

            setInterval(this.updatePrices.bind(this), 5000);
        }

        public updatePrices(): void {
            this.$http.get('/api/stocks')
                .then((results) => { this.stocks = results.data; });
        }
    }


    export class StocksAddController {
        public message = 'Hello from the Stocks Add Page!';
        public pagetitle = 'Add Stock';
        public stock;
        public errors;
        public yahooquote: any;

        constructor(private $http: ng.IHttpService,
                    private $stateParams: ng.ui.IStateParamsService,
                    private $state: ng.ui.IStateService) { }

        public saveStock(): void {
            if (this.stock.follow == null)
            {
                this.stock.follow = false;
                this.stock.imageURL = "images/240x200.png";
            }

            this.$http.post('/api/stocks', this.stock)
                .then((response) => { this.$state.go('stocks');
                    // console.log('This is the save button...');
                })
                .catch((response) => { this.errors = response.data;
                                       console.log('Whitney Houston,  we have a problem posting the stock data...'); });
        }

        public updateData(): void {
            console.log(this.stock);
            this.$http.get(`/api/stocks/update/${this.stock.tickerSymbol}`)
                .then((response) => { this.stock = response.data })
                .catch((response) => { console.log('Whitney Houston,  we have a problem in the Stocks Update...'); }); }

        // This doesn't work because of Same Origin Policy
        /*
        public updateData(): void {
            this.$http.get(`http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20IN%20(%22${this.stock.tickerSymbol}%22)&format=json&env=http://datatables.org/alltables.env`)
                .then((response) => {
                    this.yahooquote = response.data;
                    // console.log('I got the yahoo quote,  I hope...');
                })
                .catch((response) => { console.log('Whitney Houston,  we have a problem...'); });

            this.stock.name = this.yahooquote.query.results.quote.Name;
            this.stock.lastPrice = this.yahooquote.Name;
            this.stock.todayOpen = this.yahooquote.Open;
            this.stock.todayHigh = this.yahooquote.DaysHigh;
            this.stock.todayLow = this.yahooquote.DaysLow;
            this.stock.lastClose = this.yahooquote.PreviousClose;
            this.stock.volume = this.yahooquote.Volume;
            this.stock.lastUpdated = Date.now;
        }
        */
    }


    export class StocksAddWatchListController {
        public message = 'Hello from the Stocks Add Page!';
        public pagetitle = 'Add Stock to WatchList';
        public stocks;
        public searchstring;

        constructor(private $http: ng.IHttpService,
                    private $stateParams: ng.ui.IStateParamsService,
                    private $state: ng.ui.IStateService) {
            $http.get(`/api/stocks/watchlists/${$stateParams['id']}`)
                .then((results) => { this.stocks = results.data; })
                .catch((response) => { console.log('Whitney Houston,  we have a problem getting the list of stocks in the StocksAddWatchListController...') });
        }

        public addStockToWatchList(stockid): void {
            console.log('You clicked on somwething...');
            this.$http.post(`/api/watchlists/addstock/${this.$stateParams['id']}`, stockid)
                .then((results) => { this.stocks = results.data; })
                .catch((response) => { console.log('Whitney Houston,  we have a problem adding a stock in the StocksAddWatchListController...') });
        }
    }


    export class StocksEditController {
        public message = 'Hello from the Stocks Edit Page!';
        public pagetitle = 'Edit Stock';
        public stock;
        public errors;

        constructor(private $http: ng.IHttpService,
                    private $stateParams: ng.ui.IStateParamsService,
                    private $state: ng.ui.IStateService) {

            $http.get(`/api/stocks/${$stateParams['id']}`)
                .then((response) => { this.stock = response.data; })
                .catch((response) => { console.log('Whitney Houston,  we have a problem...');
                                       console.log(response); });
        }

        public saveStock(): void {
            this.$http.put(`/api/stocks/${this.$stateParams['id']}`, this.stock)
                .then((response) => { this.$state.go('stocks'); })
                .catch((response) => { this.errors = response.data; });
        }

        public markCheck(stock): void {
            stock.follow = !stock.follow;
        }
    }


    export class WatchListController {
        public message = 'Hello from the WatchList Page!';
        public stocklist;
        public title;
        public watchlist;

        constructor(private $http: ng.IHttpService,
                    private $stateParams: ng.ui.IStateParamsService,
                    private $state: ng.ui.IStateService)  {
            $http.get(`/api/watchlists/${$stateParams['id']}`)
                .then((results) => { this.watchlist = results.data; })
                .catch((response) => { console.log('Whitney Houston,  we have a problem getting the watchlist in the WatchListController...') });
        }

        public stocksAddWatchList(watchlistid): void {
            console.log('We got to the stocksAddWatchList() method with an id of ' + watchlistid + '.');
            this.$state.go(`stocksaddwatchlist`, { id: this.watchlist.id });
        }

        public removeFromList(stockid): void {
            // this proves whether or not we are getting here,  but this
            // isn't what I want to do once we get here
            console.log('Stock number ' + stockid + ' has beeen removed.');

            this.$http.post(`/api/watchlists/stock/${this.$stateParams['id']}`, stockid)
                .then((results) => { this.watchlist = results.data;
                                     this.$state.go(this.$state.current, {}, { reload: true });                })
                .catch((response) => { console.log('Whitney Houston,  we have a problem deleting the stock in the watchlist in the WatchListController...') });
        }
    }


    export class WatchListsController {
        public message = 'Hello from the WatchLists Page!';
        public watchlists;

        constructor(private $http: ng.IHttpService,
                    private $stateParams: ng.ui.IStateParamsService,
                    private $state: ng.ui.IStateService) {
            $http.get('/api/watchlists')
                .then((results) => { this.watchlists = results.data; })
                .catch((response) => { console.log('Whitney Houston,  we have a problem in the WatchListController...') });
        }

        public removeFromList(watchlistid): void {
            // this proves whether or not we are getting here,  but this
            // isn't what I want to do once we get here
            console.log('Stock number ' + watchlistid + ' has beeen removed.');

            this.$http.delete(`/api/watchlists/${watchlistid}`)
                .then((results) => { this.watchlists = results.data;
                                     this.$state.go(this.$state.current, {}, { reload: true }); })
                .catch((response) => { console.log('Whitney Houston,  we have a problem deleting the watchlist in the WatchListController...') });
        }
    }


    export class WatchListsAddController {
        public message = 'Hello from the WatchLists Add Page!';
        public pagetitle = 'Add WatchList';
        public watchlist;
        public errors;


        constructor(private $http: ng.IHttpService,
            private $state: ng.ui.IStateService) { }

        public saveWatchList(): void {
            this.watchlist.imageURL = "images/240x200.png";
            this.$http.post('/api/watchlists', this.watchlist)
                .then((response) => {
                    this.$state.go('watchlists');
                    // console.log('This is the save button...');
                })
                .catch((response) => { this.errors = response.data;
                                       console.log('Whitney Houston,  we have a problem posting the new watchlist...');
                });
        }
    }


    export class WatchListsEditController {
        public message = 'Hello from the WatchLists Edit Page!';
    }
}
