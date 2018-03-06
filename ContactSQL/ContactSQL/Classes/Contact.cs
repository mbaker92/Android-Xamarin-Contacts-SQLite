/* Author: Matthew Baker
 * Email: Hackmattr@gmail.com
 * Program: ContactSQL
 * File: Contact.cs
 * Date Created: 3/5/2018
 * Date Modified: 3/5/2018
 * Description: The contact class is used to structure the table in the SQLite database.
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
using SQLite;

namespace ContactSQL.Classes
{


    class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        
        public Contact()
        {
            Name = "Unknown";
        }
        public Contact(string name)
        {
            Name = name;
        }
        public Contact(string name, string phone)
        {
            Name = name;
            PhoneNum = phone;
        }
        public Contact(string name, string phone, string email)
        {
            Name = name;
            PhoneNum = phone;
            Email = email;
        }

        public string GetName(string Database)
        {
            return Database;
        }

    }
}