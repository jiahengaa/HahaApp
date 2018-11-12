import Movie from './Movie'

interface Actor{
    adult:boolean,
    id:number,
    name:string,
    popularity:number,
    profile_path:string,
    known_for:[Movie],
}

export default Actor