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

namespace IAB330
{
    public class Database
    {
        //-VARS
        public List<string> employees = new List<string>();


        

        //-METHODS------------------------------------------
        public void PopulateEmployeeList () {

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

        


    }
}