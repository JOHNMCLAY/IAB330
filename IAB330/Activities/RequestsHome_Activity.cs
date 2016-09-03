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
    [Activity(Label = "RequestsHome")]
    public class RequestsHome_Activity : Activity
    {

        //-VARS
        ListView sent_LV;
        ListView incoming_LV;

        Button newRequest;
        Intent newReq;

        Intent recReq_In;
        Intent outReq_In;

        Database db;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //-Setup Page
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_04_00_RequestsHome);

            //-Setup Database
            db = new Database();
            db.PopulateTEMPLists();

            //-Temporary 'sent' list
            sent_LV = FindViewById<ListView>(Resource.Id.SENT_REQ_listview);
            ArrayAdapter<string> sent_AA = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, db.TEMP_sent);
            sent_LV.Adapter = sent_AA;

            sent_LV.ItemClick += Sent_LV_ItemClick;

            //-Temporary 'incoming' list
            incoming_LV = FindViewById<ListView>(Resource.Id.INCOMING_REQ_listview);
            ArrayAdapter<string> incoming_AA = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemMultipleChoice, db.TEMP_incoming);
            incoming_LV.Adapter = incoming_AA;

            incoming_LV.ItemClick += Incoming_LV_ItemClick;

            //-NEW Request Button
            newRequest = FindViewById<Button>(Resource.Id.NEW_button);
            newRequest.Click += delegate {
                AppData.prevScreen_cancel = "Req_Home";
                newReq = new Intent(this, typeof(MakeRequest_Activity));
                this.StartActivity(newReq);
            };
        }

        private void Incoming_LV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //-***Make particular to selected List Item
            outReq_In = new Intent(this, typeof(AnswerRequest_Activity));
            this.StartActivity(outReq_In);
        }

        private void Sent_LV_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //-***Make particular to selected List Item
            recReq_In = new Intent(this, typeof(ReceivedRequest_Activity));
            this.StartActivity(recReq_In);
        }
    }
}