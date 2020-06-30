(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/Dto/NewParcelDto.ts":
/*!*************************************!*\
  !*** ./src/app/Dto/NewParcelDto.ts ***!
  \*************************************/
/*! exports provided: NewParcelDto */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NewParcelDto", function() { return NewParcelDto; });
var NewParcelDto = /** @class */ (function () {
    function NewParcelDto() {
    }
    return NewParcelDto;
}());



/***/ }),

/***/ "./src/app/app-material.module.ts":
/*!****************************************!*\
  !*** ./src/app/app-material.module.ts ***!
  \****************************************/
/*! exports provided: AppMaterialModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppMaterialModule", function() { return AppMaterialModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm5/material.es5.js");



var AppMaterialModule = /** @class */ (function () {
    function AppMaterialModule() {
    }
    AppMaterialModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            exports: [
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatAutocompleteModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatBadgeModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatBottomSheetModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatButtonModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatButtonToggleModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatCardModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatCheckboxModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatChipsModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatDatepickerModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatDialogModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatDividerModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatExpansionModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatGridListModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatIconModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatInputModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatListModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatMenuModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatNativeDateModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatPaginatorModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatProgressBarModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatProgressSpinnerModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatRadioModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatRippleModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatSelectModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatSidenavModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatSliderModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatSlideToggleModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatSnackBarModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatSortModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatStepperModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatTableModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatTabsModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatToolbarModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatTooltipModule"],
                _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatTreeModule"],
            ]
        })
    ], AppMaterialModule);
    return AppMaterialModule;
}());



/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _components_nodes_nodes_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/nodes/nodes.component */ "./src/app/components/nodes/nodes.component.ts");
/* harmony import */ var _components_sorter_sorter_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./components/sorter/sorter.component */ "./src/app/components/sorter/sorter.component.ts");
/* harmony import */ var _components_node_details_node_details_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./components/node-details/node-details.component */ "./src/app/components/node-details/node-details.component.ts");
/* harmony import */ var _components_node_actions_node_actions_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./components/node-actions/node-actions.component */ "./src/app/components/node-actions/node-actions.component.ts");
/* harmony import */ var _components_action_details_action_details_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./components/action-details/action-details.component */ "./src/app/components/action-details/action-details.component.ts");








var routes = [
    { path: '', redirectTo: '/sorter', pathMatch: 'full' },
    { path: 'sorter', component: _components_sorter_sorter_component__WEBPACK_IMPORTED_MODULE_4__["SorterComponent"] },
    { path: 'nodes', component: _components_nodes_nodes_component__WEBPACK_IMPORTED_MODULE_3__["NodesComponent"] },
    { path: 'node-details/:id', component: _components_node_details_node_details_component__WEBPACK_IMPORTED_MODULE_5__["NodeDetailsComponent"] },
    { path: 'node-actions/:id', component: _components_node_actions_node_actions_component__WEBPACK_IMPORTED_MODULE_6__["NodeActionsComponent"] },
    { path: 'action-details/:id', component: _components_action_details_action_details_component__WEBPACK_IMPORTED_MODULE_7__["ActionDetailsComponent"] }
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n  <app-navigation></app-navigation>"

/***/ }),

/***/ "./src/app/app.component.scss":
/*!************************************!*\
  !*** ./src/app/app.component.scss ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".is-inactive {\n  opacity: 0.5; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvRDpcXFByb2plY3RzXFxFZHNTb3J0ZXJFbXVsYXRvclxcRWRzU29ydGVyRW11bGF0b3JcXGVkcy5zb3J0ZXJlbXVsYXRvclxcZWRzLnNvcnRlcmVtdWxhdG9yLmNsaWVudFxcV2ViQ2xpZW50L3NyY1xcYXBwXFxhcHAuY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBRU07RUFDRSxZQUFZLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9hcHAuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIgICAgXHJcbiAgIFxyXG4gICAgICAuaXMtaW5hY3RpdmUge1xyXG4gICAgICAgIG9wYWNpdHk6IDAuNTtcclxuICAgICAgfSJdfQ== */"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'Sorter Emulator Web Client';
    }
    AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.scss */ "./src/app/app.component.scss")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _angular_cdk_layout__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/cdk/layout */ "./node_modules/@angular/cdk/esm5/layout.es5.js");
/* harmony import */ var ngx_svg__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ngx-svg */ "./node_modules/ngx-svg/fesm5/ngx-svg.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _app_material_module__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./app-material.module */ "./src/app/app-material.module.ts");
/* harmony import */ var _material_navigation_navigation_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./material/navigation/navigation.component */ "./src/app/material/navigation/navigation.component.ts");
/* harmony import */ var _components_nodes_nodes_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./components/nodes/nodes.component */ "./src/app/components/nodes/nodes.component.ts");
/* harmony import */ var _components_sorter_sorter_component__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./components/sorter/sorter.component */ "./src/app/components/sorter/sorter.component.ts");
/* harmony import */ var _components_node_actions_node_actions_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./components/node-actions/node-actions.component */ "./src/app/components/node-actions/node-actions.component.ts");
/* harmony import */ var _components_action_details_action_details_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./components/action-details/action-details.component */ "./src/app/components/action-details/action-details.component.ts");
/* harmony import */ var _components_node_details_node_details_component__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! ./components/node-details/node-details.component */ "./src/app/components/node-details/node-details.component.ts");

















var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_8__["AppComponent"],
                _material_navigation_navigation_component__WEBPACK_IMPORTED_MODULE_11__["NavigationComponent"],
                _components_nodes_nodes_component__WEBPACK_IMPORTED_MODULE_12__["NodesComponent"],
                _components_sorter_sorter_component__WEBPACK_IMPORTED_MODULE_13__["SorterComponent"],
                _components_node_actions_node_actions_component__WEBPACK_IMPORTED_MODULE_14__["NodeActionsComponent"],
                _components_action_details_action_details_component__WEBPACK_IMPORTED_MODULE_15__["ActionDetailsComponent"],
                _components_node_details_node_details_component__WEBPACK_IMPORTED_MODULE_16__["NodeDetailsComponent"]
            ],
            imports: [
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["BrowserModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_3__["FormsModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClientModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_5__["BrowserAnimationsModule"],
                _angular_cdk_layout__WEBPACK_IMPORTED_MODULE_6__["LayoutModule"],
                _app_routing_module__WEBPACK_IMPORTED_MODULE_9__["AppRoutingModule"],
                _app_material_module__WEBPACK_IMPORTED_MODULE_10__["AppMaterialModule"],
                ngx_svg__WEBPACK_IMPORTED_MODULE_7__["NgxSvgModule"]
            ],
            providers: [],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_8__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/components/action-details/action-details.component.html":
/*!*************************************************************************!*\
  !*** ./src/app/components/action-details/action-details.component.html ***!
  \*************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>\r\n  action-details works!\r\n</p>\r\n"

/***/ }),

/***/ "./src/app/components/action-details/action-details.component.scss":
/*!*************************************************************************!*\
  !*** ./src/app/components/action-details/action-details.component.scss ***!
  \*************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvYWN0aW9uLWRldGFpbHMvYWN0aW9uLWRldGFpbHMuY29tcG9uZW50LnNjc3MifQ== */"

/***/ }),

