import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NzModule } from './../../common/nz.module';
import { NavbarComponent } from './navbar/navbar.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { SlidebarComponent } from './slidebar/slidebar.component';

@NgModule({
  declarations: [NavbarComponent, PageNotFoundComponent, UnauthorizedComponent, SlidebarComponent],
  imports: [
    CommonModule, NzModule
  ],
  exports: [
    NavbarComponent, PageNotFoundComponent, UnauthorizedComponent, SlidebarComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class CommonCompsModule { }
