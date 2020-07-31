import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material';
import { ActionsService } from '../../services/actions.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-node-actions',
  templateUrl: './node-actions.component.html',
  styleUrls: ['./node-actions.component.scss']
})
export class NodeActionsComponent implements OnInit {
  displayedColumns: string[] = ['id','name','nodeEvent', 'occurs', 'continues', 'disabled','stopOnExecution','actionInfo', 'details'];
  nodeId: string;
  actions:any = [];
  actionsData:any = [];

  constructor(private actionsService:ActionsService,   
     private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.nodeId = this.route.snapshot.paramMap.get('id');
    this.actionsService.getActionsByNode(this.nodeId).subscribe((data:{}) => {
      console.log(data);
      this.actions=data;
      this.actionsData = new MatTableDataSource(this.actions);
    });
  }
  applyFilter(filterValue: string) {
    this.actionsData.filter = filterValue.trim().toLowerCase();
  }

}
  