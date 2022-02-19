using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Media;

using Ejercicio1_4_Grupo2.Modals;

namespace Ejercicio1_4_Grupo2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("imagen"))
            {
                image1.Source = Application.Current.Properties["imagen"].ToString();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No se soporta el cargar fotos", "ok");
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "mifoto.jpg"
            });

            if (file == null)
            {

                return;
            }
            //await DisplayAlert("El path es:", file.Path, "ok");
            image1.Source = file.Path;
            //Console.WriteLine(file.Path);
            Application.Current.Properties["imagen"] = file.Path;

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No se soporta el cargar fotos", "ok");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions { 
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });
          
            if (file == null)
            {
                return;
            }

            image1.Source = file.Path;
            //Console.WriteLine(file.Path);
            Application.Current.Properties["imagen"] = file.Path;
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                var fotos = new Modals.Fotos
                {
                    
                    //nombre = Convert.ToDouble(this.txtnombre.Text),
                    //descripcion = this.txtdescripcion.Text,
                   


                };

                var resultado = await App.Basedatos02.Grabarfotografia(fotos);


                if (resultado == 1)
                {
                    await DisplayAlert("Mensaje", "Ingresada Exitosamente", "OK");
                }
                else
                {
                    await DisplayAlert("Mensaje", "Error, No se logro guardar Ubicacion", "OK");

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje", ex.Message.ToString(), "OK");

            }

        }
    } 
}
