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
    public partial class NuevoCurso : ContentPage
    {
        public NuevoCurso()
        {
            InitializeComponent();
        }
        async private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Curso cursos = new Curso()
            {
                Nombre = txtNombre.Text,
            };
            using (var conn = new SQLite.SQLiteConnection(App.RUTA_BD))
            {
                conn.CreateTable<Curso>();
                conn.Insert(cursos);
            }
            await Navigation.PopAsync();
        }
    }
}