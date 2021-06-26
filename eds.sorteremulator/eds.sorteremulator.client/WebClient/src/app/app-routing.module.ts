import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NodesComponent } from './components/nodes/nodes.component';
import { SorterComponent } from './components/sorter/sorter.component';
import { NodeDetailsComponent } from './components/node-details/node-details.component';
import { NodeActionsComponent } from './components/node-actions/node-actions.component';
import { ActionDetailsComponent } from './components/action-details/action-details.component';
import { CommunicationConfigComponent } from './components/communication-config/communication-config.component';

const routes: Routes = [
  { path: '', redirectTo: '/sorter', pathMatch: 'full' },
  { path: 'sorter', component: SorterComponent },
  { path: 'nodes', component: NodesComponent },
  { path: 'node-details/:id', component: NodeDetailsComponent },  
  { path: 'node-actions/:id', component: NodeActionsComponent },
  { path: 'action-details/:id', component: ActionDetailsComponent },
  { path: 'communication-config', component: CommunicationConfigComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
