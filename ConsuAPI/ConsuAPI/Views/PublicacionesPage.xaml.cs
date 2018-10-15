using ConsuAPI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsuAPI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PublicacionesPage : ContentPage
	{
        private IEnumerable listado;

        public PublicacionesPage ()
		{
			InitializeComponent ();
            CargarPublicaciones();
        }

        private async Task CargarPublicaciones()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("");
            var request = client.GetAsync("/api/Publicacion").Result;
            if (request.IsSuccessStatusCode)
            {
                var responseJson = request.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DesarializeObject<List<Publicaciones>>(responseJson);
                listPublicaciones.ItemsSource = listado;
            }

            
        }
        private async void ProductoSeleccionado(object sender, SelectedItemChangedEventArgs e)
        {
            var producto = e.SelectedItem as Publicaciones;
            string mensaje = string.Format("Producto : {0} - Cantidad : {1}", producto.Usuario, producto.Cantidad);
            await DisplayAlert("Producto seleccionado", mensaje, "Ok");
        }
    }

    internal class JsonConvert
    {
        internal static object DesarializeObject<T>(string responseJson)
        {
            throw new NotImplementedException();
        }
    }
}