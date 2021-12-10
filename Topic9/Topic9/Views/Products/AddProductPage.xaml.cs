using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic9.Models;
using Topic9.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Topic9.Views.Products
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductPage : ContentPage
    {
        public Product ProductToBeAdded { get; set; }=new Product();
        public AddProductPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        public AddProductPage(Product product)
        {
            InitializeComponent();
            ProductToBeAdded = product;
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(ProductToBeAdded.Id))
            {
                new FirebaseService().AddProduct(ProductToBeAdded);
            }
            else
            {
                new FirebaseService().UpdateProduct(ProductToBeAdded);
            }
            Navigation.PopAsync();
        }
    }
}