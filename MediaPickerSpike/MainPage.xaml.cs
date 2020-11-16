using MediaPickerSpike.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MediaPickerSpike
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private CaptureVideoViewModel vm;
        
        public MainPage()
        {
            InitializeComponent();
            vm = new CaptureVideoViewModel(Navigation);
            BindingContext = vm;
        }
    }
}
