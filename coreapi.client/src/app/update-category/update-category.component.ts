import { Component } from '@angular/core';
import { UrlService } from '../service/url.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-category',
  templateUrl: './update-category.component.html',
  styleUrl: './update-category.component.css'
})
export class UpdateCategoryComponent {

  categoryId!: number;
  category: any;
  resultMessage !: string;

  constructor(private route: ActivatedRoute, private categoryService: UrlService) { }

  ngOnInit() {
    // نجيب ال ID من ال URL
    this.categoryId = Number(this.route.snapshot.paramMap.get('id'));

    // نستدعي الكاتيجوري ونحط الاسم بقيمته
    this.categoryService.getCategoryById(this.categoryId).subscribe((data) => this.category =data);
  }

  updateCategory(data:any) {


    var DataF = new FormData();
    DataF.append("categoryName", data.CategoryName);
    DataF.append("categoryDesc", data.CategoryDesc);

    this.categoryService.updateCategory(this.categoryId, DataF)
      .subscribe({
        next: (res) => {
          this.resultMessage = res;
        },
        error: (err) => {
          this.resultMessage = err.error;
        }
      });
  }
}
