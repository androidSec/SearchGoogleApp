using System;
using Android.Views;
using Android.App;
using System.Collections.Generic;
using Android.Widget;

namespace SearchGoogleApp
{
	public class Post
	{
		public string question { get; set; }
		public string answer { get; set; }
	}

	public class CustomAdapter: BaseAdapter<Post>
	{
		Activity context;
		List<Post> list;

		public CustomAdapter (Activity _context, List<Post> _list)
			:base()
		{
			this.context = _context;
			this.list = _list;
		}

		public override int Count {
			get { return list.Count; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override Post this[int index] {
			get { return list [index]; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView; 

			// re-use an existing view, if one is available
			// otherwise create a new one
			if (view == null)
				view = context.LayoutInflater.Inflate (Resource.Layout.listrowitem, parent, false);

			Post item = this [position];
			view.FindViewById<TextView> (Resource.Id.Question).Text = item.question;
			view.FindViewById<TextView>(Resource.Id.Answer).Text = item.answer;


			return view;
		}
	}

}