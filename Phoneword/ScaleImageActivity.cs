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

namespace Phoneword
{
    [Activity(Label = "My Activity", Theme = "@style/AppTheme")]
    public class ScaleImageActivity : Activity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ScaleImage);
            // Create your application here
            Button btnNext = FindViewById<Button>(Resource.Id.btnNext);
            Button btnPrevious = FindViewById<Button>(Resource.Id.btnPrevious);
            var ScaleImageView = FindViewById<SampleScaleImage.ScaleImageView>(Resource.Id.image);

            //Switch Image on Button Press
            btnNext.Click += (sender, e) =>
            {
                ScaleImageView.SetImageResource(Resource.Drawable.seattle);
            };

            btnPrevious.Click += (sender, e) =>
            {
                ScaleImageView.SetImageResource(Resource.Drawable.report);
                
                
            };
        }

        public void convertPDFtoJPG() {
           
            
        }
    }
}