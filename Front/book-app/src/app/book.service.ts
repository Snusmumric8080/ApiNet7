import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { BookCreate, BookRead, BookUpdate } from './book.models';

@Injectable({
  providedIn: 'root',
})
export class BookService {
    private baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getBooks(): Observable<BookRead[]> {
    return this.http.get<BookRead[]>(`${this.baseUrl}`);
  }

  getBookById(id: number): Observable<BookRead> {
    return this.http.get<BookRead>(`${this.baseUrl}/${id}`);
  }

  getBookByGuid(guid: string): Observable<BookRead> {
    return this.http.get<BookRead>(`${this.baseUrl}/get/${guid}`);
  }

  createBook(book: BookCreate): Observable<BookRead> {
    return this.http.post<BookRead>(`${this.baseUrl}`, book);
  }

  updateBook(guid: string, book: BookUpdate): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/update/${guid}`, book);
  }

  deleteBook(guid: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/del/${guid}`);
  }
}
