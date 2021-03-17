using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Universidad.Clases;


namespace Universidad.Cursos
{
    public class Matricula
    {
        [PrimaryKey,AutoIncrement]
        public int Id { set; get; }
        [ForeignKey(typeof(Curso))]
        public int CursoId { set; get; }
        public string NombreEstudiante { set; get; }
        public double PromedioFinal { set; get; }
    }
}