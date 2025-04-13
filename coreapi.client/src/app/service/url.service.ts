import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

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

  updateCategory(id: number, categoryName: string): Observable<any> {
    const body = { id, categoryName };
    return this._http.put(`https://localhost:7156/api/Category/UpdateCategory/{id}`, body);
  }
  getCategoryById(id: number) {
    return this._http.get(`https://localhost:7156/api/Category/GetCategoryByID{id}`)
  }
}
