import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BookCreate } from '../book.models';

@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.css']
})
export class BookCreateComponent {
  title: string = '';
  author: string = '';
  year: number | null = null;
  books: BookCreate[] = [];

  constructor(private router: Router) {}

  onBookAdd() {
    if (this.title && this.author && this.year) {
      const newBook: BookCreate = {
        title: this.title,
        author: this.author,
        year: this.year
      };

      this.books.push(newBook);
      this.router.navigate(['/books']);
    }
  }
}
