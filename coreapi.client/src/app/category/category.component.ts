import { Component } from '@angular/core';
import { UrlService } from '../service/url.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {

  constructor(private ser: UrlService) { }

  ngOnInit() {
    this.getCategorys();
  }

  category: any;
  getCategorys() {
    return this.ser.GetAllCategories().subscribe((data) => {
      console.log("category Data: ", data)
      this.category = data
    }

    )
  }

}
