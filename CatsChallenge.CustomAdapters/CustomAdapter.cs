﻿using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using CatsChallenge.Entities;

namespace CatsChallenge.CustomAdapters
{
    public class CustomAdapter : BaseAdapter<Cat>
    {
        List<Cat> Items;
        Activity context;
        int ItemLayoutTemplate;
        int ImageViewID;
        int NameViewID;
        int PriceViewID;

        public CustomAdapter(Activity context, List<Cat> items, int layout, 
            int imageView, int nameView, int priceView)
        {
            this.context = context;
            this.Items = items;
            this.ItemLayoutTemplate = layout;
            this.ImageViewID = imageView;
            this.NameViewID = nameView;
            this.PriceViewID = priceView;
        }

        public override Cat this[int position] {
            get { return Items[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = Items[position];
            View itemView;

            if (convertView == null)
                itemView = context.LayoutInflater.Inflate(ItemLayoutTemplate, null);
            else
                itemView = convertView;

            itemView.FindViewById<TextView>(NameViewID).Text = item.Name;
            itemView.FindViewById<TextView>(PriceViewID).Text = item.Price.ToString("C2");

            var image = itemView.FindViewById<ImageView>(ImageViewID);
            Koush.UrlImageViewHelper.SetUrlDrawable(image, item.Image);

            return itemView;
        }

        public override int Count
        {
            get
            {
                return Items.Count;
            }
        }
    }
}