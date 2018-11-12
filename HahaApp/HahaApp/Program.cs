using ChromFXUI;
using Reducers;
using ReduxCore;
using Store;
using System;
using System.Windows.Forms;

namespace HahaApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            Config.InitConfig();
            if (Config.IsDebug)
            {
                if (Bootstrap.Load())
                {
                    var appStore = new Package<AppStore>(new StoreReducer());
                    var mainform = new MainForm(appStore);

                    Middlewares.Store.Register(appStore);
                    GlobalObject.PopularActorsActions.Register(mainform);
                    GlobalObject.UpcomingMoviesActions.Register(mainform);

                    Application.Run(mainform);
                }

            }
            else
            {
                if (Bootstrap.Load())
                {
                    Bootstrap.RegisterAssemblyResources(System.Reflection.Assembly.GetExecutingAssembly(), "dist");
                    Bootstrap.RegisterFolderResources(Application.StartupPath);

                    var appStore = new Package<AppStore>(new StoreReducer());
                    var mainform = new MainForm(appStore);

                    Middlewares.Store.Register(appStore);
                    GlobalObject.PopularActorsActions.Register(mainform);
                    GlobalObject.UpcomingMoviesActions.Register(mainform);

                    Application.Run(mainform);
                }
            }
        }
    }
}
