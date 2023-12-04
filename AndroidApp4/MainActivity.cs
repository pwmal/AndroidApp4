using Android.App.AppSearch;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.Opengl;
using Java.Net;
using Newtonsoft.Json.Linq;
using System.Net;
using static Android.Telephony.CarrierConfigManager;

namespace AndroidApp4
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button btn1 = FindViewById<Button>(Resource.Id.Act3bt1);

            EditText et1 = FindViewById<EditText>(Resource.Id.Act3et1);

            btn1.Click += delegate
            {
                if (et1.Text != "" && et1.Text != " ")
                {
                    Intent intent = new Intent(this, typeof(Act2));

                    intent.PutExtra("date", et1.Text);

                    StartActivity(intent);
                }
            };
        }
    }
}