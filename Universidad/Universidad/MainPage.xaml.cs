using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Universidad.Cursos;
using Universidad.Clases;

namespace Universidad
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        List <Curso> cursos; 
        public MainPage()
        {
            InitializeComponent();
            cursos = new List<Curso>();
            lstUniversidad.ItemSelected += lstUniversidad_ItemSelected; 
        }
        private void lstUniversidad_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cursos = e.SelectedItem as Curso;
            Navigation.PushAsync(new ListaCursoIndividual(cursos));
        }
        private void ToolbarItemAgregar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NuevoCurso());
        }
        private void ToolbarItemAgregarMatricula_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NuevaMatricula());
        }
        protected override void OnAppearing()
        {

            base.OnAppearing();
            using (var conn= new SQLite.SQLiteConnection(App.RUTA_BD))
            {
                conn.CreateTable<Curso>();
                cursos = conn.Table<Curso>().ToList();
                lstUniversidad.ItemsSource = cursos;
            }
        }
    }
}
