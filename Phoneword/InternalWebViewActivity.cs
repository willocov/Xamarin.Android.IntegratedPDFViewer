using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Webkit;

namespace Phoneword
{
    [Activity(Label = "InternalWebViewActivity")]
    public class InternalWebViewActivity : Activity
    {
        WebView web_view;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.InternalWebView);

            /*
            web_view = FindViewById<WebView>(Resource.Id.webView);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(new HelloWebViewClient());
            //web_view.LoadUrl("https://www.xamarin.com/university");
            //web_view.LoadUrl("http://drive.google.com/viewerng/viewer?embedded=true&url=" + "/data/user/0/Phoneword.Phoneword/files/pdf.pdf");
            */
            string filepath = GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).ToString();
            filepath += "/pdf.pdf";

            web_view = FindViewById<WebView>(Resource.Id.webView);
            //WebSettings settings = web_view.getSettings();
            //settings.setJavaScriptEnabled(true);

            
            web_view.Settings.JavaScriptEnabled = true;
            web_view.Settings.AllowFileAccessFromFileURLs = true;
            web_view.Settings.AllowUniversalAccessFromFileURLs = true;
            web_view.Settings.BuiltInZoomControls = true;
            web_view.Settings.SetSupportZoom(true);
            web_view.SetWebChromeClient(new WebChromeClient());
            web_view.LoadUrl("file:///android_asset/pdfjs/web/viewer.html?file=" + filepath);
            
        }

        public class HelloWebViewClient : WebViewClient
        {
            // For API level 24 and later
            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            {
                view.LoadUrl(request.Url.ToString());
                return false;
            }
        }
    }
}