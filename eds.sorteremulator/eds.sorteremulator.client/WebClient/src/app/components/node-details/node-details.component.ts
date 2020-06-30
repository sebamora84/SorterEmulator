import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { NodesService } from 'src/app/services/nodes.service';

@Component({
  selector: 'app-node-details',
  templateUrl: './node-details.component.html',
  styleUrls: ['../../app.component.scss','./node-details.component.scss']
})
export class NodeDetailsComponent implements OnInit {
  nodeId: string;
  nodes: any;
  node: any;  
  defaultNode: any;
  constructor(
    private nodesService:NodesService,
    private route: ActivatedRoute,
    private router: Router) {
      route.params.subscribe(val => {        
        this.nodeId = this.route.snapshot.paramMap.get('id');
        this.getAllNodes();
      });
     }
 
  ngOnInit() {
    
    this.nodeId = this.route.snapshot.paramMap.get('id');
    this.getAllNodes();
  }
  getAllNodes(): any {
    this.nodesService.getNodes().subscribe((data:{}) => {
      console.log(data);
      this.nodes = data;    
      this.getNode();
    });
  }
  
  getNode(): void {
    this.node=this.nodes.find(n=>n.id==this.nodeId);
    this.defaultNode=this.nodes.find(n=>n.id==this.node.defaultNodeId);
  }
  onDuplicateNode():void{
    this.node.id=null;
    this.nodeId=null;
  }
  onSaveNode():void{
    if(!this.node.id){
      this.addNode();
    }
    else{
      this.updateNode();
    }
  }
  onDeleteNode():void{
   this.deleteNode();
  }
  updateNode(): void {
    this.nodesService.updateNode(this.node.id, this.node).subscribe((data) => {
      this.router.navigate(['/node-details/'+data.id]).then(nav => {
        console.log(nav); // true if navigation is successful      
        
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }
  addNode(): void {
    this.nodesService.addNode(this.node).subscribe((data) => {
      this.router.navigate(['/node-details/'+data.id]).then(nav => {
        console.log(nav); // true if navigation is successful 
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }
  deleteNode(): void {

    this.nodesService.deleteNode(this.nodeId).subscribe((data) => {
      this.router.navigate(['/nodes']).then(nav => {
        console.log(nav); // true if navigation is successful        
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }

}
