using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

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
    [Activity(Label = "Log-In")]
    public class LogIn_Activity : Activity
    {
        //-Vars
        ImageView pin_L;
        ImageView pin_C;
        ImageView pin_R;
        ImageView key;

        ImageButton key_1;
        ImageButton key_2;
        ImageButton key_3;
        ImageButton key_4;
        ImageButton key_5;
        ImageButton key_6;
        ImageButton key_7;
        ImageButton key_8;
        ImageButton key_9;
        ImageButton key_bSpace;

        int[] inputPIN;
        int inputIndex;

        Timer resetTimer;
        int timerInterval = 500;
        bool resetBlock;
        int timerCounter;

        string PIN = "000"; //-Temp. (Source from User struct)

        TextView TEST;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L_02_LogIn);

            // Create your application here
            pin_L = FindViewById<ImageView>(Resource.Id.PinInput_Left);
            pin_C = FindViewById<ImageView>(Resource.Id.PinInput_Center);
            pin_R = FindViewById<ImageView>(Resource.Id.PinInput_Right);
            key = FindViewById<ImageView>(Resource.Id.Key_Image);

            SetupKeys();

            TEST = FindViewById<TextView>(Resource.Id.USER_Text);
            

        }

        private void SetupKeys ()
        {
            inputIndex = 0;
            inputPIN = new int[3];
            inputPIN[0] = 0;
            inputPIN[1] = 0;
            inputPIN[2] = 0;

            key_1 = FindViewById<ImageButton>(Resource.Id.PIN_01_Image);
            key_2 = FindViewById<ImageButton>(Resource.Id.PIN_02_Image);
            key_3 = FindViewById<ImageButton>(Resource.Id.PIN_03_Image);
            key_4 = FindViewById<ImageButton>(Resource.Id.PIN_04_Image);
            key_5 = FindViewById<ImageButton>(Resource.Id.PIN_05_Image);
            key_6 = FindViewById<ImageButton>(Resource.Id.PIN_06_Image);
            key_7 = FindViewById<ImageButton>(Resource.Id.PIN_07_Image);
            key_8 = FindViewById<ImageButton>(Resource.Id.PIN_08_Image);
            key_9 = FindViewById<ImageButton>(Resource.Id.PIN_09_Image);
            key_bSpace = FindViewById<ImageButton>(Resource.Id.PIN_Backspace);

            key_1.Click += delegate { GetInput(1); };
            key_2.Click += delegate { GetInput(2); };
            key_3.Click += delegate { GetInput(3); };
            key_4.Click += delegate { GetInput(4); };
            key_5.Click += delegate { GetInput(5); };
            key_6.Click += delegate { GetInput(6); };
            key_7.Click += delegate { GetInput(7); };
            key_8.Click += delegate { GetInput(8); };
            key_9.Click += delegate { GetInput(9); };
            key_bSpace.Click += delegate { GetInput(0); };

        }

        private void GetInput (int key)
        {
            if (resetBlock == false)
            {
                //-Input Key
                if (key != 0)
                {
                    inputPIN[inputIndex] = key;
                    ChangePinImage(true, inputIndex);
                    inputIndex++;
                }
                //-Backspace
                if (key == 0)
                {
                    if (inputIndex != 0) { inputIndex--; ChangePinImage(false, inputIndex); }
                }

                //-Final Input - Check if PIN is correct
                if (inputIndex == 3)
                {
                    inputIndex = 0;
                    AuthenticatePIN();
                }

            }//-END| Reset Block

        }

        private void ChangePinImage(bool onOff, int index)
        {
            //-Change PIN Input Images
            if (onOff == true)
            {
                switch (index)
                {
                    case 0:
                        pin_L.SetImageResource(Resource.Drawable.IM_02_Pin_Full);
                        break;
                    case 1:
                        pin_C.SetImageResource(Resource.Drawable.IM_02_Pin_Full);
                        break;
                    case 2:
                        pin_R.SetImageResource(Resource.Drawable.IM_02_Pin_Full);
                        break;
                }
            }
            if (onOff == false)
            {
                switch (index)
                {
                    case 0:
                        pin_L.SetImageResource(Resource.Drawable.IM_02_Pin_Empty);
                        break;
                    case 1:
                        pin_C.SetImageResource(Resource.Drawable.IM_02_Pin_Empty);
                        break;
                    case 2:
                        pin_R.SetImageResource(Resource.Drawable.IM_02_Pin_Empty);
                        break;
                    case 10:
                        pin_L.SetImageResource(Resource.Drawable.IM_02_Pin_Empty);
                        pin_C.SetImageResource(Resource.Drawable.IM_02_Pin_Empty);
                        pin_R.SetImageResource(Resource.Drawable.IM_02_Pin_Empty);
                        inputPIN[0] = 0; inputPIN[1] = 0; inputPIN[2] = 0;
                        break;
                }
            }
        }

        private void AuthenticatePIN ()
        {
            bool valid = false;
            string thisPIN;
            //-Turn Input PIN to String
            thisPIN = inputPIN[0].ToString() + inputPIN[1].ToString() + inputPIN[2].ToString();
            //-Compare to PIN
            if (thisPIN != PIN)
            {
                valid = true;
                //TEST.Text = "WINNARRR";
                //-Go to Home Screen
                Intent intent = new Intent(this, typeof(Home_Activity));
                this.StartActivity(intent);
            }
            //-Reset PIN input process
            if (valid == false)
            {
                key.SetImageResource(Resource.Drawable.IM_02_KeyRed);
                resetBlock = true;
                //-Timer
                resetTimer = new Timer();
                resetTimer.Interval = timerInterval;
                resetTimer.Elapsed += Timer_Elapsed;
                resetTimer.Start();
            }

        }
        
        //-Timer End
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                timerCounter++;

                if (timerCounter == 1)
                {
                    resetTimer.Stop();
                    resetBlock = false;
                    timerCounter = 0;
                    //
                    ChangePinImage(false, 10);
                    key.SetImageResource(Resource.Drawable.IM_02_Key);
                }

            });
        }



    }//END| Class
}