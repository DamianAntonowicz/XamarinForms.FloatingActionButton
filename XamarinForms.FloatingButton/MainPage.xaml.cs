using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms.FloatingButton
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PlayAnimation_Clicked(System.Object sender, System.EventArgs e)
        {
            FloatingButton.Scale = 0;
            FloatingButton.ScaleTo(1, easing: Easing.SpringOut);
        }

        private void PlayAnimationReset_Clicked(System.Object sender, System.EventArgs e)
        {
            FloatingButton.Scale = 0;
        }
    }
}
