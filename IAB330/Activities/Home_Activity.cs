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
    [Activity(Label = "Home")]
    public class Home_Activity : Activity
    {

        TextView username;
        ImageView profilePic;

        Intent makeRequest_Intent;
        Intent incoming_Intent;

        Button makeRequest;
        Button incoming;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.L_03_00_Home);

            // Create your application here
            username = FindViewById<TextView>(Resource.Id.USERNAME_Text);
            profilePic = FindViewById<ImageView>(Resource.Id.ID_Image);

            makeRequest = FindViewById<Button>(Resource.Id.REQUEST_button);
            incoming = FindViewById<Button>(Resource.Id.INCOMING_button);

            //-Make Request
            makeRequest.Click += delegate {
                AppData.prevScreen_cancel = "Home";
                makeRequest_Intent = new Intent(this, typeof(MakeRequest_Activity));
                this.StartActivity(makeRequest_Intent);
            };
            //-Check Incoming Requests
            incoming.Click += delegate {
                incoming_Intent = new Intent(this, typeof(RequestsHome_Activity));
                this.StartActivity(incoming_Intent);
            };

        }

    }
}