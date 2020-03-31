using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppXamAndroid.Dtos.Marvel;
using AppXamAndroid.Models;
using AppXamAndroid.Services.Contracts;
using Newtonsoft.Json;

namespace AppXamAndroid.Services.Implementations
{
    public class GetMarvelPjService : IGetMarvelPjService
    {
        public async Task<MarvelModel> GetPJ(string PjName)
        {
            MarvelModel marvelModel = new MarvelModel();
                HttpClient http = new HttpClient();
                try
                {
                    var data = await http.GetAsync("https://gateway.marvel.com/v1/public/characters?name=" + PjName + "&apikey=8ccf45ae4e5cf23b66124e14b829ce7e&ts=1&hash=c7fc4feecebe24d6ce048687a7d06534");

                    if (data != null)
                    {
                        string pj = await data.Content.ReadAsStringAsync();
                        var something = JsonConvert.DeserializeObject<RootObjectMarvelDto>(pj);
                        if (something != null && something.data.results.Any())
                        {
                            marvelModel.Id = something.data.results.First().id;
                            marvelModel.PjName = something.data.results.First().name;
                            marvelModel.Description = something.data.results.First().description;
                            marvelModel.Url = something.data.results.First().thumbnail.path + "." + something.data.results.First().thumbnail.extension;

                            }
                        }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


            return marvelModel;
        }

    }
}
