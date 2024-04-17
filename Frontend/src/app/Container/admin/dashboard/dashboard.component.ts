import { Component, OnInit, inject } from '@angular/core';
import { AdminStatisticsService } from '../../../Services/Admin/admin-statistics.service';
import { AdminStatistics } from '../../../Models/AdminStatistics.model';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor() { }

  adminStatisticsService:AdminStatisticsService= inject(AdminStatisticsService);

  statisticsData:AdminStatistics={} as AdminStatistics;
  
  ngOnInit() {
    this.getStatistics();
  }

  getStatistics(){
    this.adminStatisticsService.getAdminStatistics().subscribe({
      next:(res)=>{
        this.statisticsData= res.data as AdminStatistics
      },
      error:(err)=>{
        console.log(err);
        
      }
    })

  }

}
