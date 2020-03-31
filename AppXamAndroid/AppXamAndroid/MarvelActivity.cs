using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections;
using AppXamAndroid.Models;
using AppXamAndroid.Services.Contracts;
using AppXamAndroid.Services.Implementations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Android.Content;
using Java.Lang;
using Exception = System.Exception;

namespace AppXamAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MarvelActivity : AppCompatActivity
    {
        private readonly GetMarvelPjService GetMarvelPjService = new GetMarvelPjService();
        ImageView imageViewMain;
        EditText editTextPjName;
        CheckBox checkBoxFromCache;
        Button buttonCallApi;
        ListView listViewPjList;
        string PjSelected;
        bool IsCheckBox1Checked;

        static List<MarvelModel> MarvelList = new List<MarvelModel>();
        private MyCustomListAdapter myCustomListAdapter = new MyCustomListAdapter(MarvelList);

        private MarvelModel _marvelData;

        public MarvelModel MarvelData
        {
            get { return _marvelData; }
            set
            {
                _marvelData = value;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MarvelLayout);
            BindUi();

            listViewPjList.TextFilterEnabled = true;
            listViewPjList.Adapter = myCustomListAdapter;

            listViewPjList.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
            };

            buttonCallApi.Click += (sender, e) =>
            {
                CallApi();
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void BindUi()
        {
            imageViewMain = FindViewById<ImageView>(Resource.Id.imageViewMain);
            editTextPjName = FindViewById<EditText>(Resource.Id.editTextPjName);
            checkBoxFromCache = FindViewById<CheckBox>(Resource.Id.checkBoxFromCache);
            buttonCallApi = FindViewById<Button>(Resource.Id.buttonCallApi);
            listViewPjList = FindViewById<ListView>(Resource.Id.listViewPjList);
        }

        private async void CallApi()
        {
            PjSelected = editTextPjName.Text;

            try
            {
                MarvelData = await GetMarvelPjService.GetPJ(PjSelected);
                if (MarvelData != null)
                {
                    MarvelList.Insert(0, MarvelData);
                    myCustomListAdapter.NotifyDataSetChanged();
                }
                else
                {
                    Toast.MakeText(this, "Error!", ToastLength.Short).Show();
                }
            }
            catch (Exception z)
            {

            }
        }
    }
}