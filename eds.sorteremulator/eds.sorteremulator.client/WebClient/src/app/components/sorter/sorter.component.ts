import { Component, OnInit, HostListener} from '@angular/core';
import { interval } from 'rxjs';
import { ActionsService } from '../../services/actions.service';
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


  nodePaths:any = [];
  trackingPaths:any = [];
  actionPaths:any = [];
  barcodeToRead;
  weightToWeigh;

  isDraging:boolean;
  translateX:number = 0;
  translateY:number = 0;
  sorterProportion : number=0.0095;


  refreshDrawingsInterval: any;
  reloadSorterInterval: any;
  
  actions: any = [];
  parcels: any = [];
  nodes: any = [];
  trackings: any = [];
  physicsConfig: any;
 
  actionSelected: any;
  nodeSelected: any;
  trackingSelected: any;


  constructor(
    private sorterService: SorterService,
    private trackingService: TrackingService,
    private nodesService: NodesService, 
    private parcelsService: ParcelsService, 
    private actionsService: ActionsService, 
    private physicsService: PhysicsService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.subscriveEvents();
    this.refreshDrawingsInterval = interval(1000/60);
    this.refreshDrawingsInterval.subscribe(n => this.drawSorterArea());

    this.reloadSorterInterval = interval(1000);
    this.reloadSorterInterval.subscribe(n => {
      console.log("reloading sorter");
      this.loadPhysics();
      this.loadTracking();
      this.loadActions();
      this.loadParcels();
      this.loadNodes();});

    this.loadPhysics();
    this.loadTracking();
    this.loadActions();
    this.loadParcels();
    this.loadNodes();
  }

  subscriveEvents() {
    this.trackingService.updateTracking.subscribe((data)=>{
      let currentTracking = this.trackings.find(t=>t.id==data.id);
      if(!currentTracking){
        this.trackings.push(data)
        return;
      };
      currentTracking.currentNodeId = data.currentNodeId;
      currentTracking.currentPosition = data.currentPosition;
      currentTracking.destinationNodeId=data.destinationNodeId;
      currentTracking.pic = data.pic;
      currentTracking.present = data.present;

    });
    this.trackingService.deleteTracking.subscribe((data)=>{      
      console.log("Informed Removed tracking "+ data.id);
      this.trackings = this.trackings.filter(t=>t.id!=data.id);
    });

    this.nodesService.updateNodes.subscribe((data)=>{
      this.nodes = this.nodes.filter(n=>n.id!=data.id);
      this.nodes.push(data);
    });
    this.nodesService.deleteNodes.subscribe((data)=>{
      console.log("Informed Removed node "+ data.id);
      this.nodes = this.nodes.filter(n=>n.id!=data.id);
    });

  }
  onNodeAddParcel(node): void {
    var parcelDto = new NewParcelDto();
    parcelDto.barcodeToRead = this.barcodeToRead;
    parcelDto.weightToWeigh = this.weightToWeigh;
    parcelDto.nodeId = node.id;
    this.parcelsService.addParcel(parcelDto).subscribe(
      (data: {}) => {
        
      });
  }
  onNodeStop(node) {
    node.isStopped = true;
    this.sorterService.updateNode(node.id, node).subscribe(
      (data: {}) => {
      });
  }
  onNodeStart(node) {
    node.isStopped = false;
    this.sorterService.updateNode(node.id, node).subscribe(
      (data: {}) => {
      });
  }

  onActionExecute(action): void {
    this.actionsService.executeAction(action.id).subscribe(
      (data: {}) => {
        this.snackBar.open("Manual action executed","",{duration:1000})
      });
  }
  onActionEnable(action) {
    action.disabled = false;
    this.actionsService.updateAction(action.id, action).subscribe(
      (data: {}) => {
      });
  }
  onActionDisable(action) {
    action.disabled = true;
    this.actionsService.updateAction(action.id, action).subscribe(
      (data: {}) => {
      });
  }


  startSorter(i) {
    this.physicsConfig.timeLapseSpeed = i;
    this.physicsService.addPhysic(this.physicsConfig).subscribe((data: {}) => {
      this.physicsConfig = data;
    });
  }
  loadNodes() {
    this.nodesService.getNodes().subscribe((data: {}) => {
      this.nodes = data;            
      this.drawSorterArea();   
    });
  }
  loadTracking() {
    this.trackingService.getTracking().subscribe(
      (data: {}) => {
        this.trackings = data;
      });

  }
  loadActions() {
    this.actionsService.getActions().subscribe(
      (data: {}) => {
        this.actions = data;
      });
  }
  loadParcels() {
    this.parcelsService.getParcels().subscribe(
      (data: {}) => {
        this.parcels = data;
      });
  }
  loadPhysics() {
    this.physicsService.getPhysic(0).subscribe((data: {}) => {
      this.physicsConfig = data;
    });
  }
  
  getNodeName(nodeId) {
    let node = this.nodes.filter(n => n.id == nodeId)[0];
    if (node) {
      return node.name;
    }
  }
  getNode(nodeId) {
    let node = this.nodes.filter(n => n.id == nodeId)[0];
    if (node) {
      return node;
    }
  }
  getTracking(trackingId) {
    let tracking = this.trackings.filter(t => t.id == trackingId)[0];
    if (tracking) {
      return tracking;
    }
  }

  getTrackings(nodeId) {
    return this.trackings.filter(p => p.currentNodeId == nodeId).sort((a, b) => a.currentPosition < b.currentPosition ? -1 : a.currentPosition > b.currentPosition ? 1 : 0);
  }

  getActions(nodeId) {
    return this.actions.filter(p => p.nodeId == nodeId);
  }

  getParcel(pic) {
    let parcel= this.parcels.filter(p => p.pic == pic)[0];
    if (parcel) {
      return parcel;
    }
  }
  onRemoveTracking(tracking): void {
    console.log("Removing tracking "+ tracking.id);
    this.parcelsService.deleteParcel(tracking.pic).subscribe(
      (data: {}) => {
        console.log("Removed tracking "+ tracking.id);
        this.trackingSelected=null;
      });
  }
  
  drawSorterArea() {   
   this.trackingPaths = this.trackingPaths.filter(trackingPath => this.trackings.find(t=>t.id==trackingPath.tracking.id) );
    this.nodePaths = this.nodePaths.filter(nodePath => this.nodes.find(n=>n.id==nodePath.node.id) );
    this.nodes.forEach(node =>this.updateNodePath(node));
  }

  updateNodePath(node){
    let isSelected=this.nodeSelected&&this.nodeSelected.id==node.id;
    let isStopped = node.isStopped;
    let posX = (node.positionX+this.translateX) * this.sorterProportion;
    let posY = (node.positionY+this.translateY) * this.sorterProportion;
    let size = node.size  * this.sorterProportion;      
    let radRotation = node.rotation * Math.PI /180;
    let radCurvature = node.curvature * Math.PI /180;
    let stroke = isStopped?isSelected?'Red':'DarkRed':isSelected?'Lime':'Green';
    let width = 1000 * this.sorterProportion;

   

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


    let currentNodePath = this.nodePaths.find(np=> np.node.id == node.id)
    if(currentNodePath){

      currentNodePath.node=node;
      currentNodePath.width=width;
      currentNodePath.stroke=stroke;
      currentNodePath.path=path;
    }else{
      this.nodePaths.push({node:node, width : width, stroke : stroke, path : path });
    }    

    let trackings = this.getTrackings(node.id);
    if (trackings) {
      trackings.forEach(tracking => {
        let isSelected = this.trackingSelected && this.trackingSelected.id == tracking.id;
        let stroke = isSelected ? 'Blue' : 'DarkBlue';
        let width = 250 * this.sorterProportion;
        let radius = 250 * this.sorterProportion;
        let position = tracking.currentPosition * this.sorterProportion;
        let ax = posX + (position * Math.cos(radRotation));
        let ay = posY + (position * Math.sin(radRotation)) - radius;
        let bx = posX + (position * Math.cos(radRotation));
        let by = posY + (position * Math.sin(radRotation)) + radius;
        let path = "M" + ax + " " + ay + " ";
        path += "A " + radius + " " + radius + " 0 0 0 " + bx + " " + by + " ";
        path += "A " + radius + " " + radius + " 0 0 0 " + ax + " " + ay + " ";

        let currentTrackingPath = this.trackingPaths.find(tp => tp.tracking.id == tracking.id)
        if (currentTrackingPath) {
          currentTrackingPath.node = node;
          currentTrackingPath.width = width;
          currentTrackingPath.stroke = stroke;
          currentTrackingPath.path = path;
        } else {
          this.trackingPaths.push({ tracking: tracking, width: width, stroke: stroke, path: path });
        }
      });
    }

    let actions = this.getActions(node.id);
    if (actions) {
      actions.forEach(action => {
        let isDisabled = action.disabled;
        let isSelected = this.actionSelected && this.actionSelected.id == action.id;
        let stroke = isSelected && !isDisabled ? 'DarkGrey' : 
                     !isSelected && !isDisabled ? 'Grey':
                     isSelected && isDisabled ? 'Red':
                     'DarkRed';
        let width = 500 * this.sorterProportion;
        let radius = 250 * this.sorterProportion;
        let position = action.occurs * this.sorterProportion;
        let ax = posX + (position * Math.cos(radRotation));
        let ay = posY + (position * Math.sin(radRotation)) - radius;
        let bx = posX + (position * Math.cos(radRotation));
        let by = posY + (position * Math.sin(radRotation)) + radius;
        let path = "M" + ax + " " + ay + " ";
        path += "A " + radius + " " + radius + " 0 0 0 " + bx + " " + by + " ";
        path += "A " + radius + " " + radius + " 0 0 0 " + ax + " " + ay + " ";


        let currentActionPath = this.actionPaths.find(ap => ap.action.id == action.id)
        if (currentActionPath) {
          currentActionPath.node = node;
          currentActionPath.width = width;
          currentActionPath.stroke = stroke;
          currentActionPath.path = path;
        } else {
          this.actionPaths.push({ action: action, width: width, stroke: stroke, path: path });
        }
      });
    }
  }





  onNodeSelect(node){
    this.snackBar.open(node.name,"",{duration:1000})
    this.nodeSelected = node; 
  }
  onTrackingSelect(tracking){
    this.snackBar.open(tracking.pic,"",{duration:1000})
    this.trackingSelected = tracking;
  }
  onActionSelect(action){
    this.snackBar.open(action.name,"",{duration:1000})
    this.actionSelected = action;
  }

  onMouseDown(event){
    this.isDraging=true;
  }
  onMouseMove(event){
    if(!event.ctrlKey && this.isDraging){
      this.translateX +=(event.movementX/this.sorterProportion);
      this.translateY +=(event.movementY/this.sorterProportion);
    }
    if(event.ctrlKey && this.isDraging){      
      let proportionIncrement=event.movementY/10000;
      this.sorterProportion+=(proportionIncrement);
    }

  }
  onMouseUp(event){
    this.isDraging=false;
  }


}

