using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using System.Collections.Generic;

namespace SearchGoogleApp
{
//{    [Activity(Label = "@string/app_name", MainLauncher = true,LaunchMode = LaunchMode.SingleTop)]
//	 [IntentFilter(new[] { Intent.ActionSearch, Intent.ActionView , "com.google.android.gms.actions.SEARCH_ACTION" }, 
//		Categories = new []{Intent.CategoryDefault})]
//	[MetaData("android.app.searchable", Resource = "@drawable/icon")]
	[Activity (Label = "SearchGoogleApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		List<Post> list = new List<Post>();
		ListView listView;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);

			EditText editText = FindViewById<EditText> (Resource.Id.myEditText);

			listView = FindViewById<ListView> (Resource.Id.listView1);
			CustomAdapter _custAdaptor = new CustomAdapter (this, list);

			button.Click += delegate {
				
				if(editText.Text.Trim().Length > 0)
				{
					SearchService searchService = new SearchGoogleApp.SearchService(editText.Text);
					if (searchService.SearchApi().ToString().Trim().Length > 0)
					{
						Post _post = new Post();
						_post.question = editText.Text ;
						_post.answer = searchService.SearchApi().ToString();

						list.Add(_post);

						listView.Adapter = _custAdaptor;
						editText.Text = "";
					}
				}

//				Intent intent = new Intent(Intent.ActionWebSearch);
//				String term = editText.Text;
//				Bundle bundle1 = new Bundle();
//				bundle1.PutString(SearchManager.Query, term);
//				intent.PutExtras(bundle1);
//				StartActivityForResult(intent);
			};
		}
	}
}


