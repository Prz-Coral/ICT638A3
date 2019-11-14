using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bluetooth : ContentPage
    {
        public Bluetooth()
        {
            InitializeComponent();
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if (bluetoothAdapter == null)
            {
                Toast.MakeText(this, "Bluetooth is not available", ToastLength.Long).Show();
                Finish();
                return;
            }
        }
    }

}