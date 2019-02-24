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
using System.Drawing;

namespace JuanLife
{
    [Activity(Label = "DiseaseActivity")]
    public class DiseaseActivity : Activity
    {
        string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.hackton");
        EditText txtDisease;
        EditText txtDescription;
        EditText txtCauses;
        EditText txtCure;
        Button btnAdd;
        Button btnGet;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Disease);

            
            txtDisease = FindViewById<EditText>(Resource.Id.txtdisease);
            txtDescription = FindViewById<EditText>(Resource.Id.txtDescription);
            txtCauses = FindViewById<EditText>(Resource.Id.txtCause);
            txtCure = FindViewById<EditText>(Resource.Id.txtCure);
            btnAdd = FindViewById<Button>(Resource.Id.btnAddDisease);
            btnGet = FindViewById<Button>(Resource.Id.btnGet);
            btnAdd.Click += BtnAdd_Click;
            btnGet.Click += BtnGet_Click;

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                
                var db = new SQLiteConnection(dpPath);
                db.CreateTable <tblDisease>();
                tblDisease tbl = new tblDisease();
                tbl.disease = txtDisease.Text;
                tbl.description = txtDescription.Text;
                tbl.cause = txtCauses.Text;
                tbl.cure = txtCure.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();

            }
            catch(Exception i)
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
                var test = db.Table<tblDisease>();

                foreach(var item in test)
                {
                    var aButton = new Button(this);
                    aButton.Text = item.disease + item.diseaseid;
                    layout.AddView(aButton);
                    SetContentView(layout);
                }


            }
            catch(Exception i)
            {
                Toast.MakeText(this, i.ToString(), ToastLength.Short).Show();
            }
        }
    }
}