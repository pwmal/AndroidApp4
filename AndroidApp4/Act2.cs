using Android.Graphics;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp4
{
    [Activity(Label = "@string/Act2")]
    public class Act2 : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.act2);

            ImageView i2 = FindViewById<ImageView>(Resource.Id.imageView2);

            var key = "V404QsVPGzWr1gHiwR2klUluOLjnJCxjwjj9Nz9Y";
            var date = Intent.GetStringExtra("date");

            var request = new NASAAPI($"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date={date}&camera=FHAZ&api_key={key}");
            request.Run();

            var response = request.Response;

            var json = JObject.Parse(response);
            var photos = json["photos"];

            var photo = photos[0];

            var path = photo["img_src"].ToString();

            var imageBitmap = GetImageBitmapFromUrl(path);

            i2.SetImageBitmap(imageBitmap);

        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }
            return imageBitmap;
        }
    }
}
