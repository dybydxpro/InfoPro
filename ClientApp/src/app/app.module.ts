import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule  }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NzModule } from './common/nz.module';
import { BaseChartDirective } from 'ng2-charts';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { GeneralComponent } from './components/general/general.component';
import { NavbarComponent } from './components/common/navbar/navbar.component';
import { DashboardTileComponent } from './components/general/dashboard-tile/dashboard-tile.component';
import { PageNotFoundComponent } from './components/common/page-not-found/page-not-found.component';
import { UnauthorizedComponent } from './components/common/unauthorized/unauthorized.component';
import { DashboardGraphsComponent } from './components/general/dashboard-graphs/dashboard-graphs.component';
import { GraphSegComponent } from './components/general/dashboard-graphs/graph-seg/graph-seg.component';

const routes: Routes = [
  {path: "", component: LoginComponent},
  {path: "register", component: RegisterComponent},
  {path: "home", component: GeneralComponent},
  {path: "unauthorized", component: UnauthorizedComponent},
  {path: "**", component: PageNotFoundComponent},
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    GeneralComponent,
    NavbarComponent,
    DashboardTileComponent,
    PageNotFoundComponent,
    UnauthorizedComponent,
    DashboardGraphsComponent,
    GraphSegComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NzModule,
    BrowserAnimationsModule,
    BaseChartDirective
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
