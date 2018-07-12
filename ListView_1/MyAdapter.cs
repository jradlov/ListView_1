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

// Custom Adapter that works the same as SimpleListItem1 from ListView_0
// but now can add code for changing rows for ads/purchase


namespace ListView_1 
{
	public class MyAdapter : BaseAdapter<string>
	{
		List<string> items;  // list of strings to populate the adapter
		Activity context;

		public MyAdapter(Activity context, List<string> items) {
			this.items = items;
			this.context = context;
		}


		// Below: default methods that need to be called when the adapter is fired

		public override long GetItemId(int position) { // return current adapter position
			return position;
		}

		public override string this[int index] {  // return item in question
			get { return items[index]; }
		}

		public override int Count {	// return the length of the list (so android knows how many rows to create)
			get { return items.Count;  }  // .Count for List, items.Length if array
		}

		// since it's a custom adapter, we have to create a way to display our data:
		// GetView(): create/recycle row & allow you to populate it with data
		public override View GetView(int position, View convertView, ViewGroup parent) {
			
			// converView is the recycled row that scrolled off screen that we can reuse
			View view = convertView;
			if (view == null)   // we didn't get a recycled cell/row: have to create one
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

			var item = items[position];

			// this 'if' is not needed, but good away to add ad/purchase to listview (trick users into buying something :) 
			// can also cut list from 100 items to 10 with last row asking for subscription to get the whole list :) !!!
			if (position == 3)	// replace item 3 with below
				item = "(Available to subscribers only)";

			// inside this row we have some text elements we'd like to populate with data
			// (Text1: default property from SimpleListItem1)
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item;
			return view;
		}

	}
}