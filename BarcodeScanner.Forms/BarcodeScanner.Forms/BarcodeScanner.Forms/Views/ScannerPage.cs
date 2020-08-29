using BarcodeScanner.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Markup;
using ZXing.Net.Mobile.Forms;

namespace BarcodeScanner.Forms.Views
{
    public class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            BindingContext = new ScannerViewModel();
            Content  = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Button
                    {
                        Text = "Scan",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    }.Bind(Button.CommandProperty, nameof(ScannerViewModel.ScanCommand))
                }
            };
            
        }
    }
}