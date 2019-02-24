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
using SQLite;
using System.IO;
using JuanLife.Model;

namespace JuanLife
{
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : Activity
    {
        string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.hackton");
        EditText txtSeach;
        Button btnSearch;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);

            txtSeach = FindViewById<EditText>(Resource.Id.txtsearch);
            btnSearch = FindViewById<Button>(Resource.Id.btnsearch);
            btnSearch.Click += Search_Click;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            

            try
            {
                var db = new SQLiteConnection(dpPath);
                var test = db.Table<tblDisease>();
                var data = test.FirstOrDefault(x => x.disease == txtSeach.Text);

               // btnSearch.Text = data.diseaseid.ToString();

                Intent i = new Intent(this, typeof(ChoiceActivity));
                i.PutExtra("DiseaseID", data.diseaseid.ToString());
                StartActivity(i);
            }
            catch (Exception i)
            {
                Toast.MakeText(this, i.ToString(), ToastLength.Short).Show();
            }
        }



    }
}