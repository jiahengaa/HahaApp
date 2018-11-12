import Datetime from "./Datetime"
import Actor from "./Actor"

interface ActorPage{
    loading:boolean,
    popularActors:ActorList,
}

interface ActorList{
    total_pages:number,
    total_results:number,
    page:number,
    dates:Datetime,
    results:[Actor],
}

export default ActorPage