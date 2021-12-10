using System.ComponentModel;
using Topic9.ViewModels;
using Xamarin.Forms;

namespace Topic9.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}