/***/ "./src/app/components/action-details/action-details.component.ts":
/*!***********************************************************************!*\
  !*** ./src/app/components/action-details/action-details.component.ts ***!
  \***********************************************************************/
/*! exports provided: ActionDetailsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ActionDetailsComponent", function() { return ActionDetailsComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var ActionDetailsComponent = /** @class */ (function () {
    function ActionDetailsComponent() {
    }
    ActionDetailsComponent.prototype.ngOnInit = function () {
    };
    ActionDetailsComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-action-details',
            template: __webpack_require__(/*! ./action-details.component.html */ "./src/app/components/action-details/action-details.component.html"),
            styles: [__webpack_require__(/*! ./action-details.component.scss */ "./src/app/components/action-details/action-details.component.scss")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], ActionDetailsComponent);
    return ActionDetailsComponent;
}());



/***/ }),

/***/ "./src/app/components/node-actions/node-actions.component.html":
/*!*********************************************************************!*\
  !*** ./src/app/components/node-actions/node-actions.component.html ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>\r\n  node-actions works!\r\n</p>\r\n"

/***/ }),

/***/ "./src/app/components/node-actions/node-actions.component.scss":
/*!*********************************************************************!*\
  !*** ./src/app/components/node-actions/node-actions.component.scss ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvbm9kZS1hY3Rpb25zL25vZGUtYWN0aW9ucy5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./src/app/components/node-actions/node-actions.component.ts":
/*!*******************************************************************!*\
  !*** ./src/app/components/node-actions/node-actions.component.ts ***!
  \*******************************************************************/
/*! exports provided: NodeActionsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NodeActionsComponent", function() { return NodeActionsComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var NodeActionsComponent = /** @class */ (function () {
    function NodeActionsComponent() {
    }
    NodeActionsComponent.prototype.ngOnInit = function () {
    };
    NodeActionsComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-node-actions',
            template: __webpack_require__(/*! ./node-actions.component.html */ "./src/app/components/node-actions/node-actions.component.html"),
            styles: [__webpack_require__(/*! ./node-actions.component.scss */ "./src/app/components/node-actions/node-actions.component.scss")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], NodeActionsComponent);
    return NodeActionsComponent;
}());



/***/ }),

/***/ "./src/app/components/node-details/node-details.component.html":
/*!*********************************************************************!*\
  !*** ./src/app/components/node-details/node-details.component.html ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"Node\">\r\n    <h2>{{Node.Name}} Details</h2>\r\n    <div><span>Id: </span>{{Node.Id}}</div>\r\n    <div>\r\n      <label>Name:\r\n        <input matInput [(ngModel)]=\"Node.Name\" placeholder=\"Name\" />\r\n      </label>\r\n    </div>\r\n    <div>\r\n      <label>HostDestinationId:\r\n        <input matInput [(ngModel)]=\"Node.HostDestinationId\" placeholder=\"HostDestinationId\" />\r\n      </label>\r\n    </div>\r\n    <div>\r\n      <label>Speed:\r\n        <input matInput [(ngModel)]=\"Node.Speed\" placeholder=\"Speed\" />\r\n      </label>\r\n    </div>\r\n    <div>\r\n      <label>Size:\r\n        <input matInput [(ngModel)]=\"Node.Size\" placeholder=\"Size\" />\r\n      </label>\r\n    </div>\r\n    <div>\r\n        <label>PositionX:\r\n          <input matInput [(ngModel)]=\"Node.PositionX\" placeholder=\"PositionX\" />\r\n        </label>\r\n    </div>    \r\n    <div>\r\n        <label>PositionY:\r\n          <input matInput [(ngModel)]=\"Node.PositionY\" placeholder=\"PositionY\" />\r\n        </label>\r\n    </div>\r\n    <div>\r\n        <label>Rotation:\r\n          <input matInput [(ngModel)]=\"Node.Rotation\" placeholder=\"Rotation\" />\r\n        </label>\r\n    </div>\r\n    <div>\r\n        <label>Curvature:\r\n          <input matInput [(ngModel)]=\"Node.Curvature\" placeholder=\"Curvature\" />\r\n        </label>\r\n    </div>\r\n    <div>\r\n      <label>DefaultNextId:\r\n          <select [(ngModel)]=\"Node.DefaultNextId\">\r\n              <option *ngFor=\"let node of Nodes\" [ngValue]=\"node.Id\">\r\n                {{ node.Name }}\r\n              </option>\r\n            </select>\r\n      </label>\r\n      <a routerLink=\"/node-details/{{Node.DefaultNextId}}\"><mat-icon>menu</mat-icon></a>\r\n    </div>\r\n    <div>\r\n      <label>DefaultNextOccurs:\r\n        <input matInput [(ngModel)]=\"Node.DefaultNextOccurs\" placeholder=\"DefaultNextOccurs\" />\r\n      </label>\r\n    </div>\r\n    <div>\r\n      <label>DefaultNextContinues:\r\n        <input matInput [(ngModel)]=\"Node.DefaultNextContinues\" placeholder=\"DefaultNextContinues\" />\r\n      </label>\r\n    </div>\r\n    <div><span>IsStopped: </span>{{Node.IsStopped}}</div>\r\n    <div>\r\n        <button class=\"badge-left button\" (click)=\"onSaveNode()\">Save</button>\r\n        <button class=\"badge-middle button is-stop\" (click)=\"onDeleteNode()\">Delete</button>\r\n        <button class=\"badge-right button\" (click)=\"onDuplicateNode()\">Duplicate</button>\r\n    </div>\r\n  </div>"

/***/ }),

/***/ "./src/app/components/node-details/node-details.component.scss":
/*!*********************************************************************!*\
  !*** ./src/app/components/node-details/node-details.component.scss ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvbm9kZS1kZXRhaWxzL25vZGUtZGV0YWlscy5jb21wb25lbnQuc2NzcyJ9 */"

/***/ }),

/***/ "./src/app/components/node-details/node-details.component.ts":
/*!*******************************************************************!*\
  !*** ./src/app/components/node-details/node-details.component.ts ***!
  \*******************************************************************/
/*! exports provided: NodeDetailsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NodeDetailsComponent", function() { return NodeDetailsComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var src_app_services_nodes_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! src/app/services/nodes.service */ "./src/app/services/nodes.service.ts");




