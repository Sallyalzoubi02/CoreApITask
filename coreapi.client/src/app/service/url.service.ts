import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlService {

  constructor(private _http: HttpClient) { }

  getAllProduct() {
    return this._http.get("https://localhost:7156/api/Product/GetAllProducts")
  }

  GetAllCategories() {
    return this._http.get("https://localhost:7156/api/Category/GetAllCategories")
  }
}
