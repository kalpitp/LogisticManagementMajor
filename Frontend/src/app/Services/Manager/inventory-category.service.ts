import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResponse } from '../../Models/ApiResponse.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InventoryCategoryService {
  apiUrl = 'http://localhost:5181/api/inventory-category';

  constructor(private http: HttpClient) {}
  
  getInventories():Observable<ApiResponse>{
    return this.http.get<ApiResponse>(this.apiUrl)
  }
}
