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
    class tblExercise
    {
        [PrimaryKey, AutoIncrement, Column("_ExerciseID")]
        public int exericseid { get; set; }

        [MaxLength(20)]
        public string IDDeasease { get; set; }

        [MaxLength(20)]
        public string ToDo { get; set; }

        [MaxLength(25)]
        public string Minutes { get; set; }

        [MaxLength(25)]
        public string Difficulty { get; set; }

        [MaxLength(25)]
        public string BodyPart { get; set; }
    }
}