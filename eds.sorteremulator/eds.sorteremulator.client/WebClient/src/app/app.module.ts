import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ViewChild, ElementRef  } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { NgxSvgModule } from 'ngx-svg';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AppMaterialModule } from './app-material.module';
import { NavigationComponent } from './material/navigation/navigation.component';
import { NodesComponent } from './components/nodes/nodes.component';
import { SorterComponent } from './components/sorter/sorter.component';
import { NodeActionsComponent } from './components/node-actions/node-actions.component';
import { ActionDetailsComponent } from './components/action-details/action-details.component';
import { NodeDetailsComponent } from './components/node-details/node-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    NodesComponent,
    SorterComponent,
    NodeActionsComponent,
    ActionDetailsComponent,
    NodeDetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    LayoutModule,
    AppRoutingModule,    
    AppMaterialModule,
    NgxSvgModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
