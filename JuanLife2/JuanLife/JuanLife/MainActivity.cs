using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace JuanLife
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        Button btnSearch;
        Button btnAsk;
        Button btnAdmin;
        Button btnSpeech;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);


            
            btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnAdmin = FindViewById<Button>(Resource.Id.btnadmin);
            btnAsk = FindViewById<Button>(Resource.Id.btnAsk);
            btnSpeech = FindViewById<Button>(Resource.Id.btnSpeech);


            btnSearch.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(SearchActivity));
                StartActivity(nextActivity);
            };
            btnAdmin.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(AdminActivity));
                StartActivity(nextActivity);
            };
            btnAsk.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(AskActivty));
                StartActivity(nextActivity);
            };
            btnSpeech.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(TextToSpeechActivity));
                StartActivity(nextActivity);
            };
        }


       

    }
}

