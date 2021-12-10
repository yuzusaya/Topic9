using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITest.Pages
{
    public class ItemsPage : BasePage
    {
        readonly Query itemsCollectionView;
        readonly Query addButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("AddButton"),
            //iOS = x => x.Marked("Tasky")
        };

        public ItemsPage()
        {
            if (OnAndroid)
            {
                itemsCollectionView = x => x.Marked("ItemsCollectionView");
                addButton = x => x.Marked("AddButton");
            }
        }

        public void GoToAddItemPage()
        {
            app.Tap(addButton);
        }

        public int GetItemCount()
        {
            return app.Query(x => x.Marked("ItemsCollectionView").Child()).Length;
        }
    }
}