var NodeDetailsComponent = /** @class */ (function () {
    function NodeDetailsComponent(nodesService, route, router) {
        var _this = this;
        this.nodesService = nodesService;
        this.route = route;
        this.router = router;
        route.params.subscribe(function (val) {
            _this.NodeId = _this.route.snapshot.paramMap.get('id');
            _this.getAllNodes();
        });
    }
    NodeDetailsComponent.prototype.ngOnInit = function () {
        this.NodeId = this.route.snapshot.paramMap.get('id');
        this.getAllNodes();
    };
    NodeDetailsComponent.prototype.getAllNodes = function () {
        var _this = this;
        this.nodesService.getNodes().subscribe(function (data) {
            console.log(data);
            _this.Nodes = data;
            _this.getNode();
        });
    };
    NodeDetailsComponent.prototype.getNode = function () {
        var _this = this;
        this.Node = this.Nodes.filter(function (n) { return n.Id == _this.NodeId; })[0];
        this.DefaultNode = this.Nodes.filter(function (n) { return n.Id == _this.Node.DefaultNodeId; })[0];
    };
    NodeDetailsComponent.prototype.onDuplicateNode = function () {
        this.Node.Id = null;
        this.NodeId = null;
    };
    NodeDetailsComponent.prototype.onSaveNode = function () {
        if (!this.Node.Id) {
            this.addNode();
        }
        else {
            this.updateNode();
        }
    };
    NodeDetailsComponent.prototype.onDeleteNode = function () {
        this.deleteNode();
    };
    NodeDetailsComponent.prototype.updateNode = function () {
        var _this = this;
        this.nodesService.updateNode(this.Node.Id, this.Node).subscribe(function (data) {
            _this.router.navigate(['/node-details/' + data.Id]).then(function (nav) {
                console.log(nav); // true if navigation is successful      
            }, function (err) {
                console.log(err); // when there's an error
            });
        });
    };
    NodeDetailsComponent.prototype.addNode = function () {
        var _this = this;
        this.nodesService.addNode(this.Node).subscribe(function (data) {
            _this.router.navigate(['/node-details/' + data.Id]).then(function (nav) {
                console.log(nav); // true if navigation is successful 
            }, function (err) {
                console.log(err); // when there's an error
            });
        });
    };
    NodeDetailsComponent.prototype.deleteNode = function () {
        var _this = this;
        this.nodesService.deleteNode(this.Node.Id).subscribe(function (data) {
            _this.router.navigate(['/nodes']).then(function (nav) {
                console.log(nav); // true if navigation is successful        
            }, function (err) {
                console.log(err); // when there's an error
            });
        });
    };
    NodeDetailsComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-node-details',
            template: __webpack_require__(/*! ./node-details.component.html */ "./src/app/components/node-details/node-details.component.html"),
            styles: [__webpack_require__(/*! ../../app.component.scss */ "./src/app/app.component.scss"), __webpack_require__(/*! ./node-details.component.scss */ "./src/app/components/node-details/node-details.component.scss")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [src_app_services_nodes_service__WEBPACK_IMPORTED_MODULE_3__["NodesService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]])
    ], NodeDetailsComponent);
    return NodeDetailsComponent;
}());



/***/ }),

/***/ "./src/app/components/nodes/nodes.component.html":
/*!*******************************************************!*\
  !*** ./src/app/components/nodes/nodes.component.html ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"Nodes.length>0\">\r\n    <mat-form-field>\r\n        <input matInput (keyup)=\"applyFilter($event.target.value)\" placeholder=\"Filter\">\r\n    </mat-form-field>\r\n  <table mat-table  [dataSource]=NodesData>\r\n      <ng-container matColumnDef=\"name\">\r\n          <th mat-header-cell *matHeaderCellDef> Name </th>\r\n          <td mat-cell *matCellDef=\"let node\"> {{node.Name}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"hostDestinationId\">\r\n          <th mat-header-cell *matHeaderCellDef> Host Destination Id </th>\r\n          <td mat-cell *matCellDef=\"let node\"> {{node.HostDestinationId}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"speed\">\r\n          <th mat-header-cell *matHeaderCellDef> Speed (mm/s) </th>\r\n          <td mat-cell *matCellDef=\"let node\">{{node.Speed | number:'1.3'}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"size\">\r\n          <th mat-header-cell *matHeaderCellDef> Size (mm) </th>\r\n          <td mat-cell *matCellDef=\"let node\"> {{node.Size | number:'1.3'}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"positionX\">\r\n            <th mat-header-cell *matHeaderCellDef> Position X (mm) </th>\r\n            <td mat-cell *matCellDef=\"let node\"> {{node.PositionX | number:'1.3'}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"positionY\">\r\n            <th mat-header-cell *matHeaderCellDef> Position Y (mm) </th>\r\n            <td mat-cell *matCellDef=\"let node\"> {{node.PositionY | number:'1.3'}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"rotation\">\r\n            <th mat-header-cell *matHeaderCellDef> Rotation (º) </th>\r\n            <td mat-cell *matCellDef=\"let node\"> {{node.Rotation | number:'1.3'}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"curvature\">\r\n            <th mat-header-cell *matHeaderCellDef> Curvature (º) </th>\r\n            <td mat-cell *matCellDef=\"let node\"> {{node.Curvature | number:'1.3'}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"next\">\r\n          <th mat-header-cell *matHeaderCellDef> Next </th>\r\n          <td mat-cell *matCellDef=\"let node\"> {{getNodeName(node.DefaultNextId)}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"occurs\">\r\n          <th mat-header-cell *matHeaderCellDef> Occurs (mm) </th>\r\n          <td mat-cell *matCellDef=\"let node\"> {{node.DefaultNextOccurs | number:'1.3'}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"continues\">\r\n          <th mat-header-cell *matHeaderCellDef> Continues (mm) </th>\r\n          <td mat-cell *matCellDef=\"let node\"> {{node.DefaultNextContinues | number:'1.3'}} </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"details\">\r\n          <th mat-header-cell *matHeaderCellDef> </th>\r\n          <td mat-cell *matCellDef=\"let node\">\r\n              <a routerLink=\"/node-details/{{node.Id}}\"  matTooltip=\"Details\"><mat-icon>description</mat-icon></a>        \r\n          </td>\r\n      </ng-container>\r\n      <ng-container matColumnDef=\"actions\">\r\n          <th mat-header-cell *matHeaderCellDef> </th>\r\n          <td mat-cell *matCellDef=\"let node\">\r\n              <a routerLink=\"/node-actions/{{node.Id}}\"  matTooltip=\"Actions\"><mat-icon>open_in_new</mat-icon></a>\r\n          </td>\r\n      </ng-container>\r\n      <tr mat-header-row *matHeaderRowDef=\"displayedColumns\"></tr>\r\n      <tr mat-row *matRowDef=\"let row; columns: displayedColumns;\"></tr>\r\n\r\n\r\n  </table>\r\n</div>\r\n<div >\r\n  <span>\r\n    <h5> Updated:</h5>\r\n  </span>{{LastTracked| date :  \"HH:mm:ss\"}}\r\n</div>"

/***/ }),

/***/ "./src/app/components/nodes/nodes.component.scss":
/*!*******************************************************!*\
  !*** ./src/app/components/nodes/nodes.component.scss ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2NvbXBvbmVudHMvbm9kZXMvbm9kZXMuY29tcG9uZW50LnNjc3MifQ== */"

/***/ }),

/***/ "./src/app/components/nodes/nodes.component.ts":
/*!*****************************************************!*\
  !*** ./src/app/components/nodes/nodes.component.ts ***!
  \*****************************************************/
/*! exports provided: NodesComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NodesComponent", function() { return NodesComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm5/material.es5.js");
/* harmony import */ var _services_nodes_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/nodes.service */ "./src/app/services/nodes.service.ts");




var NodesComponent = /** @class */ (function () {
    function NodesComponent(nodesService) {
        this.nodesService = nodesService;
        this.Nodes = [];
        this.NodesData = [];
        this.displayedColumns = ['name', 'hostDestinationId', 'speed', 'size', 'positionX', 'positionY', 'rotation', 'curvature', 'next', 'occurs', 'continues', 'details', 'actions'];
    }
    NodesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.nodesService.getNodes().subscribe(function (data) {
            console.log(data);
            _this.Nodes = data;
            _this.NodesData = new _angular_material__WEBPACK_IMPORTED_MODULE_2__["MatTableDataSource"](_this.Nodes);
        });
    };
    NodesComponent.prototype.getNodeName = function (nodeId) {
        var node = this.Nodes.filter(function (n) { return n.Id == nodeId; })[0];
        if (node) {
            return node.Name;
        }
    };
    NodesComponent.prototype.applyFilter = function (filterValue) {
        this.NodesData.filter = filterValue.trim().toLowerCase();
    };
    NodesComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-nodes',
            template: __webpack_require__(/*! ./nodes.component.html */ "./src/app/components/nodes/nodes.component.html"),
            styles: [__webpack_require__(/*! ../../app.component.scss */ "./src/app/app.component.scss"), __webpack_require__(/*! ./nodes.component.scss */ "./src/app/components/nodes/nodes.component.scss")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_services_nodes_service__WEBPACK_IMPORTED_MODULE_3__["NodesService"]])
    ], NodesComponent);
    return NodesComponent;
}());



