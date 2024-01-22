using TAreasAPP.Services;

namespace TAreasAPP
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
            ApiService apiService = new ApiService();
            MainPage = new NavigationPage( new ListaTarea(apiService));
        }
    }
}
