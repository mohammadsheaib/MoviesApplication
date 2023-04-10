export interface Movie {
  id: number,
  original_language: string,
  popularity: number,
  vote_average: number,
  overview: string,
//  logoFile: File | null,
  release_date: Date,
  title:string,
  poster_path:string|null
}
