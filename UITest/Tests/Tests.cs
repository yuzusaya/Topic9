using NUnit.Framework;
using System.Linq;
using UITest.Pages;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests : BaseTestFixture
    {
        IApp app;
        Platform platform;
        public Tests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void ReplTest()
        {
            app.Repl();
        }

        [Test]
        public void AddItemTest()
        {
            app.Tap(x => x.Text("Browse"));
            var itemsPage = new ItemsPage();
            var count = itemsPage.GetItemCount();
            itemsPage.GoToAddItemPage();
            new NewItemPage().AddItem("Title", "Description");
            var count2 = new ItemsPage().GetItemCount();
            Assert.IsTrue(count2 == count + 1);
            //app.Screenshot("Title");
        }
    }
}
