﻿using Actions;
using Actions.PopularActors;
using ReduxCore;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;

namespace Reducers
{
    public class PopularActorsReducer : ElementReducer<PopularActorsState>
    {
        TMDbClient client = new TMDbClient("c6b31d1cdad6a56a23f0c913e2482a31");
        private string defaultImage = "data:image/png;base64,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";
        public PopularActorsReducer()
        {
            Process<getPopularActors>((state, action) =>
            {
                var curState = state;
                var results = client.GetPersonListAsync(TMDbLib.Objects.People.PersonListType.Popular).Result;
                foreach (var item in results.Results)
                {
                    item.ProfilePath = item.ProfilePath == null ? defaultImage : "https://image.tmdb.org/t/p/w200" + item.ProfilePath;
                }
                curState.popularActors = results == null ? new TMDbLib.Objects.General.SearchContainer<TMDbLib.Objects.General.PersonResult>() : results;
                curState.loading = false;
                return curState;
            });
        }
    }
}