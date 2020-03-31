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
    class ResultDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime modified { get; set; }
        public ThumbnailDto thumbnail { get; set; }
        public string resourceURI { get; set; }
        public ComicsDto comics { get; set; }
        public SeriesDto series { get; set; }
        public StoriesDto stories { get; set; }
        public EventsDto events { get; set; }
        public List<UrlDto> urls { get; set; }
    }
}