import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, of } from "rxjs";
import { Inventory } from "../../Models/Inventory.model";
import { ApiResponse } from "../../Models/ApiResponse.model";

@Injectable({ providedIn: 'root' })
export class InventoryService {
  apiUrl = 'http://localhost:5181/api/inventory';

  constructor(private http: HttpClient) {}
  
  getInventories():Observable<ApiResponse>{
    return this.http.get<ApiResponse>(this.apiUrl)
  }
}
