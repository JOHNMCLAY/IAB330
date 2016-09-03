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
    [Activity(Label = "MakeRequest_Activity")]
    public class MakeRequest_Activity : Activity
    {
        //-VARS
        ListView makeRequest_LV;

        Button send;
        Button cancel;

        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //-SETUP
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_03_01_MakeRequest);

            //-Setup Database
            db = new Database();
            db.PopulateEmployeeList();

            //-Get Layout Elements
            makeRequest_LV = FindViewById<ListView>(Resource.Id.LIST_listView);
            ArrayAdapter<string> request_AA = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, db.employees);
            makeRequest_LV.Adapter = request_AA;

            makeRequest_LV.ItemClick += MakeRequest_LV_ItemClick;


            //-Send Request
            send = FindViewById<Button>(Resource.Id.SENDREQUEST_button);
            send.Click += delegate {
                SendAlert();
            };

            //-Cancel (Functionally same as the back-button atm...might drop it)
            cancel = FindViewById<Button>(Resource.Id.CANCEL_button);
            cancel.Click += delegate
                {
                if(AppData.prevScreen_cancel=="Home")
                    {
                        Intent intent = new Intent(this, typeof(Home_Activity));
                        this.StartActivity(intent);
                    }
                else
                    {
                        Intent intent = new Intent(this, typeof(RequestsHome_Activity));
                        this.StartActivity(intent);
                    }
                };

            }

        private void MakeRequest_LV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void SendAlert()
        {
            AlertDialog.Builder aBuilder = new AlertDialog.Builder(this);
            AlertDialog alert = aBuilder.Create();
            alert.SetTitle("Request Sent!");
            //alert.SetIcon(Resource.Drawable.Icon);
            //alert.SetMessage("Hello John");

            alert.SetButton("OK", (s, ev) =>
            {
                //-Leave Text alert behind
                //Toast.MakeText(this, "YESSSS", ToastLength.Long).Show();
            });

            alert.Show();
        }
    }
}