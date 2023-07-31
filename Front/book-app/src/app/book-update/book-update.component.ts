import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookUpdate } from '../book.models';
import { BookService } from '../book.service';

@Component({
  selector: 'app-book-update',
  templateUrl: './book-update.component.html',
  styleUrls: ['./book-update.component.css']
})
export class BookUpdateComponent {
  bookId: string;
  book: BookUpdate = { title: '', author: '', year: 0 };

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService,
    private router: Router
  ) {
    this.bookId = this.route.snapshot.params['guid'];
    this.loadBookData();
  }

  onUpdateBook() {
    if (this.book.title && this.book.author && this.book.year !== 0) {
      this.bookService.updateBook(this.bookId, this.book).subscribe(() => {
        this.router.navigate(['/books']);
      });
    }
  }

  private loadBookData() {
    this.bookService.getBookByGuid(this.bookId).subscribe(book => {
      this.book = book;
    });
  }
}