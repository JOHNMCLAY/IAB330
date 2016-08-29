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
    [Activity(Label = "Home")]
    public class Home_Activity : Activity
    {

        TextView username;
        ImageView profilePic;

        Button makeRequest;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Home);

            // Create your application here
            username = FindViewById<TextView>(Resource.Id.USERNAME_Text);
            profilePic = FindViewById<ImageView>(Resource.Id.ID_Image);

            makeRequest = FindViewById<Button>(Resource.Id.REQUEST_button);

            //-
            makeRequest.Click += delegate {
                //counter++;
                Intent intent = new Intent(this, typeof(MakeRequest_Activity));
                this.StartActivity(intent);
            };

        }

    }
}