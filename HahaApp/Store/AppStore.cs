using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace Store
{
    public struct AppStore
    {
        public UpcomingMoviesState upcomingMovies;
        public PopularActorsState popularActors;
    }
}
