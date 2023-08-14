namespace Beekeeming.Xamarin.Views
{
    using Beekeeming.Xamarin.ViewModels;
    using System.ComponentModel;
    using Xamarin.Forms;

    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}