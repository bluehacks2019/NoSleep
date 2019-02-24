using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JuanLife.Model
{
    class tblDiet
    {
        [PrimaryKey, AutoIncrement, Column("_DietID")]
        public int dietid { get; set; }

        [MaxLength(20)]
        public string diseaseid { get; set; }

        [MaxLength(25)]
        public string foodname { get; set; }

        [MaxLength(25)]
        public string dietdescription { get; set; }

        [MaxLength(25)]
        public string benifit { get; set; }
    }
}