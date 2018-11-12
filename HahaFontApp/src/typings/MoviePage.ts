import Datetime from "./Datetime"
import Movie from "./Movie"

interface MoviePage{
    total_pages:number,
    total_results:number,
    page:number,
    dates:Datetime,
    results:[Movie],
    loading:boolean,
}

export default MoviePage