import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material';
import { NodesService } from '../../services/nodes.service';
@Component({
  selector: 'app-nodes',
  templateUrl: './nodes.component.html',
  styleUrls: ['../../app.component.scss','./nodes.component.scss'],
})
export class NodesComponent implements OnInit {
  
  nodes:any = [];
  nodesData:any = [];
  displayedColumns: string[] = ['name', 'hostDestinationId', 'speed', 'size','positionX','positionY','rotation','curvature', 'next', 'occurs','continues','details', 'actions'];
  constructor(private nodesService:NodesService) { }

  ngOnInit() {    
    this.nodesService.getNodes().subscribe((data:{}) => {
      console.log(data);
      this.nodes=data;
      this.nodesData = new MatTableDataSource(this.nodes);
    });
  }
  
  getNodeName(nodeId){
    let node = this.nodes.filter(n => n.id==nodeId)[0];
    if(node){
      return node.name;
    }
  }
  applyFilter(filterValue: string) {
    this.nodesData.filter = filterValue.trim().toLowerCase();
  }
}
