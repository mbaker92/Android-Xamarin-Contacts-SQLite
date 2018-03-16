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
using SQLite;

namespace ContactSQL
{
    [Activity(Label = "ViewCon")]
    public class ViewCon : Activity
    {
        private Classes.User TempUser;
        private TextView Email;
        private TextView Phone;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewContact);

            TempUser = Classes.InitialController.Load();
            this.Title = TempUser.name;
            // Create your application here

            Phone = FindViewById<TextView>(Resource.Id.PhoneView);
            Email = FindViewById<TextView>(Resource.Id.EmailView);

            GetInfo();

        }

        protected override void OnDestroy()
        {
            Classes.InitialController.Save(TempUser);
            base.OnDestroy();
        }

        private void GetInfo()
        {
            var db = new SQLiteConnection(TempUser.GetDBPath());
            var Info = db.Query<Classes.Contact>("SELECT * FROM Contact Where Name='" + TempUser.name+"'");
            foreach(var s in Info)
            {
                Phone.Text = s.PhoneNum;
                Email.Text = s.Email;
            }

            db.Close();
        }
    }
}