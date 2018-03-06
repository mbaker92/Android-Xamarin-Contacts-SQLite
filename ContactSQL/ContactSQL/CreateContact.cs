using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ContactSQL
{
    [Activity(Label = "CreateContact")]
    public class CreateContact : Activity
    {
        private Classes.User TempUser;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateContact);


            TempUser = Classes.InitialController.Load();
            // Create your application here
        }
    }
}