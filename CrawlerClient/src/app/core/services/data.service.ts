import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CrawlWebsiteForm, WebsiteInfo } from '../models/websiteinfo.models';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = environment.baseUrl;
  }

  getAllWebsiteInfos(): Observable<WebsiteInfo[]> {
    return this.http.get(`${this.baseUrl}/websiteInfos`).pipe(
      map((artist: any[]) => artist.map(item => WebsiteInfo.Adapt(item)))
    );
  }

  sendUrl(form: CrawlWebsiteForm) {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post(`${this.baseUrl}/crawlers`, form, { headers });
  }


}