/***/ }),

/***/ "./src/app/components/sorter/sorter.component.html":
/*!*********************************************************!*\
  !*** ./src/app/components/sorter/sorter.component.html ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div *ngIf=\"physicsConfig\">\r\n  <button mat-button [ngClass]=\"{\r\n        'is-start':true,\r\n        'is-inactive': physicsConfig.timeLapseSpeed==0}\" ng-show (click)=\"startSorter(1)\"><mat-icon>play_arrow</mat-icon></button>\r\n  <button mat-button color=\"warn\" [ngClass]=\"{\r\n          'is-stop':true,\r\n          'is-inactive': physicsConfig.timeLapseSpeed>0}\" (click)=\"startSorter(0)\"><mat-icon>stop</mat-icon></button>\r\n\r\n  <button mat-button [ngClass]=\"{\r\n          'is-inactive': physicsConfig.timeLapseSpeed==0}\"\r\n    (click)=\"startSorter(physicsConfig.timeLapseSpeed*0.5)\"><mat-icon>fast_rewind</mat-icon></button>\r\n  <button mat-flat-button>{{physicsConfig.timeLapseSpeed}}x</button>\r\n  <button mat-button [ngClass]=\"{\r\n       'button':true,\r\n       'is-inactive': physicsConfig.timeLapseSpeed==0}\" ng-show\r\n    (click)=\"startSorter(physicsConfig.timeLapseSpeed*2)\"><mat-icon>fast_forward</mat-icon></button>\r\n\r\n</div>\r\n<div>\r\n  <input matInput [(ngModel)]=\"barcodeToRead\" placeholder=\"Barcode to read\" />\r\n  <input matInput [(ngModel)]=\"weightToWeigh\" placeholder=\"Weight to weigh\" />\r\n  <input matInput [(ngModel)]=\"sorterProportion\" placeholder=\"Sorter Proportion\" />\r\n  <input matInput [(ngModel)]=\"translateX\" placeholder=\"Translate X\" />\r\n  <input matInput [(ngModel)]=\"translateY\" placeholder=\"Translate Y\" />\r\n</div>\r\n<mat-card class=\"sorter-area-container\">\r\n <svg class=\"sorter-area\">\r\n    <path *ngFor=\"let path of nodePaths\" [attr.d]=\"path.path\" [attr.stroke-width]=\"path.width\"\r\n      [attr.stroke]=\"path.stroke\" (click)=\"onNodeSelect(path.node)\" fill=\"none\" stroke-opacity=\"0.8\">\r\n      <title>{{path.node.name}}</title>\r\n    </path>\r\n    <path *ngFor=\"let path of trackingPaths\" [attr.d]=\"path.path\" [attr.stroke-width]=\"path.width\"\r\n      [attr.stroke]=\"path.stroke\" (click)=\"onTrackingSelect(path.tracking)\" [attr.stroke-opacity]=\"path.tracking.present?'0.8':'0.4'\" >\r\n      <title>{{path.tracking.pic}}</title>\r\n    </path>\r\n  </svg>\r\n</mat-card>\r\n\r\n<div class=\"node-control-container\" *ngIf=\"nodeSelected\">\r\n  <mat-card>\r\n      <div>\r\n        <span>\r\n          Node {{nodeSelected.name}}\r\n        </span>\r\n          <a routerLink=\"/node-details/{{nodeSelected.id}}\"  matTooltip=\"Details\"><mat-icon>description</mat-icon></a>\r\n        \r\n        \r\n      </div>\r\n      <div>\r\n        <button mat-button (click)=\"onAddParcel(nodeSelected)\"><mat-icon>add</mat-icon></button>\r\n        <button mat-button [ngClass]=\"{\r\n                    'is-start':true,\r\n                    'is-inactive': nodeSelected.isStopped}\" ng-show (click)=\"onStart(nodeSelected)\"><mat-icon>play_arrow</mat-icon></button>\r\n        <button mat-button color=\"warn\" [ngClass]=\"{\r\n                      'is-stop':true,\r\n                      'is-inactive': !nodeSelected.isStopped}\" (click)=\"onStop(nodeSelected)\"><mat-icon>stop</mat-icon></button>\r\n      </div>\r\n  </mat-card>\r\n</div>\r\n<div class=\"tracking-control-container\"  *ngIf=\"nodeSelected\" >  \r\n    <mat-card *ngFor=\"let tracking of getTrackings(nodeSelected.id)\">\r\n      <div>\r\n        <div>\r\n          <span>Pic {{tracking.pic}}</span>\r\n        </div>\r\n        <div>\r\n          <span>Position {{tracking.currentPosition | number:'1.3'}}</span>\r\n        </div>\r\n        <div>\r\n          <button mat-button color=\"warn\" (click)=\"onRemoveTracking(tracking)\"><mat-icon>delete_forever</mat-icon></button>\r\n        </div>\r\n      </div>\r\n    </mat-card>\r\n</div>\r\n<div class=\"clear\"></div>\r\n<div>\r\n  <span>\r\n    <h5> Updated:</h5>\r\n  </span>{{lastTracked| date :  \"HH:mm:ss\"}}\r\n</div>"

/***/ }),

