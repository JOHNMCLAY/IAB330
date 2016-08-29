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
    [Activity(Label = "MakeRequest_Activity")]
    public class MakeRequest_Activity : Activity
    {
        //-VARS
        ListView makeRequest_LV;

        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //-SETUP
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MakeRequest);

            //-Setup Database
            db = new Database();
            db.PopulateEmployeeList();

            //-Get Layout Elements
            makeRequest_LV = FindViewById<ListView>(Resource.Id.LIST_listView);
            ArrayAdapter<string> request_AA = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, db.employees);

            makeRequest_LV.Adapter = request_AA;

        }

        private void LV_Format()
        {
            //var template = new DataTemplate(typeof(TextCell));
            //template.SetValue(TextCell.TextColorProperty, Color.Black);
            //makeRequest_LV = template;
        }
    }
}