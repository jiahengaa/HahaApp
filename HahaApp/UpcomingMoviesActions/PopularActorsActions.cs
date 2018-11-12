using Actions.PopularActors;
using ReduxStyleUI;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalObject
{
    public class PopularActorsActions
    {
        public static void Register(ReduxStyleForm<AppStore> form)
        {
            var upcomingMoviesActions = form.GlobalObject.AddObject("PopularActorsActions");

            upcomingMoviesActions.AddFunction(new getPopularActors().ToString()).Execute += (func, args) =>
            {
                form.Store.Dispatch(new getPopularActors());
            };
        }
    }
}
