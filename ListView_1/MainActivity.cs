using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Util;

// Create a custom adapter: MyAdapter class
// Custom Adapter works the same as SimpleListItem1 from ListView_0
// but now can add code for changing rows for ads/purchase


namespace ListView_1 
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // create data set for listview
            var data = new List<string>();
            for (int i = 0; i < 100; i++)
                data.Add("Item number: " + i);

            // reference listView with layout resource
            var listView = FindViewById<ListView>(Resource.Id.listView1);

			// create custom adapter and apply it to listView
			var adapter = new MyAdapter(this, data);
            listView.Adapter = adapter;

            listView.ItemClick += ListView_ItemClick; // ListView_ItemClick added by Intellisense by pressing Tab
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e) {
            Log.Debug("-----DEBUG-----", "Number: " + e.Position);
        }
    }
}

