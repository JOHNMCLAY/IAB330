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

/*
 * Code (hacked together by) John McLay - n5767148
 */

namespace IAB330
{
    public class Database
    {
        //-VARS
        public List<string> employees = new List<string>();
        public List<string> TEMP_incoming = new List<string>();
        public List<string> TEMP_sent = new List<string>();



        //-METHODS------------------------------------------
        public void PopulateEmployeeList()
        {

            employees.Add("John Smith");
            employees.Add("Jack Bellings");
            employees.Add("Harry Kelogg");
            employees.Add("Joanne Harris");
            employees.Add("Peter Childs");
            employees.Add("Barry Graham");
            employees.Add("Jill Gonzalez");
            employees.Add("Sophie Bell");
            employees.Add("Hanlon Bellis");
            employees.Add("Evie Adler");
            employees.Add("Holly Johnson");
            employees.Add("Albert Schrier");
            employees.Add("Emily Spencer");
            employees.Add("Julie Wayne");
            employees.Add("Heather Albertson");

        }

        public void PopulateTEMPLists()
        {
            TEMP_incoming.Add("Hanlon Bellis");
            TEMP_incoming.Add("Evie Adler");
            TEMP_incoming.Add("Holly Johnson");
            TEMP_incoming.Add("Albert Schrier");
            TEMP_incoming.Add("Emily Spencer");
            TEMP_incoming.Add("Julie Wayne");

            TEMP_sent.Add("Jack Bellings");
            TEMP_sent.Add("Harry Kelogg");
            TEMP_sent.Add("Joanne Harris");
            TEMP_sent.Add("Peter Childs");
            TEMP_sent.Add("Barry Graham");
            TEMP_sent.Add("Jill Gonzalez");
        }

    }
}