using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinForms.FloatingButton
{
    public partial class ListPage : ContentPage
    {
        public ICommand TestCommand { get; }
        
        public ListPage()
        {
            TestCommand = new Command(() =>
            {
                // FloatingButton also handles Commands!
            });
            
            InitializeComponent();

            var items = new List<string>();
            
            for (int i = 0; i < 20; i++)
            {
                items.Add(i + " Lorem ipsum dolor sit amet, consectetur adipiscing elit");//". Cras eget iaculis Tappeda quam eget arcu eleifend maximus. Morbi in ultrices ante, non faucibus mauris.");
            }

            ListView.ItemsSource = items;
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new ItemDetailsPage(e.Item as string));
        }

        private void FloatingButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateItemPage());
        }
    }
}