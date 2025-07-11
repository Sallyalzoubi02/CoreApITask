import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { CategoryComponent } from './category/category.component';
import { UpdateCategoryComponent } from './update-category/update-category.component';

const routes: Routes = [
  { path: "products", component: ProductComponent },
  { path: "category", component: CategoryComponent },
  { path: "Updatecategory/:id", component: UpdateCategoryComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
