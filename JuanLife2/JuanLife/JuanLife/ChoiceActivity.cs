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
    [Activity(Label = "ChoiceActivity")]
    public class ChoiceActivity : Activity
    {
        string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.hackton");
        Button btndiet;
        Button btnexe;

        string ID = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.choice);


            btndiet = FindViewById<Button>(Resource.Id.btndiet);
            btnexe = FindViewById<Button>(Resource.Id.btnexe);

            string name = Intent.GetStringExtra("DiseaseID");
            ID = name;

            btndiet.Click += BtnAdd_Click;

            btnexe.Click += BtnEx_Click;


        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var layout = new LinearLayout(this);
            layout.SetBackgroundColor(Android.Graphics.Color.Orange);
            layout.Orientation = Orientation.Vertical;
            try
            {
                var db = new SQLiteConnection(dpPath);
                var test = db.Table<tblDiet>();
                var datas = test.Where(x => x.diseaseid == ID).ToList();
                foreach(var data1 in datas)
                {
                    var aButton = new Button(this);
                    aButton.Text = "Diet Food :"+ data1.foodname + "\n" + "Description : " + data1.dietdescription;
                    layout.AddView(aButton);
                    SetContentView(layout);
                }

            }
            catch(Exception i)
            {

            }
        }
        private void BtnEx_Click(object sender, EventArgs e)
        {
            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;
            layout.SetBackgroundColor(Android.Graphics.Color.Orange);
            try
            {
                var db = new SQLiteConnection(dpPath);
                var test = db.Table<tblExercise>();
                var datas = test.Where(x => x.IDDeasease == ID).ToList();
                foreach (var data1 in datas)
                {
                    var aButton = new Button(this);
                    aButton.Text = "Work-Out :" + data1.ToDo + "\n" +
                        "Type : " + data1.Difficulty + "\n" +
                        "Time : " + data1.Minutes;
                    layout.AddView(aButton);
                    SetContentView(layout);
                }
            }
            catch (Exception i)
            {

            }
        }
    }
}