using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using Topic9.Models;
using Xamarin.Forms;

namespace Topic9.Services
{
    public class FirebaseService
    {
        FirebaseClient Client { get; } = new FirebaseClient("https://databasetestingproject-4fa65-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public List<Product> GetAllProducts()
        {
            return Client.Child(nameof(Product)).AsObservable<Product>().AsObservableCollection().ToList();
        }

        public async void AddProduct(Product product)
        {
            var json = JsonConvert.SerializeObject(product);
            var result = await Client.Child(nameof(Product)).PostAsync(json);
            product.Id = result.Key;
            MessagingCenter.Send(this, "NewItemAdded", product);
        }

        public async void DeleteProduct(Product product)
        {
            await Client.Child(nameof(Product)).Child(product.Id).DeleteAsync();
        }

        public async void UpdateProduct(Product product)
        {
            await Client.Child(nameof(Product)).Child(product.Id).PutAsync(product);
        }
    }
}
