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
        
        // Default Constructor
        public Contact()
        {
            
        }

        // Constructor for just name
        public Contact(string name)
        {
            Name = name;
        }

        // Constructor with name and contactInfo
        public Contact(string name, string ContactInfo, int Type)
        {
            Name = name;
            if (Type == 0)
            {
                PhoneNum = ContactInfo;
            }else if (Type == 1)
            {
                Email = ContactInfo;
            }
        }

        // Constructor with name, phone, and email
        public Contact(string name, string phone, string email)
        {
            Name = name;
            PhoneNum = phone;
            Email = email;
        }

        // Get DBName
        public string GetDBName(string Database)
        {
            return Database;
        }

        // SetName
        public void SetName(string name)
        {
            Name = name;
        }

        // SetPhone
        public void SetPhone(string Phone)
        {
            PhoneNum = Phone;
        }

        // SetEmail
        public void SetEmail(string email)
        {
            Email = email;
        }

    }
}