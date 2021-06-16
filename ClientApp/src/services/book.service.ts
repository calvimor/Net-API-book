import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Book } from '../Model/Book';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  private booksUrl = 'https://localhost:44399/api/books';  // URL to web api
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {    
    return this.http.get<Book[]>(this.booksUrl);
  }
}
