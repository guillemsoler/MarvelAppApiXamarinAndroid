using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppXamAndroid.Models;
using static Android.Support.V7.Widget.RecyclerView;

namespace AppXamAndroid
{
    public class MyCustomListAdapter : BaseAdapter<MarvelModel>
    {
        List<MarvelModel> MarvelModels;

        public MyCustomListAdapter(List<MarvelModel> users)
        {
            this.MarvelModels = users;
        }

        public override MarvelModel this[int position]
        {
            get
            {
                return MarvelModels[position];
            }
        }

        public override int Count
        {
            get
            {
                return MarvelModels.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MarvelItemLayout, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.imageViewPjImage);
                var name = view.FindViewById<TextView>(Resource.Id.textViewPjName);
                var button = view.FindViewById<ImageButton>(Resource.Id.right_side);

                view.Tag = new ViewHolder() { Photo = photo, Name = name, ButtonG = button };
            }

            var holder = (ViewHolder)view.Tag;

            var imageBitmap = Utils.GetImageBitmapFromUrl(MarvelModels[position].Url);

            holder.Photo.SetImageBitmap(imageBitmap);
            holder.Name.Text = MarvelModels[position].PjName;

            holder.ButtonG.Click += (object sender, EventArgs e) =>
            {
                MarvelModel item = MarvelModels[position];
                GoToDetails(item, view);
                //activity.RunOnUiThread(() => this.NotifyDataSetChanged());
            };

            return view;

        }
        public class ViewHolder : Java.Lang.Object
        {
            public ImageView Photo { get; set; }
            public TextView Name { get; set; }
            public ImageButton ButtonG { get; set; }
        }
        public void GoToDetails(MarvelModel marvelModel, View view)
        {
            Intent intent = new Intent(view.Context, typeof(MarvelDetailsActivity));
            //intent.AddFlags(ActivityFlags.NewTask);
            Bundle bundle = new Bundle();
            bundle.PutString("Url", marvelModel.Url);
            bundle.PutString("PjName", marvelModel.PjName);
            bundle.PutString("Description", marvelModel.Description);
            intent.PutExtras(bundle);
            view.Context.StartActivity(intent);
        }

    }
}