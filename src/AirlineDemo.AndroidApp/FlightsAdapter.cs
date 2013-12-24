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
using AirlineDemo.PortableBusiness.Data;

namespace AirlineDemo.AndroidApp
{
    public class FlightsAdapter : BaseAdapter<FlightInfo>
    {
        List<FlightInfo> flights;

        Activity context;

        public FlightsAdapter(Activity context, List<FlightInfo> flights)
            : base()
        {
            this.context = context;
            this.flights = flights;
        }

        public override FlightInfo this[int position]
        {
            get { return this.flights[position]; }
        }

        public override int Count
        {
            get { return this.flights.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.FlightItem, null);
            }

            view.FindViewById<TextView>(Resource.Id.carrierTextView).Text = this.flights[position].Carrier;
            view.FindViewById<TextView>(Resource.Id.flightNoTextView).Text = this.flights[position].FlightNo;
            view.FindViewById<TextView>(Resource.Id.etdTextView).Text = this.flights[position].Etd;
            view.FindViewById<TextView>(Resource.Id.etaTextView).Text = this.flights[position].Eta;
            view.FindViewById<TextView>(Resource.Id.priceTextView).Text = this.flights[position].Price.ToString();

            return view;
        }
    }
}