/***/ "./src/app/components/sorter/sorter.component.scss":
/*!*********************************************************!*\
  !*** ./src/app/components/sorter/sorter.component.scss ***!
  \*********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".sorter-area-container {\n  overflow-y: scroll;\n  overflow-x: scroll;\n  float: left;\n  width: 80%;\n  height: 75%;\n  margin: 2px; }\n\n.node-control-container {\n  float: left;\n  width: 15%;\n  margin: 1px; }\n\n.tracking-control-container {\n  float: left;\n  width: 15%;\n  margin: 1px; }\n\n.clear {\n  clear: left; }\n\n.sorter-area {\n  width: 500%;\n  height: 500%; }\n\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvY29tcG9uZW50cy9zb3J0ZXIvRDpcXFByb2plY3RzXFxFZHNTb3J0ZXJFbXVsYXRvclxcRWRzU29ydGVyRW11bGF0b3JcXGVkcy5zb3J0ZXJlbXVsYXRvclxcZWRzLnNvcnRlcmVtdWxhdG9yLmNsaWVudFxcV2ViQ2xpZW50L3NyY1xcYXBwXFxjb21wb25lbnRzXFxzb3J0ZXJcXHNvcnRlci5jb21wb25lbnQuc2NzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtFQUNJLGtCQUFpQjtFQUNqQixrQkFBaUI7RUFDakIsV0FBVztFQUNYLFVBQVU7RUFDVixXQUFVO0VBQ1YsV0FBVyxFQUFBOztBQUdmO0VBQ0ksV0FBVTtFQUNWLFVBQVU7RUFDVixXQUFXLEVBQUE7O0FBRWY7RUFDSSxXQUFVO0VBQ1YsVUFBVTtFQUNWLFdBQVcsRUFBQTs7QUFFZjtFQUNJLFdBQVcsRUFBQTs7QUFFZjtFQUVJLFdBQVc7RUFDWCxZQUFXLEVBQUEiLCJmaWxlIjoic3JjL2FwcC9jb21wb25lbnRzL3NvcnRlci9zb3J0ZXIuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIuc29ydGVyLWFyZWEtY29udGFpbmVye1xyXG4gICAgb3ZlcmZsb3cteTpzY3JvbGw7XHJcbiAgICBvdmVyZmxvdy14OnNjcm9sbDtcclxuICAgIGZsb2F0OiBsZWZ0O1xyXG4gICAgd2lkdGg6IDgwJTsgXHJcbiAgICBoZWlnaHQ6NzUlO1xyXG4gICAgbWFyZ2luOiAycHg7XHJcblxyXG59XHJcbi5ub2RlLWNvbnRyb2wtY29udGFpbmVye1xyXG4gICAgZmxvYXQ6bGVmdDtcclxuICAgIHdpZHRoOiAxNSU7XHJcbiAgICBtYXJnaW46IDFweDtcclxufVxyXG4udHJhY2tpbmctY29udHJvbC1jb250YWluZXJ7XHJcbiAgICBmbG9hdDpsZWZ0O1xyXG4gICAgd2lkdGg6IDE1JTtcclxuICAgIG1hcmdpbjogMXB4O1xyXG59XHJcbi5jbGVhcntcclxuICAgIGNsZWFyOiBsZWZ0O1xyXG59XHJcbi5zb3J0ZXItYXJlYXtcclxuICAgIFxyXG4gICAgd2lkdGg6IDUwMCU7IFxyXG4gICAgaGVpZ2h0OjUwMCU7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/components/sorter/sorter.component.ts":
/*!*******************************************************!*\
  !*** ./src/app/components/sorter/sorter.component.ts ***!
  \*******************************************************/
/*! exports provided: SorterComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SorterComponent", function() { return SorterComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var _services_nodes_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../services/nodes.service */ "./src/app/services/nodes.service.ts");
/* harmony import */ var _services_parcels_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../services/parcels.service */ "./src/app/services/parcels.service.ts");
/* harmony import */ var _services_physics_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../services/physics.service */ "./src/app/services/physics.service.ts");
/* harmony import */ var _Dto_NewParcelDto__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../Dto/NewParcelDto */ "./src/app/Dto/NewParcelDto.ts");
/* harmony import */ var _services_tracking_service__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ../../services/tracking.service */ "./src/app/services/tracking.service.ts");
/* harmony import */ var src_app_services_sorter_service__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! src/app/services/sorter.service */ "./src/app/services/sorter.service.ts");
/* harmony import */ var _angular_material__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! @angular/material */ "./node_modules/@angular/material/esm5/material.es5.js");










