import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Movie } from './movie';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  GetMovieDetails(movieId: number) {
    return this.http.get(`https://api.themoviedb.org/3/movie/${movieId}?api_key=90f1a97417721d66d405f554e092a4ba`);
  }

  GetMovies(selectedmode: string, currentpage: number) {
    if (selectedmode == "online") {
      return this.http.get(`https://api.themoviedb.org/3/movie/popular?page=${currentpage}&api_key=90f1a97417721d66d405f554e092a4ba`)
    }
    else {
      return this.http.get(`https://localhost:7090/api/MovieController/GetAllMovies?pageIndex=${currentpage}`)
    }
  }

  InsertMovie(movie: Movie) {
    return this.http.post(`https://localhost:7090/api/MovieController/InsertMovie`, movie);
  }
}
