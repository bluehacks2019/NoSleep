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

namespace JuanLife
{
    [Activity(Label = "AdminActivity")]
    public class AdminActivity : Activity
    {
        Button btndisease;
        Button btndiet;
        Button btnexercise;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Admin);
            btndisease = FindViewById<Button>(Resource.Id.btnAddDisease);
            btndiet = FindViewById<Button>(Resource.Id.btnAddDiet);
            btnexercise = FindViewById<Button>(Resource.Id.btnAddExercise);

            btndisease.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(DiseaseActivity));
                StartActivity(nextActivity);
            };
            btndiet.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(DietActivity));
                StartActivity(nextActivity);
            };
            btnexercise.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(ExerciseActivitiy));
                StartActivity(nextActivity);
            };
        }
    }
}