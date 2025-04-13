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

  updateCategory() {
    if (!this.categoryId || !this.category) {
      this.resultMessage = "Please enter both ID and Name";
      return;
    }

    this.categoryService.updateCategory(this.categoryId, this.category)
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
