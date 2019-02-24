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
    [Activity(Label = "ExerciseActivitiy")]
    public class ExerciseActivitiy : Activity
    {

        string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.hackton");
        EditText txtDiseaseID;
        EditText txtToDO;
        EditText txtMinutesToDo;
        EditText txtDifficulty;
        EditText txtBodyPart;
        Button btnAddDiet;
        Button btnget;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Exercise);


            txtDiseaseID = FindViewById<EditText>(Resource.Id.txtexerciseiddeasease);
            txtToDO = FindViewById<EditText>(Resource.Id.txttodo);
            txtMinutesToDo = FindViewById<EditText>(Resource.Id.txtminutes);
            txtDifficulty = FindViewById<EditText>(Resource.Id.txtdifficulty);
            txtBodyPart = FindViewById<EditText>(Resource.Id.txtbodypart);
            btnAddDiet = FindViewById<Button>(Resource.Id.btnAdd);
            btnget = FindViewById<Button>(Resource.Id.btnGet);
            btnAddDiet.Click += BtnAdd_Click;
            btnget.Click += BtnGet_Click;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                var db = new SQLiteConnection(dpPath);
                db.CreateTable<tblExercise>();
                tblExercise tbl = new tblExercise();
                tbl.IDDeasease = txtDiseaseID.Text;
                tbl.ToDo = txtToDO.Text;
                tbl.Minutes = txtMinutesToDo.Text;
                tbl.Difficulty = txtDifficulty.Text;
                tbl.BodyPart = txtBodyPart.Text;
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
                var test = db.Table<tblExercise>();

                foreach (var item in test)
                {
                    var aButton = new Button(this);
                    aButton.Text = item.ToDo;
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