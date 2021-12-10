using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Topic9.Models;
using Topic9.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Topic9.Views.Products
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public ObservableCollection<Product> DisplayedProducts { get; set; } = new ObservableCollection<Product>();
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = this;
            MessagingCenter.Subscribe<FirebaseService,Product>(this, "NewItemAdded", (source,item) =>
            {
                DisplayedProducts.Add(item);
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            DisplayedProducts.Clear();
            var products = await new FirebaseService().GetAllProducts();
            foreach(var product in products)
            {
                DisplayedProducts.Add(product);
            }    
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddProductPage());
        }

        public IAsyncCommand<Product> EditCommand => new AsyncCommand<Product>(async (product) =>
        {
            await Navigation.PushAsync(new AddProductPage(product));
        }, allowsMultipleExecutions: false);
        public IAsyncCommand<Product> DeleteCommand => new AsyncCommand<Product>(async (product) =>
        {
            if(await DisplayAlert("", "Delete?", "yes", "no"))
            {
                new FirebaseService().DeleteProduct(product);
            }
        }, allowsMultipleExecutions: false);
    }
}