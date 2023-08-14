namespace Beekeeming.Xamarin.Views
{
    using Beekeeming.Xamarin.Models;
    using Beekeeming.Xamarin.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}