import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, Router } from '@angular/router';
import { NodesService } from 'src/app/services/nodes.service';

@Component({
  selector: 'app-node-details',
  templateUrl: './node-details.component.html',
  styleUrls: ['../../app.component.scss','./node-details.component.scss']
})
export class NodeDetailsComponent implements OnInit {
  NodeId: string;
  Nodes: any;
  Node: any;  
  DefaultNode: any;
  constructor(
    private nodesService:NodesService,
    private route: ActivatedRoute,
    private router: Router) {
      route.params.subscribe(val => {        
        this.NodeId = this.route.snapshot.paramMap.get('id');
        this.getAllNodes();
      });
     }
 
  ngOnInit() {
    
    this.NodeId = this.route.snapshot.paramMap.get('id');
    this.getAllNodes();
  }
  getAllNodes(): any {
    this.nodesService.getNodes().subscribe((data:{}) => {
      console.log(data);
      this.Nodes = data;    
      this.getNode();
    });
  }
  
  getNode(): void {
    
    this.Node=this.Nodes.filter(n=>n.Id==this.NodeId)[0];
    this.DefaultNode=this.Nodes.filter(n=>n.Id==this.Node.DefaultNodeId)[0];
  }
  onDuplicateNode():void{
    this.Node.Id=null;
    this.NodeId=null;
  }
  onSaveNode():void{
    if(!this.Node.Id){
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
    this.nodesService.updateNode(this.Node.Id, this.Node).subscribe((data) => {
      this.router.navigate(['/node-details/'+data.Id]).then(nav => {
        console.log(nav); // true if navigation is successful      
        
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }
  addNode(): void {
    this.nodesService.addNode(this.Node).subscribe((data) => {
      this.router.navigate(['/node-details/'+data.Id]).then(nav => {
        console.log(nav); // true if navigation is successful 
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }
  deleteNode(): void {
    this.nodesService.deleteNode(this.Node.Id).subscribe((data) => {
      this.router.navigate(['/nodes']).then(nav => {
        console.log(nav); // true if navigation is successful        
      }, err => {
        console.log(err) // when there's an error
      });
    });
  }

}
