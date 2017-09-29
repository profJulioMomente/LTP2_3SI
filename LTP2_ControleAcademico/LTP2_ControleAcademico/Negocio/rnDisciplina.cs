using LTP2_ControleAcademico.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LTP2_ControleAcademico.Negocio
{
    public class rnDisciplina : Disciplina
    {
        public rnDisciplina()
        {
            Curso = new rnCurso();
        }

        public void inserir()
        {
            string query = "INSERT INTO disciplina (Codigo_Disciplina, Nome_Disciplina, Ementa_Disciplina, Semestre_Disciplina, CargaHoraria_Disciplina, ID_Curso) VALUES(";
            query = query + "'" + Codigo_Disciplina + "',"
                          + "'" + Nome_Disciplina + "',"
                          + "'" + Ementa_Disciplina + "',"
                          + Semestre_Disciplina + ","
                          + CargaHoraria_Disciplina + ","
                          + Curso.ID_Curso + ")";

            //Chamada a classe de conexao
            Conexao.modificarTabela(query);
        }

        public void alterar()
        {
            string query = "UPDATE Disciplina SET ";
            query = query + "Codigo_Disciplina='" + Codigo_Disciplina + "',"
                          + "Nome_Disciplina='" + Nome_Disciplina + "',"
                          + "Ementa_Disciplina='" + Ementa_Disciplina + "',"
                          + "Semestre_Disciplina=" + Semestre_Disciplina + ","
                          + "CargaHoraria_Disciplina=" + CargaHoraria_Disciplina + " "
                          + "ID_Curso=" + Curso.ID_Curso + " "
                          + "WHERE ID_Disciplina=" + ID_Disciplina;

            Conexao.modificarTabela(query);
        }

        public void excluir()
        {
            string query = "DELETE FROM disciplina "
                          + "WHERE ID_Disciplina=" + ID_Disciplina;

            Conexao.modificarTabela(query);
        }

        public DataTable recuperarDisciplinas(string filtro)
        {
            string query;
            if (String.IsNullOrEmpty(filtro))
            {
                query = "SELECT * FROM disciplina";
            }
            else
            {
                query = "SELECT * FROM disciplina WHERE " + filtro;
            }

            DataTable Dados = new DataTable();
            Dados = Conexao.carregarTabela(query);
            return Dados;
        }
        /// <summary>
        /// Recupera um único registro definido pelo Identificado (Chave Primaria)
        /// </summary>
        public void recuperarRegistro()
        {
            string query = "SELECT * FROM disciplina WHERE ID_Disciplina = " + ID_Disciplina;
            DataTable Dados = new DataTable();
            Dados = Conexao.carregarTabela(query);

            if (Dados != null)
            {
                DataRow dr = Dados.Rows[0];
                Codigo_Disciplina = dr["Codigo_Disciplina"].ToString();
                Nome_Disciplina = dr["Nome_Disciplina"].ToString();
                Ementa_Disciplina = dr["Ementa_Disciplina"].ToString();
                Semestre_Disciplina = Convert.ToInt32(dr["Semestre_Disciplina"].ToString());
                CargaHoraria_Disciplina = Convert.ToInt32(dr["CargaHoraria_Disciplina"].ToString());
                Curso.ID_Curso = Convert.ToInt32(dr["ID_Curso"].ToString());

                Curso.recuperarRegistro();
            }
        }

        public static implicit operator rnDisciplina(rnCurso v)
        {
            throw new NotImplementedException();
        }
    }
}