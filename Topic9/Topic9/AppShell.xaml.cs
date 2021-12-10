using System;
using System.Collections.Generic;
using Topic9.ViewModels;
using Topic9.Views;
using Xamarin.Forms;

namespace Topic9
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
