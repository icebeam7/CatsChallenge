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
using Android.Webkit;

namespace CatsChallengeClient
{
    [Activity(Label = "CatWebsiteActivity")]
    public class CatWebsiteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CatWebsite);

            var url = Intent.Extras.GetString("website");
            var webview = FindViewById<WebView>(Resource.Id.webViewCat);
            webview.LoadDataWithBaseURL(url, "", 
                "text/html", "utf-8", null);

        }
    }
}