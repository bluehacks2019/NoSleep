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
using System.IO;
using SQLite;
using JuanLife.Model;

namespace JuanLife
{
    [Activity(Label = "DietActivity")]
    public class DietActivity : Activity
    {

        string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.hackton");
        EditText txtDiseaseID;
        EditText txtFname;
        EditText txtFoodDescription;
        EditText txtBeni;
        Button btnAddDiet;
        Button btnget;
      


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Diet);


            txtDiseaseID = FindViewById<EditText>(Resource.Id.txtDisease);
            txtFname = FindViewById<EditText>(Resource.Id.txtDietFoodName);
            txtFoodDescription = FindViewById<EditText>(Resource.Id.txtDietDesc);
            txtBeni = FindViewById<EditText>(Resource.Id.txtBenifit);
            btnAddDiet = FindViewById<Button>(Resource.Id.btnAddDiet);
            btnget = FindViewById<Button>(Resource.Id.btnGetDiet);
            btnAddDiet.Click += BtnAdd_Click;
            btnget.Click += BtnGet_Click;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                var db = new SQLiteConnection(dpPath);
                db.CreateTable<tblDiet>();
                tblDiet tbl = new tblDiet();
                tbl.diseaseid = txtDiseaseID.Text;
                tbl.foodname = txtFname.Text;
                tbl.dietdescription = txtFoodDescription.Text;
                tbl.benifit = txtBeni.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();

            }
            catch (Exception i)
            {
                Toast.MakeText(this, i.ToString(), ToastLength.Short).Show();
            }
        }
        private void BtnGet_Click(object sender, EventArgs e)
        {
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            try
            {
                var db = new SQLiteConnection(dpPath);
                var test = db.Table<tblDiet>();

                foreach (var item in test)
                {
                    var aButton = new Button(this);
                    aButton.Text = item.foodname;
                    layout.AddView(aButton);
                    SetContentView(layout);
                }


            }
            catch (Exception i)
            {
                Toast.MakeText(this, i.ToString(), ToastLength.Short).Show();
            }
        }
    }
}