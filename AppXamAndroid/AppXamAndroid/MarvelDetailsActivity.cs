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
using Newtonsoft.Json;

namespace AppXamAndroid
{
    [Activity(Label = "MarvelDetailsActivity")]
    public class MarvelDetailsActivity : Activity
    {
        private ImageView pjImage;
        private TextView pjName;
        private TextView pjDescription;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MarvelDetailsLayout);
            // Create your application here
            BindUi();
            string url = Intent.GetStringExtra("Url");
            var imageBitmap = Utils.GetImageBitmapFromUrl(url);
            pjImage.SetImageBitmap(imageBitmap);
            pjName.Text = Intent.GetStringExtra("PjName");
            pjDescription.Text = Intent.GetStringExtra("Description");
        }

        private void BindUi()
        {
            pjImage = FindViewById<ImageView>(Resource.Id.imageViewPj);
            pjName = FindViewById<TextView>(Resource.Id.textViewName);
            pjDescription = FindViewById<TextView>(Resource.Id.textViewDescription);
        }
    }
}