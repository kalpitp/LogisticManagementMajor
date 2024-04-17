import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AdminRoutingModule } from './admin-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { SignupRequestComponent } from './signup-request/signup-request.component';
import { MatTabsModule } from '@angular/material/tabs';
import { SignupRequestTableComponent } from './signup-request/signup-request-table/signup-request-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { ManagerListComponent } from './manager-list/manager-list.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DriverListComponent } from './driver-list/driver-list.component';
import { CustomerListComponent } from './customer-list/customer-list.component';

@NgModule({
  declarations: [
    DashboardComponent,
    SignupRequestComponent,
    SignupRequestTableComponent,
    ManagerListComponent,
    DriverListComponent,
    CustomerListComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    HttpClientModule,
    MatTabsModule,
    MatTableModule,
    MatSortModule,
    MatIconModule,
    MatTooltipModule,
  ],
  exports: [DashboardComponent],
})
export class AdminModule {}
