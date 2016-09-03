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
    [Activity(Label = "ReceivedRequest_Activity")]
    public class ReceivedRequest_Activity : Activity
    {
        //VAR
        Button ok;
        Intent back_Intent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_04_01_ReceivedRequest);

            ok = FindViewById<Button>(Resource.Id.OK_button);
            ok.Click += delegate {
                back_Intent = new Intent(this, typeof(RequestsHome_Activity));
                this.StartActivity(back_Intent);
            };

        }
    }
}