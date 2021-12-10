using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Topic9.Services;
using Topic9.Views;
using Topic9.Views.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Topic9
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            AppCenter.Start("android=3dcb0eff-eb38-42df-abb2-3d70081d39b7;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new ProductsPage());
            //MainPage = new AppShell();
            //try
            //{
            //    Crashes.GenerateTestCrash();
            //}
            //catch (Exception ex)
            //{
            //    Crashes.TrackError(new NotImplementedException());
            //}
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
