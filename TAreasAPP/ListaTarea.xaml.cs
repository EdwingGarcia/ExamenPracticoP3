using System.Collections.ObjectModel;
using TAreasAPP.Models;
using TAreasAPP.Services;

namespace TAreasAPP;

public partial class ListaTarea : ContentPage
{
    private readonly ApiService _apiService;
    private Tarea _tarea;
    private string nombre;
    private string estado;

	public ListaTarea(ApiService api)
	{
        _apiService = api;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        List<Tarea> ListaTareas = await _apiService.GetAllTarea();
        var tareas = new ObservableCollection<Tarea>(ListaTareas);
        listaTareas.ItemsSource = tareas;
    }


        private async void OnClickBuscar(object sender, EventArgs e)
    {
        nombre =Nombre.Text ;
        estado = Estado.SelectedItem !!= null ? Estado.SelectedItem.ToString(): string.Empty;

        List<Tarea> filtrada =await _apiService.BuscarTareaNombreEstado(nombre, estado);
        var lista = new ObservableCollection<Tarea>(filtrada);
        listaTareas.ItemsSource=lista;
    }

    private async void OnClickNuevo(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevaTarea(_apiService));

    }
}