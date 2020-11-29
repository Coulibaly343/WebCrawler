import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CrawlWebsiteForm } from '../core/models/websiteinfo.models';
import { DataService } from '../core/services/data.service';

@Component({
  selector: 'app-form-view',
  templateUrl: './form-view.component.html',
  styleUrls: ['./form-view.component.scss']
})
export class FormViewComponent implements OnInit {
  crawlerFormGroup: FormGroup;
  loading: boolean;
  constructor(
    private dataService: DataService,
    private formBuilder: FormBuilder,
    private router: Router) {

  }

  ngOnInit(): void {
    this.crawlerFormGroup = this.formBuilder.group({
      uri: ['', []]
    });
    this.loading = false;
  }

  onSubmitButtonClick() {
    this.loading = true;
    if (this.crawlerFormGroup.valid) {
      const submitedUri = this.crawlerFormGroup.get('uri').value;
      const form = { uri: submitedUri } as CrawlWebsiteForm;

      this.dataService.sendUrl(form).subscribe(data => {
        if (data) {
          this.router.navigateByUrl('/home/images');
          this.loading = false;
        }
      });
    }

  }
}
