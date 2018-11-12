using Actions.ReSet;
using ReduxCore;
using Store;

namespace Middlewares
{
    public class Store
    {
        public static void Register(IBasePackage<AppStore> store)
        {
            store.Middleware(
                curStore => next => action =>
                {
                    next(action);
                },
                curStore => next => action =>
                {
                    if(!(action is ReSetState))
                    {
                        curStore.Dispatch(new ReSetState());
                    }
                    next(action);
                }
                );
        }
    }
}
