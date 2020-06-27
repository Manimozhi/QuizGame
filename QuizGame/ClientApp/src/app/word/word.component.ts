import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html'
})
export class WordComponent {
  public words: Word[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Word[]>(baseUrl + 'words').subscribe(result => {
      this.words = result;
    }, error => console.error(error));
  }
}

interface Word {
  Id: number;
  Name: string;
  TamilWord: "string";
}
