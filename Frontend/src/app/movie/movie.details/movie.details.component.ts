import { Component, Inject, OnInit } from '@angular/core';
import { MovieService } from './../movie.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MovieDetails } from './movie.details';

@Component({
  selector: 'app-movie.details',
  templateUrl: './movie.details.component.html',
  styleUrls: ['./movie.details.component.css']
})
export class MovieDetailsComponent {

  movieId: number;
  movieDetails: MovieDetails | undefined;

  constructor(private service: MovieService, @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<MovieDetailsComponent>
  ) {
    this.movieId = data.movieId;
  }

  ngOnInit(): void {
    this.GetMovieDetails();
  }

  GetMovieDetails() {
    this.service.GetMovieDetails(this.movieId).subscribe((result: any) => {
      this.movieDetails = result;
    });
  }
  
  close(): void {
    this.dialogRef.close();
  };
}
