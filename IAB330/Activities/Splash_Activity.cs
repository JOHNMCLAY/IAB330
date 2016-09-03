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
using System.Timers;

/*
 * Code (hacked together by) John McLay - n5767148
 */

namespace IAB330
{
    [Activity(Label = "Splash Activity", MainLauncher = true)]
    public class Splash_Activity : Activity
    {
        Timer timer;
        int timerCounter = 0;

        ImageView splash;
        float splashOpacity;

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.L_01_Splash);
            // Create your application here
            splash = FindViewById<ImageView>(Resource.Id.BG_image);
            splash.Alpha = 0;

            this.OnPause();

        }

        protected override void OnResume()
        {
            base.OnResume();
            //-Setup Splash Timer
            TimerSetup(1000);

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                timerCounter++;
                if (timerCounter == 0) { } //-Prevent else/if defaulting to 'else'
                else if (timerCounter == 1)//-Pre Fade
                {
                    timer.Stop();
                    TimerSetup(100);
                }
                else if (timerCounter<25)//-Fade In
                {
                    timer.Stop();
                    TimerSetup(50);
                    splashOpacity += 0.05f;
                    splash.Alpha = splashOpacity;
                }
                else if (timerCounter == 25)//-Pre Activity (Screen) Change
                {
                    timer.Stop();
                    TimerSetup(500);
                }
                else //-Transition to Log-In
                {
                    timer.Stop();
                    Intent intent = new Intent(this, typeof(LogIn_Activity));
                    this.StartActivity(intent);
                }

            });
        }

        private void TimerSetup (int length)
        {
            timer = new Timer();
            timer.Interval = length;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

    }
}