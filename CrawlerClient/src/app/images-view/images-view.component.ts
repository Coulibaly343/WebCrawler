import { Component, OnInit } from '@angular/core';
import { WebsiteInfo } from '../core/models/websiteinfo.models';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-images-view',
  templateUrl: './images-view.component.html',
  styleUrls: ['./images-view.component.scss']
})
export class ImagesViewComponent implements OnInit {
  websiteInfos: WebsiteInfo[];
  selectedWebsiteInfo: WebsiteInfo;

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.getAllWebsiteInfos().subscribe((data) => {
      this.websiteInfos = data;
    });
  }

  onUrlButtonClick(websiteInfo: WebsiteInfo) {
    this.selectedWebsiteInfo = websiteInfo;
  }

}
