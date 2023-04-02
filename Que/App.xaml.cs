using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Que
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) // for create DB or don't if already have
        {
            DatabaseFacade facade = new DatabaseFacade(new ApplicationContext());
            facade.EnsureCreated();
        }

    }
}
