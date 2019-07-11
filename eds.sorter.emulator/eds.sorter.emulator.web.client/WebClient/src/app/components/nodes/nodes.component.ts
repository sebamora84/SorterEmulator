import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material';
import { NodesService } from '../../services/nodes.service';
@Component({
  selector: 'app-nodes',
  templateUrl: './nodes.component.html',
  styleUrls: ['../../app.component.scss','./nodes.component.scss'],
})
export class NodesComponent implements OnInit {
  
  Nodes:any = [];
  NodesData:any = [];
  displayedColumns: string[] = ['name', 'hostDestinationId', 'speed', 'size','positionX','positionY','rotation','curvature', 'next', 'occurs','continues','details', 'actions'];
  constructor(private nodesService:NodesService) { }

  ngOnInit() {    
    this.nodesService.getNodes().subscribe((data:{}) => {
      console.log(data);
      this.Nodes=data;
      this.NodesData = new MatTableDataSource(this.Nodes);
    });
  }
  
  getNodeName(nodeId){
    let node = this.Nodes.filter(n => n.Id==nodeId)[0];
    if(node){
      return node.Name;
    }
  }
  applyFilter(filterValue: string) {
    this.NodesData.filter = filterValue.trim().toLowerCase();
  }
}
