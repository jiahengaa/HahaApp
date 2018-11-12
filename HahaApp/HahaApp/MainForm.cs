using System;
using ReduxCore;
using ReduxStyleUI;
using Store;

namespace HahaApp
{
    public partial class MainForm : ReduxStyleForm<AppStore>
    {
        public MainForm(Package<AppStore> store)
            :base(store,Config.BaseUrl + "index.html")
        {
            InitializeComponent();

            this.JsDispatchMethod = "vm.updateData({0})";

            LoadHandler.OnLoadEnd += (sender, e) => { Chromium.ShowDevTools(); };
        }
    }
}
