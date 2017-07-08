using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace CatsChallengeClient
{
    [Activity(Label = "CatDetailActivity")]
    public class CatDetailActivity : Activity
    {
        string id, name, description, website, image;
        int price;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CatDetail);

            id = Intent.Extras.GetString("id");
            name = Intent.Extras.GetString("name");
            description = Intent.Extras.GetString("description");
            website = Intent.Extras.GetString("website");
            image = Intent.Extras.GetString("image");
            price = Intent.Extras.GetInt("price");

            this.Title = name;

            var imageView = FindViewById<ImageView>(Resource.Id.imageViewCatDetail);
            Koush.UrlImageViewHelper.SetUrlDrawable(imageView, image);

            FindViewById<TextView>(Resource.Id.textViewCatName).Text = name;
            FindViewById<TextView>(Resource.Id.textViewCatDescription).Text = description;

            FindViewById<Button>(Resource.Id.buttonVisitWebsite).Click += (s, e) =>
            {
                var uri = Android.Net.Uri.Parse(website);
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
        }
    }
}