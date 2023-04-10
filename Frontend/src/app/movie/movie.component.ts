import { Component, OnInit, Inject } from '@angular/core';
import { MovieService } from './../movie/movie.service';
import { PageEvent } from '@angular/material/paginator';
import { AddMovieComponent } from './../movie/addmovie.component';
import { MovieDetailsComponent } from './../movie/movie.details/movie.details.component';
import { MatDialog } from '@angular/material/dialog';
import { Movie } from './movie';

@Component({
  selector: 'app-movie',
  templateUrl: './../movie/movie.component.html',
  styleUrls: ['./../movie/movie.component.css']
})

export class MovieComponent implements OnInit {
  title = 'MoviesApplication';

  displayedColumns: string[] = ['title', 'original_language', 'release_date', 'popularity', 'vote_average', 'overview', 'logo'];
  // displayedColumns: any[] = 
  // [{Name:'title',Title:'Title'}, 
  // {Name:'original_language',Title:'Original Language'} ,
  // {Name:'release_date',Title:'Release Date'},
  // {Name:'popularity',Title:'Popularity'},
  // {Name:'vote_average',Title:'Vote Average'},
  // {Name:'overview',Title:'Overview'},
  // {Name:'logo',Title:'Logo'}];

  dataSource: any;

  currentPage = 1;
  totalPages = 0;
  pageSize = 20;
  pages: number[] = [];
  selectedMode = "online";

  constructor(private service: MovieService, private dialogRef: MatDialog) {
    if (this.selectedMode == "online")
      this.displayedColumns.push('Preview');
  }

  ngOnInit(): void {
    this.GetMovies();
  }
  GetMovies() {
    this.service.GetMovies(this.selectedMode, this.currentPage).subscribe((result: any) => {
      this.totalPages = result.total_pages;
      //   this.updatePages();
      this.dataSource = result.results.map((movie: any) => {
        return {
          ...movie,
          logo: `<img src='https://image.tmdb.org/t/p/w500/${movie.poster_path}' alt='Backdrop' width="100" height="auto">`
        };
      });
    });
  }

  getColumnTitle(column: string): string {
    switch (column) {
      case 'title':
        return 'Title';
      case 'original_language':
        return 'Original Language';
      case 'release_date':
        return 'Release Date';
      case 'popularity':
        return 'Popularity';
      case 'vote_average':
        return 'Vote Average';
      case 'overview':
        return 'Overview';
      case 'logo':
        return 'Logo';
      default:
        return column;
    }
  }

  previousPage(): void {
    if (this.currentPage > 1) {
      this.goToPage(this.currentPage - 1);
    }
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.goToPage(this.currentPage + 1);
    }
  }

  goToPage(page: number): void {
    if (this.currentPage !== page) {
      this.currentPage = page;
      this.GetMovies();
    }
  }

  onPageChange(event: PageEvent): void {
    this.currentPage = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.GetMovies();
  }

  // updatePages() {
  //   const maxPages = 10;
  //   const startPage = Math.max(1, this.currentPage - Math.floor(maxPages / 2));
  //   const endPage = Math.min(this.totalPages, startPage + maxPages - 1);

  //   this.pages = [];
  //   for (let i = startPage; i <= endPage; i++) {
  //     this.pages.push(i);
  //   }
  // }

  onModeChange() {
    if (this.selectedMode == "online")
      this.displayedColumns.push('Preview');
    else
      this.displayedColumns.pop();

    this.GetMovies();
  }

  showAddMoviePopup(): void {
    this.dialogRef.open(AddMovieComponent, {
      data: {
      }
    });
  }

  PreviewMovie(element: Movie) {
    this.dialogRef.open(MovieDetailsComponent, {
      data: {
        movieId: element.id
      }
    });
  };
}
