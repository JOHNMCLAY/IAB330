using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace IAB330
{
    [Activity(Label = "Mercury")]
    public class MainActivity : Activity
    {
        //-VARS
        
        TextView mod_Text;
        int counter = 0; 

        protected override void OnCreate(Bundle bundle)
        {
            //-Remove Title Bar
            //RequestWindowFeature(WindowFeatures.NoTitle);

            //-Call Superclass
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);


            //-Get Layout Elements
            ImageButton button = FindViewById<ImageButton>(Resource.Id.TapToStart);
            mod_Text = FindViewById<TextView>(Resource.Id.ModText);

            //-Controls
            button.Click += delegate {
                //counter++;
                Intent intent = new Intent(this, typeof(MakeRequest_Activity));
                this.StartActivity(intent);
            };



        }//-END| OnCreate----------------------------

        /*
        protected override void OnStart()
        {

            base.OnStart();
            mod_Text.Text = "On Start!";

        }

        protected override void OnResume()
        {

            base.OnResume();

            counter++;
            mod_Text.Text = "On Resume! " + counter;

        }*/

    }
}

