using System;
using System.Collections.Generic;
using System.ComponentModel;
using Topic9.Models;
using Topic9.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Topic9.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}