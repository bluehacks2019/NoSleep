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
using Plugin.TextToSpeech;

namespace JuanLife
{
    [Activity(Label = "AskActivty")]
    public class AskActivty : Activity
    {
        EditText txtask;
        Button btnAsk;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.askmarcky);

            txtask = FindViewById<EditText>(Resource.Id.txtAsk);
            btnAsk = FindViewById<Button>(Resource.Id.btnask);

            btnAsk.Click += BtnAdd_Click;
            // Create your application here
        }
        public void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtask.Text.Contains("Hello"))
            {
                CrossTextToSpeech.Current.Speak("Hello, You can Ask me if you want");
            }
            else if(txtask.Text.Contains("What is your name"))
            {
                CrossTextToSpeech.Current.Speak("My name is Marcky");
            }
            else if (txtask.Text.Contains("How old Are you"))
            {
                CrossTextToSpeech.Current.Speak("I'm only 20years old");
            }
            else if (txtask.Text.Contains("Cancer"))
            {
                CrossTextToSpeech.Current.Speak("Cancer is the second most common cause of death in the world it accounts for nearly 1 in 4 deaths.");
            }
            else if (txtask.Text.Contains("Heart Disease"))
            {
                CrossTextToSpeech.Current.Speak("Heart disease describes a range of conditions that affect your heart. ");
            }
            else if (txtask.Text.Contains("Vascular Disease"))
            {
                CrossTextToSpeech.Current.Speak("Vascular disease is any abnormal condition of the blood vessels.The body uses blood vessels to circulate blood through itself.Problems along this vast network can cause severe disability and death.");
            }
            else if (txtask.Text.Contains("Pneumonia"))
            {
                CrossTextToSpeech.Current.Speak("lung inflammation caused by bacterial or viral infection, in which the air sacs fill with pus and may become solid. Inflammation may affect both lungs ( double pneumonia ), one lung ( single pneumonia ), or only certain lobes ( lobar pneumonia ).");
            }
            else if (txtask.Text.Contains("Malignant neoplasm"))
            {
                CrossTextToSpeech.Current.Speak("a tumor that is malignant and tends to spread to other parts of the body");
            }
            else if (txtask.Text.Contains("Tubercolosis"))
            {
                CrossTextToSpeech.Current.Speak("an infectious bacterial disease characterized by the growth of nodules (tubercles) in the tissues, especially the lungs.diabetes - a disease in which the body’s ability to produce or respond to the hormone insulin is impaired, resulting in abnormal metabolism of carbohydrates and elevated levels of glucose in the blood and urine.");
            }
            else if (txtask.Text.Contains("mellitus"))
            {
                CrossTextToSpeech.Current.Speak("a variable disorder of carbohydrate metabolism caused by a combination of hereditary and environmental factors and usually characterized by inadequate secretion or utilization of insulin, by excessive urine production, by excessive amounts of sugar in the blood and urine, and by thirst, hunger, and loss of weight");
            }
            else if (txtask.Text.Contains("Asthma"))
            {
                CrossTextToSpeech.Current.Speak("Asthma is defined as a common, chronic respiratory condition that causes difficulty breathing due to inflammation of the airways. Asthma symptoms include dry cough, wheezing, chest tightness and shortness of breath.");
            }
            else
            {
                CrossTextToSpeech.Current.Speak("Sorry, I Did not understand");
            }
        }
    }
}