using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppXamAndroid.Models;

namespace AppXamAndroid.Services.Contracts
{
    public interface IGetMarvelPjService
    {
        Task<MarvelModel> GetPJ(string PjName);
    }
}