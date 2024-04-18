import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminComponent } from './Container/admin/admin.component';
import { DriverComponent } from './Container/driver/driver.component';
import { CustomerComponent } from './Container/customer/customer.component';
import { AuthComponent } from './Container/auth/auth.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { NavbarComponent } from './Components/navbar/navbar.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatTableModule } from '@angular/material/table';
import { AdminModule } from './Container/admin/admin.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { AuthModule } from './Container/auth/auth.module';
import { SideNavComponent } from './Components/side-nav/side-nav.component';
import { ManagerComponent } from './Container/manager/manager.component';
import { ManagerModule } from './Container/manager/manager.module';

@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    DriverComponent,
    CustomerComponent,
    ManagerComponent,
    AuthComponent,
    NavbarComponent,
    SideNavComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    RouterModule,
    CommonModule,
    ManagerModule,
    AdminModule,
    AuthModule,
    MatTableModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [provideAnimationsAsync()],
  bootstrap: [AppComponent],
})
export class AppModule {}
