using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Universidad.Cursos;

namespace Universidad.Clases
{
    public class Curso
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Nombre { set; get; }
        [OneToMany]
        public List<Matricula> matriculas { set; get; }
       public Curso()
        {

        }
    }
}
