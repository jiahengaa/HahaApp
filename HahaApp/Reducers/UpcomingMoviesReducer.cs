using Actions;
using Actions.UpcomingMovies;
using ReduxCore;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace Reducers
{
    public class UpcomingMoviesReducer : ElementReducer<UpcomingMoviesState>
    {
        private TMDbClient client = new TMDbClient("c6b31d1cdad6a56a23f0c913e2482a31");
        public UpcomingMoviesReducer()
        {
            Process<getUpcomingMovies>((state, action) =>
            {
                var curState = state;
                SearchContainerWithDates<SearchMovie> results =  client.GetMovieUpcomingListAsync().Result;
                foreach(var item in results.Results)
                {
                    item.BackdropPath = "https://image.tmdb.org/t/p/w500" + item.BackdropPath;
                    item.PosterPath = "https://image.tmdb.org/t/p/w500_and_h282_bestv2" + item.PosterPath;
                }
                curState.movies = results;
                curState.loading = false;
                return curState;
            });
        }
    }
}
