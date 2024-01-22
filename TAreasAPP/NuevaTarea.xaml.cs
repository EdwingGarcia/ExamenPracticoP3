using TAreasAPP.Models;
using TAreasAPP.Services;

namespace TAreasAPP;

public partial class NuevaTarea : ContentPage
{
    private readonly ApiService _apiService;
    private Tarea _tarea;
    public NuevaTarea(ApiService apiService)
	{
		InitializeComponent();
        _apiService = apiService;


	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _tarea = BindingContext as Tarea;
        if (_tarea != null)
        {
            Nombre.Text = _tarea.Nombre;
            Estado.SelectedItem = _tarea.Estado.ToString();
            Descripcion.Text = _tarea.Descripcion;
        }
    }

    private async void OnClickGuardar(object sender, EventArgs e)
    {


        Tarea Tarea = new Tarea
        {
            IdTarea = 0,
            Nombre = Nombre.Text,
            Descripcion = Descripcion.Text,
            Estado = Estado.SelectedItem.ToString() != null ? Estado.SelectedItem.ToString() : string.Empty  };

            await _apiService.CreateTarea(Tarea);
        
        await Navigation.PopAsync();

    }
}