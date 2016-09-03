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
    [Activity(Label = "AnswerRequest_Activity")]
    public class AnswerRequest_Activity : Activity
    {
        Button send;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_04_02_AnswerRequest);

            //-SEND Button
            send = FindViewById<Button>(Resource.Id.SEND_button);
            send.Click += delegate
            {
                SendAlert();
            };


            }

        private void SendAlert()
        {
            AlertDialog.Builder aBuilder = new AlertDialog.Builder(this);
            AlertDialog alert = aBuilder.Create();
            alert.SetTitle("Info. Sent!");

            alert.SetButton("OK", (s, ev) =>
            {
                Intent intent = new Intent(this, typeof(RequestsHome_Activity));
                this.StartActivity(intent);
            });

            alert.Show();
        }
    }
}