import { AfterViewInit, Component } from '@angular/core';
import { Router } from '@angular/router';
import { ROUTES_WITHOUT_MENU } from './shared/layout/routes-without-menu';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements AfterViewInit {
  title = 'orangotango';
  loaded = false;

  get showNavbar(): boolean {
    if (!this.loaded) {
      return false;
    }

    return ROUTES_WITHOUT_MENU.some((route) => this.showNavbarFromRoute(route));
  }

  constructor(private route: Router) {}

  ngAfterViewInit() {
    this.loaded = true;
  }

  private showNavbarFromRoute(route: string): boolean {
    const url = this.route.url;
    return !this.isDefaultRoute(url) && !url.includes(route);
  }

  private isDefaultRoute(url: string): boolean {
    return url === '/';
  }
}
