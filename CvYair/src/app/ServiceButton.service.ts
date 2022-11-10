import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable, Input } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class ServiceButtonService {



constructor(public http : HttpClient) { }


}
