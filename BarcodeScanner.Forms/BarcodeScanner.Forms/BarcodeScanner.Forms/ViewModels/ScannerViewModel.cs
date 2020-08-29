using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarcodeScanner.Forms.ViewModels
{

    public class ScannerViewModel:BaseViewModel
    {
        public Command ScanCommand { get; set; }

        public ScannerViewModel()
        {
            ScanCommand = new Command(async (obj) => 
            {
                var scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) => {
                    scanPage.IsScanning = false;
                    Device.BeginInvokeOnMainThread(async () => {
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                        await Application.Current.MainPage.DisplayAlert("Scanned Barcode", result.Text + " , " + result.BarcodeFormat + " ," + result.ResultPoints[0].ToString(), "OK");
                    });
                };
                await Application.Current.MainPage.Navigation.PushModalAsync(scanPage);
            });
        }
    }
}
