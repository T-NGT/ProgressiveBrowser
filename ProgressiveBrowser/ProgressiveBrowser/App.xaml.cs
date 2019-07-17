using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using ProgressiveBrowser.Models;
using ProgressiveBrowser.ViewModels;
using ProgressiveBrowser.Views;

namespace ProgressiveBrowser
{

    public partial class App : PrismApplication
    {

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<ICommunicator>(new HttpCommunicator());
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
    }
}