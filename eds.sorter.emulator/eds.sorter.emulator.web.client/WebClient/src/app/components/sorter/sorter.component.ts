import { Component, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { Node } from '../../Model/Node';
import { NodesService } from '../../services/nodes.service';
import { ParcelsService } from '../../services/parcels.service';
import { PhysicsService } from '../../services/physics.service';
import { NewParcelDto } from '../../Dto/NewParcelDto';
import { TrackingService } from '../../services/tracking.service';
import { SorterService } from 'src/app/services/sorter.service';
import {MatButtonModule} from '@angular/material/button';
import {MatSnackBar} from '@angular/material';
@Component({
  selector: 'app-sorter',
  templateUrl: './sorter.component.html',
  styleUrls: ['../../app.component.scss', './sorter.component.scss']
})

export class SorterComponent implements OnInit {
  NodePaths:any = [];
  TrackingPaths:any = [];
  BarcodeToRead;
  WeightToWeigh;
  TranslateX:number = 0;
  TranslateY:number = 0;
  SorterProportion : number=0.0125;

  trackParcelInterval: any;
  trackNodeInterval: any;
  trackTrackingInterval: any;
  trackPhysicsInterval: any;
  
  Parcels: any = [];
  Nodes: any = [];
  Trackings: any = [];
  PhysicsConfig: any;
 
  NodeSelected: any;
  TrackingSelected: any;

  LastTracked;

  constructor(
    private sorterService: SorterService,
    private trackingService: TrackingService,
    private nodesService: NodesService, 
    private parcelsService: ParcelsService, 
    private physicsService: PhysicsService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.trackPhysics(0);
    this.trackTrackingInterval = interval(1000);
    this.trackTrackingInterval.subscribe(n => this.trackTracking(n));
    this.trackParcelInterval = interval(1000);
    this.trackParcelInterval.subscribe(n => this.trackParcels(n));
    this.trackPhysicsInterval = interval(1000);
    this.trackPhysicsInterval.subscribe(n => this.trackPhysics(n));
    this.trackNodeInterval = interval(1000);
    this.trackNodeInterval.subscribe(n => this.trackNode(n));
  }
  onAddParcel(node: Node): void {
    var parcelDto = new NewParcelDto();
    parcelDto.BarcodeToRead = this.BarcodeToRead;
    parcelDto.WeightToWeigh = this.WeightToWeigh;
    parcelDto.NodeId = node.Id;
    this.parcelsService.addParcel(parcelDto).subscribe(
      (data: {}) => {
        console.log(data);

      });
  }
  onStop(node) {
    node.IsStopped = true;
    this.sorterService.updateNode(node.Id, node).subscribe(
      (data: {}) => {
        console.log(data);
      });
  }
  onStart(node) {
    node.IsStopped = false;
    this.sorterService.updateNode(node.Id, node).subscribe(
      (data: {}) => {
        console.log(data);
      });
  }
  trackNode(n) {
    this.LastTracked = new Date();
    this.nodesService.getNodes().subscribe((data: {}) => {
      console.log(data);
      this.Nodes = data;            
      this.drawSorterArea();   
    });
  }
  startSorter(i) {
    this.PhysicsConfig.TimeLapseSpeed = i;
    this.physicsService.addPhysic(this.PhysicsConfig).subscribe((data: {}) => {
      console.log(data);
      this.PhysicsConfig = data;
    });
  }
  trackTracking(n) {
    this.LastTracked = new Date();
    this.trackingService.getTracking().subscribe(
      (data: {}) => {
        console.log(data);
        this.Trackings = data;
                
      this.drawSorterArea();
      });

  }
  trackParcels(n) {
    this.LastTracked = new Date();
    this.parcelsService.getParcels().subscribe(
      (data: {}) => {
        console.log(data);
        this.Parcels = data;
      });
  }
  trackPhysics(n) {
    this.physicsService.getPhysic(0).subscribe((data: {}) => {
      console.log(data);
      this.PhysicsConfig = data;
    });
  }
  
  getNodeName(nodeId) {
    let node = this.Nodes.filter(n => n.Id == nodeId)[0];
    if (node) {
      return node.Name;
    }
  }
  getNode(nodeId) {
    let node = this.Nodes.filter(n => n.Id == nodeId)[0];
    if (node) {
      return node;
    }
  }
  getTracking(trackingId) {
    let tracking = this.Trackings.filter(t => t.Id == trackingId)[0];
    if (tracking) {
      return tracking;
    }
  }

  getTrackings(nodeId) {
    return this.Trackings.filter(p => p.CurrentNodeId == nodeId).sort((a, b) => a.CurrentPosition < b.CurrentPosition ? -1 : a.CurrentPosition > b.CurrentPosition ? 1 : 0);
  }
  getParcel(pic) {
    let parcel= this.Parcels.filter(p => p.Pic == pic)[0];
    if (parcel) {
      return parcel;
    }
  }
  onRemoveTracking(tracking): void {
    this.parcelsService.deleteParcel(tracking.Pic).subscribe(
      (data: {}) => {
        console.log(data);
        this.TrackingSelected=null;
      });
  }
  
  drawSorterArea() {
    let nodePaths=[];
    let trackingPaths=[];
    this.Nodes.forEach(node => {
      let isSelected=this.NodeSelected&&this.NodeSelected.Id==node.Id;

      let isStopped = node.IsStopped;
      let posX = (node.PositionX+this.TranslateX) * this.SorterProportion;
      let posY = (node.PositionY+this.TranslateY) * this.SorterProportion;
      let size = node.Size  * this.SorterProportion;      
      let radRotation = node.Rotation * Math.PI /180;
      let radCurvature = node.Curvature * Math.PI /180;
      let stroke = isStopped?isSelected?'Red':'DarkRed':isSelected?'Lime':'Green';
      let width = 1000 * this.SorterProportion;

      let path="M"+posX+" "+posY+" ";      
      
      if(radCurvature==0){
        let x1 = posX + Math.cos(radRotation)*size;
        let y1 = posY + Math.sin(radRotation)*size;
       path+="L"+x1+" "+y1+" ";

      }
      else{
        let sweep = radCurvature > 0 ? 0 : 1;
        
        let radius = size / radCurvature;
        let chord = Math.sin(radCurvature/2)*2*radius;
        let x1 = posX + Math.cos(radRotation)*chord;
        let y1 = posY + Math.sin(radRotation)*chord;
        
        path+="A "+radius+" "+radius+" 0 0 "+sweep+" "+x1+" "+y1+" ";
      }
      
      let pathElement = {Node:node, Width : width, Stroke : stroke, Path : path };
      nodePaths.push(pathElement);

      let trackings =this.getTrackings(node.Id);
      if(trackings){
        trackings.forEach(tracking => {
          let isSelected=this.TrackingSelected&&this.TrackingSelected.Id==tracking.Id;        
          let stroke =isSelected? 'Blue':'DarkBlue';
          let width = 250 * this.SorterProportion;
          let radius = 250 * this.SorterProportion;
          let position = tracking.CurrentPosition*this.SorterProportion;
          let ax=posX+(position * Math.cos(radRotation));
          let ay=posY+(position * Math.sin(radRotation)) - radius;
          let bx=posX+(position * Math.cos(radRotation));
          let by=posY+(position * Math.sin(radRotation)) + radius;
          let path="M"+ax+" "+ay+" ";
          path +="A "+radius+" "+radius+" 0 0 0 "+bx+" "+by+" ";
          path +="A "+radius+" "+radius+" 0 0 0 "+ax+" "+ay+" ";
          let pathElement = {Tracking:tracking, Width : width, Stroke : stroke, Path : path };
          trackingPaths.push(pathElement);
        });
      }
      
    });
    this.NodePaths=nodePaths;
    this.TrackingPaths=trackingPaths;
  }
  onNodeSelect(node){
    this.snackBar.open(node.Name,"",{duration:1000})
    this.NodeSelected = node; 
    this.drawSorterArea();
  }
  onTrackingSelect(tracking){
    this.snackBar.open(tracking.Pic,"",{duration:1000})
    this.TrackingSelected = tracking;
    this.drawSorterArea();
  }
}

