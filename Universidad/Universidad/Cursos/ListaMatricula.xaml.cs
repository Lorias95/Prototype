using System.Collections.Generic;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Universidad.Cursos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaMatricula : ContentPage
    {
        List<Matricula> matriculas;
        public ListaMatricula()
        {
            InitializeComponent();
            matriculas = new List<Matricula>();
            lstMatricula.ItemSelected += LstMatricula_ItemSelected; ;
        }

        private void LstMatricula_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var matricula = e.SelectedItem as Matricula;
            Navigation.PushAsync(new EditarMatricula { BindingContext = matricula});
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var conn = new SQLite.SQLiteConnection(App.RUTA_BD))
            {
                conn.CreateTable<Matricula>();
                matriculas = conn.Table<Matricula>().ToList();
                lstMatricula.ItemsSource = matriculas;
            }
        }

    }
}