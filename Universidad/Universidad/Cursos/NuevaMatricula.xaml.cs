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
    public partial class NuevaMatricula : ContentPage
    {
        public NuevaMatricula()
        {
            InitializeComponent();
            using (var conn = new SQLite.SQLiteConnection(App.RUTA_BD))

            {
                conn.CreateTable<Matricula>();
                pCursos.ItemsSource = conn.Table<Curso>().ToList();
            }
        }
        async private void AgregarMatricula_Clicked(object sender, EventArgs e)
        {
            var cursoSeleccionado = (Curso)pCursos.SelectedItem;
            Matricula matricula = new Matricula()
            {
                NombreEstudiante=txtNombreEst.Text,
                PromedioFinal=double.Parse(txtPromedioFinal.Text),
            };
            using (var conn = new SQLite.SQLiteConnection(App.RUTA_BD))
            {
                conn.CreateTable<Matricula>();
                conn.CreateTable<Curso>();
                conn.Insert(matricula);
                var curso = conn.GetWithChildren<Curso>(cursoSeleccionado.Id);
                curso.matriculas.Add(matricula);
                conn.UpdateWithChildren(curso);
            }
            await Navigation.PushAsync(new ListaMatricula());
        }
        private void ListaMatricula_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaMatricula());
        }

        private void PCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = (Curso)pCursos.SelectedItem;
        }
    }
}