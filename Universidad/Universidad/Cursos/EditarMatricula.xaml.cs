using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Universidad.Cursos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarMatricula : ContentPage
    {
        public EditarMatricula()
        {
            InitializeComponent();
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            using (var cnn = new SQLite.SQLiteConnection(App.RUTA_BD))
            {
                var matricula = (Matricula)BindingContext;
                cnn.Delete(matricula);
            }
            await Navigation.PopAsync();

            
        }

        private async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            var matricula = (Matricula)BindingContext;
            using (var cnn = new SQLite.SQLiteConnection(App.RUTA_BD))
            {
                cnn.Update(matricula);
            }
            await Navigation.PopAsync();

        }
    }
}