import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html'
})
export class CategoryComponent {
  public categories: Category[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Category[]>(baseUrl + 'categories').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));
  }
}

interface Category {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
