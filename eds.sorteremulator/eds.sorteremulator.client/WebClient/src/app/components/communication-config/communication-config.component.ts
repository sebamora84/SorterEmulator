import { CDK_CONNECTED_OVERLAY_SCROLL_STRATEGY_FACTORY } from '@angular/cdk/overlay/typings/overlay-directives';
import { Component, OnInit } from '@angular/core';
import { CommunicationService } from 'src/app/services/communication.service';

@Component({
  selector: 'app-communication-config',
  templateUrl: './communication-config.component.html',
  styleUrls: ['./communication-config.component.scss']
})
export class CommunicationConfigComponent implements OnInit {

  config:any;
  constructor(private comunicationService:CommunicationService) { }

  ngOnInit() {
    this.reloadConfig();
  }

  reloadConfig() {
    this.comunicationService.getCommunicationConfig().subscribe((data:{}) => {
      console.log(data);
      this.config = data;
    });
  }
  onSaveConfig(){
    this.comunicationService.addCommunicationConfig(this.config).subscribe((data:{}) => {
      console.log(data);
      this.config = data;
    });
  }

  onCancelConfig(){
    this.reloadConfig();
  }
}
