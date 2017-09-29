using LTP2_ControleAcademico.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTP2_ControleAcademico.Entidade
{
    public class Disciplina
    {
        public int ID_Disciplina { get; set; }
        public string Codigo_Disciplina { get; set; }
        public string Nome_Disciplina { get; set; }
        public string Ementa_Disciplina { get; set; }
        public int Semestre_Disciplina { get; set; }
        public int CargaHoraria_Disciplina { get; set; }
        
        //public int ID_Curso { get; set; }
        public rnCurso Curso { get; set; }
    }
}