var SorterComponent = /** @class */ (function () {
    function SorterComponent(sorterService, trackingService, nodesService, parcelsService, physicsService, snackBar) {
        this.sorterService = sorterService;
        this.trackingService = trackingService;
        this.nodesService = nodesService;
        this.parcelsService = parcelsService;
        this.physicsService = physicsService;
        this.snackBar = snackBar;
        this.nodePaths = [];
        this.trackingPaths = [];
        this.translateX = 0;
        this.translateY = 0;
        this.sorterProportion = 0.0095;
        this.parcels = [];
        this.nodes = [];
        this.trackings = [];
    }
    SorterComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.subscriveEvents();
        this.refreshDrawingsInterval = Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["interval"])(1000 / 60);
        this.refreshDrawingsInterval.subscribe(function (n) { return _this.drawSorterArea(); });
        this.loadPhysics();
        this.loadTracking();
        this.loadNodes();
        this.loadParcels();
    };
    SorterComponent.prototype.subscriveEvents = function () {
        var _this = this;
        this.trackingService.updateTracking.subscribe(function (data) {
            console.log(data);
            _this.trackings = _this.trackings.filter(function (t) { return t.id != data.id; });
            _this.trackings.push(data);
        });
        this.trackingService.deleteTracking.subscribe(function (data) {
            console.log(data);
            _this.trackings = _this.trackings.filter(function (t) { return t.id != data.id; });
        });
        this.nodesService.updateNodes.subscribe(function (data) {
            console.log(data);
            _this.nodes = _this.nodes.filter(function (n) { return n.id != data.id; });
            _this.nodes.push(data);
        });
        this.nodesService.deleteNodes.subscribe(function (data) {
            console.log(data);
            _this.nodes = _this.nodes.filter(function (n) { return n.id != data.id; });
        });
    };
    SorterComponent.prototype.onAddParcel = function (node) {
        var parcelDto = new _Dto_NewParcelDto__WEBPACK_IMPORTED_MODULE_6__["NewParcelDto"]();
        parcelDto.barcodeToRead = this.barcodeToRead;
        parcelDto.weightToWeigh = this.weightToWeigh;
        parcelDto.nodeId = node.id;
        this.parcelsService.addParcel(parcelDto).subscribe(function (data) {
        });
    };
    SorterComponent.prototype.onStop = function (node) {
        node.isStopped = true;
        this.sorterService.updateNode(node.id, node).subscribe(function (data) {
        });
    };
    SorterComponent.prototype.onStart = function (node) {
        node.IsStopped = false;
        this.sorterService.updateNode(node.id, node).subscribe(function (data) {
        });
    };
    SorterComponent.prototype.startSorter = function (i) {
        var _this = this;
        this.physicsConfig.timeLapseSpeed = i;
        this.physicsService.addPhysic(this.physicsConfig).subscribe(function (data) {
            _this.physicsConfig = data;
        });
    };
    SorterComponent.prototype.loadNodes = function () {
        var _this = this;
        this.lastTracked = new Date();
        this.nodesService.getNodes().subscribe(function (data) {
            _this.nodes = data;
            _this.drawSorterArea();
        });
    };
    SorterComponent.prototype.loadTracking = function () {
        var _this = this;
        this.lastTracked = new Date();
        this.trackingService.getTracking().subscribe(function (data) {
            console.log(data);
            _this.trackings = data;
        });
    };
    SorterComponent.prototype.loadParcels = function () {
        var _this = this;
        this.lastTracked = new Date();
        this.parcelsService.getParcels().subscribe(function (data) {
            _this.parcels = data;
        });
    };
    SorterComponent.prototype.loadPhysics = function () {
        var _this = this;
        this.physicsService.getPhysic(0).subscribe(function (data) {
            _this.physicsConfig = data;
        });
    };
    SorterComponent.prototype.getNodeName = function (nodeId) {
        var node = this.nodes.filter(function (n) { return n.id == nodeId; })[0];
        if (node) {
            return node.name;
        }
    };
    SorterComponent.prototype.getNode = function (nodeId) {
        var node = this.nodes.filter(function (n) { return n.id == nodeId; })[0];
        if (node) {
            return node;
        }
    };
    SorterComponent.prototype.getTracking = function (trackingId) {
        var tracking = this.trackings.filter(function (t) { return t.id == trackingId; })[0];
        if (tracking) {
            return tracking;
        }
    };
    SorterComponent.prototype.getTrackings = function (nodeId) {
        return this.trackings.filter(function (p) { return p.currentNodeId == nodeId; }).sort(function (a, b) { return a.currentPosition < b.currentPosition ? -1 : a.currentPosition > b.currentPosition ? 1 : 0; });
    };
    SorterComponent.prototype.getParcel = function (pic) {
        var parcel = this.parcels.filter(function (p) { return p.pic == pic; })[0];
        if (parcel) {
            return parcel;
        }
    };
    SorterComponent.prototype.onRemoveTracking = function (tracking) {
        var _this = this;
        this.parcelsService.deleteParcel(tracking.pic).subscribe(function (data) {
            _this.trackingSelected = null;
        });
    };
    SorterComponent.prototype.drawSorterArea = function () {
        var _this = this;
        this.trackingPaths = this.trackingPaths.filter(function (trackingPath) { return _this.trackings.find(function (t) { return t.id != trackingPath.tracking.id; }); });
        this.nodePaths = this.nodePaths.filter(function (nodePath) { return _this.nodes.find(function (n) { return n.id != nodePath.node.id; }); });
        console.log(this.nodePaths);
        this.nodes.forEach(function (node) { return _this.updateNodePath(node); });
    };
    SorterComponent.prototype.updateNodePath = function (node) {
        var _this = this;
        var isSelected = this.nodeSelected && this.nodeSelected.id == node.id;
        var isStopped = node.isStopped;
        var posX = (node.positionX + this.translateX) * this.sorterProportion;
        var posY = (node.positionY + this.translateY) * this.sorterProportion;
        var size = node.size * this.sorterProportion;
        var radRotation = node.rotation * Math.PI / 180;
        var radCurvature = node.curvature * Math.PI / 180;
        var stroke = isStopped ? isSelected ? 'Red' : 'DarkRed' : isSelected ? 'Lime' : 'Green';
        var width = 1000 * this.sorterProportion;
        var path = "M" + posX + " " + posY + " ";
        if (radCurvature == 0) {
            var x1 = posX + Math.cos(radRotation) * size;
            var y1 = posY + Math.sin(radRotation) * size;
            path += "L" + x1 + " " + y1 + " ";
        }
        else {
            var sweep = radCurvature > 0 ? 0 : 1;
            var radius = size / radCurvature;
            var chord = Math.sin(radCurvature / 2) * 2 * radius;
            var x1 = posX + Math.cos(radRotation) * chord;
            var y1 = posY + Math.sin(radRotation) * chord;
            path += "A " + radius + " " + radius + " 0 0 " + sweep + " " + x1 + " " + y1 + " ";
        }
        var currentNodePath = this.nodePaths.find(function (np) { return np.node.id == node.id; });
        if (currentNodePath) {
            currentNodePath.node = node;
            currentNodePath.width = width;
            currentNodePath.stroke = stroke;
            currentNodePath.path = path;
        }
        else {
            this.nodePaths.push({ node: node, width: width, stroke: stroke, path: path });
        }
        var trackings = this.getTrackings(node.id);
        if (trackings) {
            trackings.forEach(function (tracking) {
                var isSelected = _this.trackingSelected && _this.trackingSelected.id == tracking.id;
                var stroke = isSelected ? 'Blue' : 'DarkBlue';
                var width = 250 * _this.sorterProportion;
                var radius = 250 * _this.sorterProportion;
                var position = tracking.currentPosition * _this.sorterProportion;
                var ax = posX + (position * Math.cos(radRotation));
                var ay = posY + (position * Math.sin(radRotation)) - radius;
                var bx = posX + (position * Math.cos(radRotation));
                var by = posY + (position * Math.sin(radRotation)) + radius;
                var path = "M" + ax + " " + ay + " ";
                path += "A " + radius + " " + radius + " 0 0 0 " + bx + " " + by + " ";
                path += "A " + radius + " " + radius + " 0 0 0 " + ax + " " + ay + " ";
                var currentTrackingPath = _this.trackingPaths.find(function (tp) { return tp.tracking.id == tracking.id; });
                if (currentTrackingPath) {
                    currentTrackingPath.node = node;
                    currentTrackingPath.width = width;
                    currentTrackingPath.stroke = stroke;
                    currentTrackingPath.path = path;
                }
                else {
                    _this.trackingPaths.push({ tracking: tracking, width: width, stroke: stroke, path: path });
                }
            });
        }
    };
    SorterComponent.prototype.onNodeSelect = function (node) {
        this.snackBar.open(node.name, "", { duration: 1000 });
        this.nodeSelected = node;
    };
    SorterComponent.prototype.onTrackingSelect = function (tracking) {
        this.snackBar.open(tracking.pic, "", { duration: 1000 });
        this.trackingSelected = tracking;
    };
    SorterComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-sorter',
            template: __webpack_require__(/*! ./sorter.component.html */ "./src/app/components/sorter/sorter.component.html"),
            styles: [__webpack_require__(/*! ../../app.component.scss */ "./src/app/app.component.scss"), __webpack_require__(/*! ./sorter.component.scss */ "./src/app/components/sorter/sorter.component.scss")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [src_app_services_sorter_service__WEBPACK_IMPORTED_MODULE_8__["SorterService"],
            _services_tracking_service__WEBPACK_IMPORTED_MODULE_7__["TrackingService"],
            _services_nodes_service__WEBPACK_IMPORTED_MODULE_3__["NodesService"],
            _services_parcels_service__WEBPACK_IMPORTED_MODULE_4__["ParcelsService"],
            _services_physics_service__WEBPACK_IMPORTED_MODULE_5__["PhysicsService"],
            _angular_material__WEBPACK_IMPORTED_MODULE_9__["MatSnackBar"]])
    ], SorterComponent);
    return SorterComponent;
}());



/***/ }),

/***/ "./src/app/material/navigation/navigation.component.css":
/*!**************************************************************!*\
  !*** ./src/app/material/navigation/navigation.component.css ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".sidenav-container {\r\n  height: 100%;\r\n}\r\n\r\n.sidenav {\r\n  width: 200px;\r\n}\r\n\r\n.sidenav {\r\n  background: inherit;\r\n}\r\n\r\n.mat-toolbar.mat-primary {\r\n  position: -webkit-sticky;\r\n  position: sticky;\r\n  top: 0;\r\n  z-index: 1;\r\n}\r\n\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbWF0ZXJpYWwvbmF2aWdhdGlvbi9uYXZpZ2F0aW9uLmNvbXBvbmVudC5jc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFDRSxZQUFZO0FBQ2Q7O0FBRUE7RUFDRSxZQUFZO0FBQ2Q7O0FBRUE7RUFDRSxtQkFBbUI7QUFDckI7O0FBRUE7RUFDRSx3QkFBZ0I7RUFBaEIsZ0JBQWdCO0VBQ2hCLE1BQU07RUFDTixVQUFVO0FBQ1oiLCJmaWxlIjoic3JjL2FwcC9tYXRlcmlhbC9uYXZpZ2F0aW9uL25hdmlnYXRpb24uY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5zaWRlbmF2LWNvbnRhaW5lciB7XHJcbiAgaGVpZ2h0OiAxMDAlO1xyXG59XHJcblxyXG4uc2lkZW5hdiB7XHJcbiAgd2lkdGg6IDIwMHB4O1xyXG59XHJcblxyXG4uc2lkZW5hdiB7XHJcbiAgYmFja2dyb3VuZDogaW5oZXJpdDtcclxufVxyXG5cclxuLm1hdC10b29sYmFyLm1hdC1wcmltYXJ5IHtcclxuICBwb3NpdGlvbjogc3RpY2t5O1xyXG4gIHRvcDogMDtcclxuICB6LWluZGV4OiAxO1xyXG59XHJcbiJdfQ== */"

