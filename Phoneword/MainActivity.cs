using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace Phoneword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //New Code will go here
            // Get our UI controls from the loaded layout
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
            Button translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);

            // Add code to translate number
            string translatedNumber = string.Empty;
            translateButton.Click += (sender, e) =>
            {
                // Translate user's alphanumeric phone number to numeric
                translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    translatedPhoneWord.Text = "";
                }
                else
                {
                    translatedPhoneWord.Text = translatedNumber;
                    phoneNumbers.Add(translatedNumber);
                    translationHistoryButton.Enabled = true;
                }
            };
            translationHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
        }
    }
}