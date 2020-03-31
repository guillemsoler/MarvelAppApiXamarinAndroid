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

namespace AppXamAndroid.Dtos.Marvel
{
    class StoriesDto
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public List<Item3Dto> items { get; set; }
        public int returned { get; set; }
    }
}