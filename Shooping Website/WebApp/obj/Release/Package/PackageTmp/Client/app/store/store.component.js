"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var store_1 = require("../services/store");
var cart_1 = require("../models/cart");
var StoreComponent = (function () {
    function StoreComponent(storeService, cart) {
        this.storeService = storeService;
        this.cart = cart;
        this.name = 'My Angular App';
        this.products = [];
    }
    StoreComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.storeService.GetProducts().subscribe(function (res) {
            _this.products = res;
            // console.log(this.products);
        });
    };
    return StoreComponent;
}());
StoreComponent = __decorate([
    core_1.Component({
        selector: 'app-store',
        templateUrl: 'client/app/store/store.component.html'
    }),
    __metadata("design:paramtypes", [store_1.StoreService, cart_1.Cart])
], StoreComponent);
exports.StoreComponent = StoreComponent;
//# sourceMappingURL=store.component.js.map