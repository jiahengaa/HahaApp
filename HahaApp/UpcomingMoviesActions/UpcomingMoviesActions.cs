using Actions.UpcomingMovies;
using ReduxStyleUI;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReduxCore;

namespace GlobalObject
{
    public class UpcomingMoviesActions
    {
        public static void Register(ReduxStyleForm<AppStore> form)
        {
            var upcomingMoviesActions = form.GlobalObject.AddObject("UpcomingMoviesActions");

            upcomingMoviesActions.AddFunction(new getUpcomingMovies().ToString()).Execute += (func, args) =>
            {
                form.Store.Dispatch(new getUpcomingMovies());
            };

        }
    }
}
