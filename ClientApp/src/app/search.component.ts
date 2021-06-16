import { Component, Input, OnInit } from '@angular/core';
import { Book } from '../Model/Book';
import { BookService } from "../services/book.service";

@Component({
  selector: 'search',
  template: `<div class="container-fluid">
<input [(ngModel)]="searchText" placeholder="Search...">
<div class="table-responsive">
<table class="table table-bordered table-striped table-hover" id="book-table">
  <thead>
    <tr>
      <th >Título </th>
      <th >Year </th>
      <th >Género </th>
      <th ># Pág </th>
      <th >Autor </th>
      <th >Editorial </th>
    </tr>
  </thead>
  <tbody>
    <ng-container *ngFor="let book of books | grdFilter: {title: searchText, author:searchText, publisher:searchText, year: searchText}: false;">
      <tr>
        <td>{{book.title}}</td>
        <td>{{ book.year }}</td>
        <td>{{ book.genre }}</td>
        <td>{{ book.numberPages }}</td>
        <td>{{ book.author }}</td>
        <td>{{ book.publisher }}</td>
      </tr>
    </ng-container>
  </tbody>
</table>
</div>
</div>
`,
  styles: []
})
export class SearchComponent implements OnInit  {

  books: Book[] = [];
  public searchText: string;
  
  @Input() name: string;
  
  constructor(private bookService: BookService) { }

  getBooks(): void {
    this.bookService.getBooks()
      .subscribe(heroes => this.books = heroes);
  }

  ngOnInit() {
    this.getBooks();
  }
}
