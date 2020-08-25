using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinForms.FloatingButton
{
    public partial class ItemDetailsPage : ContentPage
    {
        public ItemDetailsPage(string item)
        {
            InitializeComponent();
            Label.Text = item;
        }
    }
}