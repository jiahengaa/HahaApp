using ReduxCore;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reducers
{
    public class StoreReducer : ComposableReducer<AppStore>
    {
        public StoreReducer()
        {
            Diverter<UpcomingMoviesState>(state => state.upcomingMovies, new UpcomingMoviesReducer()).
                Diverter<PopularActorsState>(state => state.popularActors, new PopularActorsReducer());
        }
    }
}
