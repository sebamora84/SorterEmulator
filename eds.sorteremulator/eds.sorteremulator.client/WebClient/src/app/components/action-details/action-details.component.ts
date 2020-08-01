import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { ActionsService } from '../../services/actions.service';
import { NodesService } from '../../services/nodes.service';

@Component({
  selector: 'app-action-details, json-pipe',
  templateUrl: './action-details.component.html',
  styleUrls: ['../../app.component.scss','./action-details.component.scss']
})
export class ActionDetailsComponent implements OnInit {
  actionId: string;
  action: any;  
  nodes: any;
  constructor( 
    private actionsService:ActionsService,
    private nodesService:NodesService,
    private route: ActivatedRoute,
    private router: Router) { 
      route.params.subscribe(val => {
        this.actionId = this.route.snapshot.paramMap.get('id');
        this.getAllNodes();
        this.getAction();
      });
    }

  ngOnInit() {
    this.actionId = this.route.snapshot.paramMap.get('id');
    this.getAllNodes();
    this.getAction();
  }

  getAction():any{
    this.actionsService.getAction(this.actionId).subscribe((data:{}) => {
      this.action = data;
    });
  }

  getAllNodes(): any {
    this.nodesService.getNodes().subscribe((data:{}) => {
      this.nodes = data;
    });
  }

  onDuplicateAction():void{
    this.action.id=null;
    this.actionId=null;
  }
  onSaveAction():void{
    if(!this.action.id){
      this.addAction();
    }
    else{
      this.updateAction();
    }
  }
  onDeleteAction():void{
   this.deleteAction();
  }
  updateAction(): void {
    console.log(this.action);
    this.actionsService.updateAction(this.actionId, this.action).subscribe((data) => {
      
      this.router.navigate(['/action-details/'+data.id]).then(nav => {
        console.log(nav); // true if navigation is successful      
        
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }
  addAction(): void {
    this.actionsService.addAction(this.action).subscribe((data) => {
      this.router.navigate(['/action-details/'+data.id]).then(nav => {
        console.log(nav); // true if navigation is successful 
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }
  deleteAction(): void {

    this.actionsService.deleteAction(this.actionId).subscribe((data) => {
      this.router.navigate(['/actions']).then(nav => {
        console.log(nav); // true if navigation is successful        
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }

  prettyPrint(uglyJson) {
    return JSON.stringify(JSON.parse(uglyJson), undefined, 4);;
  }
}
