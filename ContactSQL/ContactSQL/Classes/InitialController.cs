/* Author: Matthew Baker
 * Email: Hackmattr@gmail.com
 * Program: ContactSQL
 * File: InitialController.cs
 * Date Created: 3/5/2018
 * Date Modified: 3/5/2018
 * Description: The InitialController class will create the new database that will store the contacts
 *              once the constructor is called. The InitialController will also save and load a user
 *              class profile.
 */

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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SQLite;

namespace ContactSQL.Classes
{
    class InitialController
    {
        private string DBPath;
        private string DBName = "Contacts.db3";
        const int VERSION = 1;


        public InitialController()
        {
            DBPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DBName);
            if (System.IO.File.Exists(DBPath))
            {
                // IF DB file already exists (Shouldn't)
            }
            var db = new SQLiteConnection(DBPath);
            db.CreateTable<Contact>();
            db.Close();
        }

        public static void Save(User Mainsave)
        {
            Stream stream = null;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SavedData.hack"), FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, VERSION);
                formatter.Serialize(stream, Mainsave);
            }
            catch
            {
                // Do nothing
            }
            finally
            {
                if (null != stream)
                    stream.Close();
            }
        } 

        public static User Load()
        {
            Stream stream = null;
            User Profile = null;

            try
            {
                IFormatter formatter = new BinaryFormatter();
                stream = new FileStream(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SavedData.hack"), FileMode.Open, FileAccess.Read, FileShare.None);
                int version = (int)formatter.Deserialize(stream);
                Profile = (User)formatter.Deserialize(stream);
            }
            catch
            {
                // Do nothing, ignore any errors
            }
            finally
            {
                if (null != stream)
                    stream.Close();
                
            }
            return Profile;
        }
    }
}