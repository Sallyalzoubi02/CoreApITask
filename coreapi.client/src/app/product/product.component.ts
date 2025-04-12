import { Component } from '@angular/core';
import { UrlService } from '../service/url.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent {

  constructor(private ser: UrlService) { }

  ngOnInit() {
    this.getProducts();
  }

  products: any;
  getProducts() {
    return this.ser.getAllProduct().subscribe((data) => {
      console.log("Product Data: ", data)
      this.products = data
    }
      
    )
  }

}
