
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using Xamarin.Essentials;
namespace Barcode
{

    public partial class MainPage : ContentPage
    {
        private string myStringProperty;
        public string MyStringProperty
        {
            get { return myStringProperty; }
            set
            {
                myStringProperty = value;
                OnPropertyChanged(nameof(MyStringProperty)); // Notify that there was a change on this property
            }
        }
        ZXingScannerPage scanPage;
        public MainPage()
        {
            /*// Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Orientation (Landscape, Portrait, Square, Unknown)
            var orientation = mainDisplayInfo.Orientation;

            // Rotation (0, 90, 180, 270)
            var rotation = mainDisplayInfo.Rotation;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;

            // Screen density
            var density = mainDisplayInfo.Density;*/

            InitializeComponent();
            ButtonScanDefault.Clicked += ButtonScanDefault_Clicked;
        }
        private async void ButtonScanDefault_Clicked(object sender, EventArgs e)
        {
            BindingContext = this;

            MyStringProperty = "New label text"; // It will be shown at your label
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                //do something here
             
                Item.Text = result.Text;
                MyStringProperty = result.Text;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    await DisplayAlert("Scanned Barcode", Item.Text, "OK");
                });
            };

            await Navigation.PushModalAsync(scanPage); 
            //throw new NotImplementedException();
        }

    }
   
}
