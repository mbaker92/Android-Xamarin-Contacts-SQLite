/* Author: Matthew Baker
 * Email: Hackmattr@gmail.com
 * Program: ContactSQL
 * File: .cs
 * Date Created: 3/5/2018
 * Date Modified: 3/5/2018
 * Description: The InitialController class will create the new database that will store the contacts
 *              once the constructor is called. The InitialController will also save and load a user
 *              class profile.
 */

using System;
using System.IO;
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

namespace ContactSQL.Classes
{
    [Serializable]
    public class User
    {
        private string DBName = "Contacts.db3";
        private string DBPath;

        public User()
        {
            DBPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DBName);
        }


        public ArrayAdapter<string> GetContactNames(ref List<string> temp)
        {
            var db = new SQLiteConnection(DBPath);
            var NameList = db.Query<Classes.Contact>("Select Name From Contact");
            foreach(var s in NameList)
            {
                temp.Add(s.Name);
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(Android.App.Application.Context, Android.Resource.Layout.SimpleListItem1, temp);
            db.Close();
            return adapter;
        }

    }
}