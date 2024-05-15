import { Component, OnInit } from '@angular/core';
import { Router} from '@angular/router';

@Component({
  selector: 'app-slidebar',
  templateUrl: './slidebar.component.html',
  styleUrl: './slidebar.component.scss'
})
export class SlidebarComponent implements OnInit {
  module: string = "";
  uri: string = "";

  constructor(
    private router: Router
  ) {
    this.module = this.getModule();
    this.uri = this.router.url;
  }

  ngOnInit(): void {
    this.uri = this.router.url;
  }

  getModule(): string {
    let seg: string[] = this.router.url.split('/');
    return seg[1];
  }

  isActivatedRoute(uri: string): boolean {
    return this.uri === uri;
  }

  redirect(route: string): void {
    this.uri = route;
    this.router.navigate([route]);
  }
}
