using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITest.Pages
{
    public class NewItemPage : BasePage
    {
        readonly Query textEntry;
        readonly Query descriptionEditor;
        readonly Query cancelButton;
        readonly Query saveButton;

        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("TextEntry"),
            //iOS = x => x.Marked("Tasky")
        };

        public NewItemPage()
        {
            if (OnAndroid)
            {
                textEntry = x => x.Marked("TextEntry");
                descriptionEditor = x => x.Marked("DescriptionEditor");
                cancelButton = x => x.Marked("CancelButton");
                saveButton = x => x.Marked("SaveButton");
            }

            //if (OniOS)
            //{
            //    addTaskButton = x => x.Marked("Add");
            //    firstTask = x => x.Class("UITableViewWrapperView").Child(0);
            //    taskListItem = name => x => x.Class("UITableViewCell").Text(name);
            //    deleteButton = x => x.Marked("Delete");
            //}
        }

        public void AddItem(string entryText,string descriptionText)
        {
            app.EnterText(textEntry, entryText);
            app.DismissKeyboard();
            app.EnterText(descriptionEditor, descriptionText);
            app.DismissKeyboard();
            app.Tap(saveButton);
        }
    }
}