/***/ }),

/***/ "./src/app/material/navigation/navigation.component.html":
/*!***************************************************************!*\
  !*** ./src/app/material/navigation/navigation.component.html ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-sidenav-container class=\"sidenav-container\">\r\n  <mat-sidenav #drawer class=\"sidenav\" fixedInViewport=\"true\"\r\n      [attr.role]=\"'dialog'\"\r\n      [mode]=\"'over'\"\r\n      [opened]=\"false\">\r\n    <mat-toolbar color=\"primary\">Menu</mat-toolbar>\r\n    <mat-nav-list>\r\n      <a mat-list-item href=\"/sorter\" color=\"primary\">Sorter</a>\r\n      <a mat-list-item href=\"/nodes\" color=\"accent\">Nodes</a>\r\n      <a mat-list-item href=\"/parcels\" color=\"warn\">Parcels</a>\r\n    </mat-nav-list>\r\n  </mat-sidenav>\r\n  <mat-sidenav-content>\r\n    <mat-toolbar color=\"primary\">\r\n      <button\r\n        type=\"button\"\r\n        aria-label=\"Toggle sidenav\"\r\n        mat-icon-button\r\n        (click)=\"drawer.toggle()\">\r\n        <mat-icon aria-label=\"Side nav toggle icon\">menu</mat-icon>\r\n      </button>\r\n      <span>Sorter Emulator Web Client</span>\r\n    </mat-toolbar>\r\n    <router-outlet></router-outlet>\r\n  </mat-sidenav-content>\r\n</mat-sidenav-container>\r\n"

/***/ }),

/***/ "./src/app/material/navigation/navigation.component.ts":
/*!*************************************************************!*\
  !*** ./src/app/material/navigation/navigation.component.ts ***!
  \*************************************************************/
/*! exports provided: NavigationComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NavigationComponent", function() { return NavigationComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_cdk_layout__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/cdk/layout */ "./node_modules/@angular/cdk/esm5/layout.es5.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");




var NavigationComponent = /** @class */ (function () {
    function NavigationComponent(breakpointObserver) {
        this.breakpointObserver = breakpointObserver;
        this.isHandset$ = this.breakpointObserver.observe(_angular_cdk_layout__WEBPACK_IMPORTED_MODULE_2__["Breakpoints"].Handset)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["map"])(function (result) { return result.matches; }));
    }
    NavigationComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-navigation',
            template: __webpack_require__(/*! ./navigation.component.html */ "./src/app/material/navigation/navigation.component.html"),
            styles: [__webpack_require__(/*! ./navigation.component.css */ "./src/app/material/navigation/navigation.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_cdk_layout__WEBPACK_IMPORTED_MODULE_2__["BreakpointObserver"]])
    ], NavigationComponent);
    return NavigationComponent;
}());



/***/ }),

/***/ "./src/app/services/global.service.ts":
/*!********************************************!*\
  !*** ./src/app/services/global.service.ts ***!
  \********************************************/
/*! exports provided: GlobalService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GlobalService", function() { return GlobalService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var GlobalService = /** @class */ (function () {
    //endpoint=window.location.origin + '/api/';
    function GlobalService() {
        this.endpoint = "http://localhost:49494/api/";
    }
    GlobalService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [])
    ], GlobalService);
    return GlobalService;
}());



/***/ }),

/***/ "./src/app/services/nodes.service.ts":
/*!*******************************************!*\
  !*** ./src/app/services/nodes.service.ts ***!
  \*******************************************/
/*! exports provided: NodesService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NodesService", function() { return NodesService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _aspnet_signalr__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @aspnet/signalr */ "./node_modules/@aspnet/signalr/dist/esm/index.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./global.service */ "./src/app/services/global.service.ts");







var httpOptions = {
    headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpHeaders"]({
        'Content-Type': 'application/json'
    })
};
var NodesService = /** @class */ (function () {
    function NodesService(http, globalService) {
        var _this = this;
        this.http = http;
        this.globalService = globalService;
        this.updateNodes = new _angular_core__WEBPACK_IMPORTED_MODULE_1__["EventEmitter"]();
        this.deleteNodes = new _angular_core__WEBPACK_IMPORTED_MODULE_1__["EventEmitter"]();
        this.buildConnection = function () {
            _this.nodesHubConnection = new _aspnet_signalr__WEBPACK_IMPORTED_MODULE_5__["HubConnectionBuilder"]()
                .withUrl(_this.globalService.endpoint + 'NodesHub')
                .build();
        };
        this.startConnection = function () {
            _this.nodesHubConnection
                .start()
                .then(function () { return console.log('Nodes Connection started'); })
                .catch(function (err) { return console.log('Error while starting Nodes connection: ' + err); });
        };
        this.buildConnection();
        this.registerEvents();
        this.startConnection();
    }
    NodesService.prototype.registerEvents = function () {
        var _this = this;
        this.nodesHubConnection.on('UpdateNode', function (data) {
            _this.updateNodes.emit(data);
        });
        this.nodesHubConnection.on('DeleteNode', function (data) {
            _this.deleteNodes.emit(data);
        });
    };
    NodesService.prototype.getNodes = function () {
        return this.http.get(this.globalService.endpoint + 'nodes').pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(this.extractData));
    };
    NodesService.prototype.getNode = function (id) {
        return this.http.get(this.globalService.endpoint + 'nodes/' + id).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(this.extractData));
    };
    NodesService.prototype.addNode = function (node) {
        return this.http.post(this.globalService.endpoint + 'nodes', JSON.stringify(node), httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (node) { return console.log('added node w/ id=${node.id}'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('addNode')));
    };
    NodesService.prototype.updateNode = function (id, node) {
        return this.http.put(this.globalService.endpoint + 'nodes/' + id, JSON.stringify(node), httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log('updated node id=${id}'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('updateNode')));
    };
    NodesService.prototype.deleteNode = function (id) {
        return this.http.delete(this.globalService.endpoint + 'nodes/' + id, httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log('deleted node id=${id}'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('deleteNode')));
    };
    NodesService.prototype.handleError = function (operation, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead
            // TODO: better job of transforming error for user consumption
            console.log(operation + " failed: " + error.message);
            // Let the app keep running by returning an empty result.
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["of"])(result);
        };
    };
    NodesService.prototype.extractData = function (res) {
        var body = res;
        return body || {};
    };
    NodesService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_6__["GlobalService"]])
    ], NodesService);
    return NodesService;
}());



/***/ }),

/***/ "./src/app/services/parcels.service.ts":
/*!*********************************************!*\
  !*** ./src/app/services/parcels.service.ts ***!
  \*********************************************/
/*! exports provided: ParcelsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ParcelsService", function() { return ParcelsService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./global.service */ "./src/app/services/global.service.ts");






