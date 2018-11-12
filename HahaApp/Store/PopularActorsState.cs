using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.General;

namespace Store
{
    public struct PopularActorsState
    {
        public SearchContainer<PersonResult> popularActors;
        public bool loading;
    }
}
