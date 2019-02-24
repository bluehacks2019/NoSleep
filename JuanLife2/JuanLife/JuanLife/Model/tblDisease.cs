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
    class tblDisease
    {

        [PrimaryKey, AutoIncrement, Column("_DiseaseId")]
        public int diseaseid { get; set; }

        [MaxLength(200)]
        public string disease { get; set; }

        [MaxLength(200)]
        public string description { get; set; }

        [MaxLength(25)]
        public string cause { get; set; }

        [MaxLength(25)]
        public string cure { get; set; }


    }
}