﻿using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public abstract class BaseTestFixture
    {
        protected IApp app => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        protected bool OniOS => AppManager.Platform == Platform.iOS;

        protected BaseTestFixture(Platform platform)
        {
            AppManager.Platform = platform;
        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            AppManager.StartApp();
        }

        protected void EnterTask(string name, string notes = null)
        {
            //new TaskListPage()
            //    .GoToAddTask();

            //new TaskDetailsPage()
            //    .EnterTask(name, notes)
            //    .Save();

            //new TaskListPage()
            //    .VerifyTaskExists(name);
        }

        // You can edit this file to define functionality that is common across many or all tests.
        // For example, you could add a method here to log in or dismiss a welcome dialogue.
    }
}
