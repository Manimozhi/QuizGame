import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html'
})
export class WordComponent {
  public categories: Word[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Word[]>(baseUrl + 'words').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));
  }
}

interface Word {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
