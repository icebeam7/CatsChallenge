using Android.App;
using Android.Widget;
using Android.OS;
using CatsChallenge.SAL;
using CatsChallenge.CustomAdapters;
using Android.Content;

namespace CatsChallengeClient
{
    [Activity(Label = "CatsChallengeClient", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var service = new ServiceClient();
            var catsList = await service.GetCats();

            var listviewCats = FindViewById<ListView>
                (Resource.Id.listviewCats);
            listviewCats.Adapter = new CustomAdapter
                (this, catsList, Resource.Layout.ListItem, 
                Resource.Id.imageViewCat, 
                Resource.Id.textViewName, 
                Resource.Id.textViewPrice);

            listviewCats.ItemClick += (s, e) =>
            {
                var cat = catsList[e.Position];

                var intent = new Intent(this, typeof(CatDetailActivity));
                intent.PutExtra("id", cat.ID);
                intent.PutExtra("name", cat.Name);
                intent.PutExtra("description", cat.Description);
                intent.PutExtra("price", cat.Price);
                intent.PutExtra("image", cat.Image);
                intent.PutExtra("website", cat.WebSite);
                StartActivity(intent);
            };
        }
    }
}

