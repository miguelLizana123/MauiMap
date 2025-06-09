using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors; // Para Geolocation
using Microsoft.Maui.ApplicationModel; // Para Permissions
using Microsoft.Maui.Maps;
namespace MauiAppAndroid.Views
{
    public partial class MapaPage : ContentPage
    {
        public MapaPage()
        {
            InitializeComponent();
            ObtenerUbicacionAsync();
        }
        private async Task ObtenerUbicacionAsync()
        {
            try
            {
                var ubicacion = await Geolocation.GetLastKnownLocationAsync();

                if (ubicacion == null)
                    ubicacion = await Geolocation.GetLocationAsync();

                if (ubicacion != null)
                {
                    var posicion = new Location(ubicacion.Latitude, ubicacion.Longitude);
                    mapa.MoveToRegion(Microsoft.Maui.Maps.MapSpan.FromCenterAndRadius(posicion, Distance.FromKilometers(1)));
                }
                var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    await DisplayAlert("Permiso denegado", "La app necesita acceder a la ubicación.", "OK");
                    return;
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "No se pudo obtener ubicación: " + ex.Message, "OK");
            }
        }
    }
}
