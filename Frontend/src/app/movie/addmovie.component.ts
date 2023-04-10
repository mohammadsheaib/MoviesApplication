import { Component, EventEmitter, Output } from '@angular/core';
import { Movie } from './../movie/movie';
import { MovieService } from './../movie/movie.service';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-addmovie',
  templateUrl: './addmovie.component.html'
})

export class AddMovieComponent {
  form: FormGroup;
  isLoading: boolean;
  constructor(private service: MovieService,
    public dialogRef: MatDialogRef<AddMovieComponent>,
    private formBuilder: FormBuilder) {
    this.isLoading = false;
    this.form = this.formBuilder.group({
      title: ['', Validators.required],
      original_language: ['', Validators.required],
      release_date: ['', Validators.required],
      popularity: ['', Validators.required],
      vote_average: ['', Validators.required],
      overview: ['', Validators.required]
    });
  }
  @Output() onSave = new EventEmitter<any>();

  newMovie: Movie = {
    title: '',
    original_language: '',
    popularity: 0,
    vote_average: 0,
    overview: '',
    //logoFile: null,
    release_date: new Date(),
    id: -1,
    poster_path: ''
  };
  saveMovie(): void {
    this.isLoading = true;
    this.service.InsertMovie(this.newMovie).subscribe((result: any) => {
      this.onSave.emit(this.newMovie);
      this.dialogRef.close();
      this.isLoading = false;
    },
      (error: any) => {
        console.error(error);
        this.isLoading = false;
      });
  }

  handleLogoInput(event: any) {
    //   this.newMovie.logoFile = event.target.files[0];
  }
}
