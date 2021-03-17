using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Clases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Universidad.Cursos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaCursoIndividual : ContentPage
    {
        public Curso Curso { set; get; }
        public ListaCursoIndividual(Curso curso)
        {
            InitializeComponent();
            Curso = curso;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lstMatricula.ItemsSource = null;
            using (var conn = new SQLite.SQLiteConnection(App.RUTA_BD))
            {
                conn.CreateTable<Curso>();
                Curso = conn.GetWithChildren<Curso>(Curso.Id);
                lstMatricula.ItemsSource = Curso.matriculas;
            }
        }
    }
}