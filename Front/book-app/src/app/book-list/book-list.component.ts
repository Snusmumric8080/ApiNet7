import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';
import { BookRead } from '../book.models';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: BookRead[] = [];

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    console.log("Зашел");
    this.getBooks();
  }

  getBooks(): void {
    this.bookService.getBooks()
      .subscribe(books => this.books = books);
  }
}