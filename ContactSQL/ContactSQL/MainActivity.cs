/* Author: Matthew Baker
 * Email: Hackmattr@gmail.com
 * Program: ContactSQL
 * File: MainActivity.cs
 * Date Created: 3/5/2018
 * Date Modified: 3/5/2018
 * Description: The MainActivity is the home screen of the Contacts. 
 */
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Preferences;
using Android.Content;
using System;
using System.Collections.Generic;
using SQLite;

namespace ContactSQL
{

    [Activity(Label = "ContactSQL", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Classes.User TempUser;
        private List<string> ContactNames = new List<string>();
        private ListView ContactList;
        private Button AddBut;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            // Change Title of Screen
            this.Title = "Contacts";

            // Find Add Contact Button and the List view for Names
            AddBut = FindViewById<Button>(Resource.Id.AddContactButton);
            ContactList = FindViewById<ListView>(Resource.Id.ContactNameView);
            CheckFirstRun();


            AddBut.Click += delegate
            {
                StartIntent();
            };
            ContactList.Adapter = TempUser.GetContactNames(ref ContactNames);
            
        }

 
        protected override void OnDestroy()
        {
            Classes.InitialController.Save(TempUser);
            base.OnDestroy();
        }



        private void StartIntent()
        {
            var intent = new Intent(this, typeof(CreateContact));
            Classes.InitialController.Save(TempUser);
            StartActivity(intent);
        }


        private void CheckFirstRun()
        {
            const string PREFS_NAME = "PrefsFile";
            const string PrefVersionCodeKey = "version_code";
            int DoesntExist = -1;

            // Get Current Version of Application
            int currentVersionCode = Application.Context.PackageManager.GetPackageInfo(Application.Context.ApplicationContext.PackageName, 0).VersionCode;


            ISharedPreferences prefs = GetSharedPreferences(PREFS_NAME, FileCreationMode.Private);
            int savedVersionCode = prefs.GetInt(PrefVersionCodeKey, DoesntExist);

            // If current version then its a normal run.
            if (currentVersionCode == savedVersionCode)
            {
                // Normal Run Load User Profile
                TempUser = Classes.InitialController.Load();
                return;
                
            }
            else if (savedVersionCode == DoesntExist)
            {                
                // New Install or User Cleared Shared Preferences
                // Initialize MainController for Contacts database and initialize user.
                Classes.InitialController main = new Classes.InitialController();
                TempUser = new Classes.User();


            }
            else if (currentVersionCode > savedVersionCode)
            {

                // Upgrade of Application Load User Profile
                TempUser = Classes.InitialController.Load();
            }

            // Update shared preferences with current version code
            prefs.Edit().PutInt(PrefVersionCodeKey, currentVersionCode).Apply();

        }
    }

}

