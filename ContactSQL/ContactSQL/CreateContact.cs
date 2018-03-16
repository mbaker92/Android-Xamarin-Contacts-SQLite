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
    [Activity(Label = "CreateContact")]
    public class CreateContact : Activity
    {
        private Classes.User TempUser;
        private Button AddButton;
        private EditText Name;
        private EditText Number;
        private EditText Email;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateContact);

            // Change Title of Screen
            this.Title = "Create Contact";

            // Set the Button and Fields
            AddButton = FindViewById<Button>(Resource.Id.ContactComfirmButton);
            Name = FindViewById<EditText>(Resource.Id.NameField);
            Number = FindViewById<EditText>(Resource.Id.NumberField);
            Email = FindViewById<EditText>(Resource.Id.EmailField);

            // Load User data
            TempUser = Classes.InitialController.Load();

            // Create your application here

            // On Addbutton click call AddContact
            AddButton.Click += delegate
            {
                AddContact();
            };
        }

        protected override void OnDestroy()
        {
            Classes.InitialController.Save(TempUser);
            base.OnDestroy();
        }
 

        private void AddContact()
        {
            // Create temp contact variable to help add info to the database.
            Classes.Contact tempContact = new Classes.Contact();

            // Open the Database
            var db = new SQLite.SQLiteConnection(TempUser.GetDBPath());
            
            
            // If Name and Number or Name and Email then set fields in tempContact and add to database
            if (((Name.Text != "") && (Number.Text != "")) || ((Name.Text != "") && (Email.Text != "")))
            {
                // If name is not empty, then set name variable of temp
                if (Name.Text != "")
                {
                    tempContact.SetName(Name.Text);
                }

                // If number is not empty, then set phone number variable of temp
                if (Number.Text != "")
                {
                    tempContact.SetPhone(Number.Text);
                }

                // If email is not empty, then set email variable of temp
                if (Email.Text != "")
                {
                    tempContact.SetEmail(Email.Text);
                }

                // Reset Fields to Blank
                Name.Text = "";
                Number.Text = "";
                Email.Text = "";

                // Insert into Database
                db.Insert(tempContact);
            }

            // Close Database
            db.Close();

            MainActivity.UpdateListview();
        }
        
    }
}