var httpOptions = {
    headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpHeaders"]({
        'Content-Type': 'application/json'
    })
};
var ParcelsService = /** @class */ (function () {
    function ParcelsService(http, globalService) {
        this.http = http;
        this.globalService = globalService;
    }
    ParcelsService.prototype.getParcels = function () {
        return this.http.get(this.globalService.endpoint + 'parcels').pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(this.extractData));
    };
    ParcelsService.prototype.getParcel = function (id) {
        return this.http.get(this.globalService.endpoint + 'parcels/' + id).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(this.extractData));
    };
    ParcelsService.prototype.addParcel = function (parcel) {
        console.log(parcel);
        return this.http.post(this.globalService.endpoint + 'parcels', JSON.stringify(parcel), httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function () { return console.log('Parcel added'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('addParcel')));
    };
    ParcelsService.prototype.updateParcel = function (id, parcel) {
        return this.http.put(this.globalService.endpoint + 'parcels/' + id, JSON.stringify(parcel), httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (parcel) { return console.log('Parcel updated'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('updateParcel')));
    };
    ParcelsService.prototype.deleteParcel = function (id) {
        return this.http.delete(this.globalService.endpoint + 'parcels/' + id, httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log("deleted parcel id=" + id); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('deleteParcel')));
    };
    ParcelsService.prototype.handleError = function (operation, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead
            // TODO: better job of transforming error for user consumption
            console.log(operation + " failed: " + error.message);
            // Let the app keep running by returning an empty result.
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["of"])(result);
        };
    };
    ParcelsService.prototype.extractData = function (res) {
        var body = res;
        return body || {};
    };
    ParcelsService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_5__["GlobalService"]])
    ], ParcelsService);
    return ParcelsService;
}());



/***/ }),

/***/ "./src/app/services/physics.service.ts":
/*!*********************************************!*\
  !*** ./src/app/services/physics.service.ts ***!
  \*********************************************/
/*! exports provided: PhysicsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "PhysicsService", function() { return PhysicsService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./global.service */ "./src/app/services/global.service.ts");






var httpOptions = {
    headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpHeaders"]({
        'Content-Type': 'application/json'
    })
};
var PhysicsService = /** @class */ (function () {
    function PhysicsService(http, globalService) {
        this.http = http;
        this.globalService = globalService;
    }
    PhysicsService.prototype.getPhysics = function () {
        return this.http.get(this.globalService.endpoint + 'physics').pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(this.extractData));
    };
    PhysicsService.prototype.getPhysic = function (id) {
        return this.http.get(this.globalService.endpoint + 'physics/' + id, httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(this.extractData));
    };
    PhysicsService.prototype.addPhysic = function (physic) {
        console.log(physic);
        return this.http.post(this.globalService.endpoint + 'physics', JSON.stringify(physic), httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function () { return console.log('Physic added'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('addPhysic')));
    };
    PhysicsService.prototype.updatePhysic = function (id, physic) {
        return this.http.put(this.globalService.endpoint + 'physics/' + id, JSON.stringify(physic), httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (physic) { return console.log('Physic updated'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('updatePhysic')));
    };
    PhysicsService.prototype.deletePhysic = function (id) {
        return this.http.delete(this.globalService.endpoint + 'physics/' + id, httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log("deleted physic id=" + id); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('deletePhysic')));
    };
    PhysicsService.prototype.handleError = function (operation, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead
            // TODO: better job of transforming error for user consumption
            console.log(operation + " failed: " + error.message);
            // Let the app keep running by returning an empty result.
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["of"])(result);
        };
    };
    PhysicsService.prototype.extractData = function (res) {
        var body = res;
        return body || {};
    };
    PhysicsService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({ providedIn: 'root' }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_5__["GlobalService"]])
    ], PhysicsService);
    return PhysicsService;
}());



/***/ }),

/***/ "./src/app/services/sorter.service.ts":
/*!********************************************!*\
  !*** ./src/app/services/sorter.service.ts ***!
  \********************************************/
/*! exports provided: SorterService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SorterService", function() { return SorterService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./global.service */ "./src/app/services/global.service.ts");






var httpOptions = {
    headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpHeaders"]({
        'Content-Type': 'application/json'
    })
};
var SorterService = /** @class */ (function () {
    function SorterService(http, globalService) {
        this.http = http;
        this.globalService = globalService;
    }
    SorterService.prototype.updateNode = function (id, node) {
        return this.http.put(this.globalService.endpoint + 'sorter/' + id, JSON.stringify(node), httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log("updated node id=" + id); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('updateNode')));
    };
    SorterService.prototype.handleError = function (operation, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead
            // TODO: better job of transforming error for user consumption
            console.log(operation + " failed: " + error.message);
            // Let the app keep running by returning an empty result.
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["of"])(result);
        };
    };
    SorterService.prototype.extractData = function (res) {
        var body = res;
        return body || {};
    };
    SorterService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_5__["GlobalService"]])
    ], SorterService);
    return SorterService;
}());



/***/ }),

/***/ "./src/app/services/tracking.service.ts":
/*!**********************************************!*\
  !*** ./src/app/services/tracking.service.ts ***!
  \**********************************************/
/*! exports provided: TrackingService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TrackingService", function() { return TrackingService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _aspnet_signalr__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! @aspnet/signalr */ "./node_modules/@aspnet/signalr/dist/esm/index.js");
/* harmony import */ var _global_service__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./global.service */ "./src/app/services/global.service.ts");







var httpOptions = {
    headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpHeaders"]({
        'Content-Type': 'application/json'
    })
};
var TrackingService = /** @class */ (function () {
    function TrackingService(http, globalService) {
        var _this = this;
        this.http = http;
        this.globalService = globalService;
        this.updateTracking = new _angular_core__WEBPACK_IMPORTED_MODULE_1__["EventEmitter"]();
        this.deleteTracking = new _angular_core__WEBPACK_IMPORTED_MODULE_1__["EventEmitter"]();
        this.buildConnection = function () {
            _this.trackingHubConnection = new _aspnet_signalr__WEBPACK_IMPORTED_MODULE_5__["HubConnectionBuilder"]()
                .withUrl(_this.globalService.endpoint + 'TrackingHub')
                .build();
        };
        this.startConnection = function () {
            _this.trackingHubConnection
                .start()
                .then(function () { return console.log('Tracking Connection started'); })
                .catch(function (err) { return console.log('Error while starting Tracking connection: ' + err); });
        };
        this.buildConnection();
        this.registerEvents();
        this.startConnection();
    }
    TrackingService.prototype.registerEvents = function () {
        var _this = this;
        this.trackingHubConnection.on('UpdateTracking', function (data) {
            _this.updateTracking.emit(data);
        });
        this.trackingHubConnection.on('DeleteTracking', function (data) {
            _this.deleteTracking.emit(data);
        });
    };
    TrackingService.prototype.getTracking = function () {
        return this.http.get(this.globalService.endpoint + 'tracking').pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(this.extractData));
    };
    TrackingService.prototype.deleteTrackingByPic = function (id) {
        return this.http.delete(this.globalService.endpoint + 'tracking/' + id, httpOptions).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return console.log('deleted tracking by pic=${id}'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('deleteTrackingByPic')));
    };
    TrackingService.prototype.handleError = function (operation, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead
            // TODO: better job of transforming error for user consumption
            console.log(operation + " failed: " + error.message);
            // Let the app keep running by returning an empty result.
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["of"])(result);
        };
    };
    TrackingService.prototype.extractData = function (res) {
        var body = res;
        return body || {};
    };
    TrackingService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"], _global_service__WEBPACK_IMPORTED_MODULE_6__["GlobalService"]])
    ], TrackingService);
    return TrackingService;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! D:\Projects\EdsSorterEmulator\EdsSorterEmulator\eds.sorteremulator\eds.sorteremulator.client\WebClient\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map