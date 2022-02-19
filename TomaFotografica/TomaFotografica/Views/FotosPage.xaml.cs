using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_4_Grupo2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FotosPage : ContentPage
    {
        public FotosPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listafoto = await App.Basedatos02.ObtenerListaFotos();
            lstFotos.ItemsSource = listafoto;

        }

        private void lstFotos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Modals.Fotos item = (Modals.Fotos)e.Item;
        }
    }
}