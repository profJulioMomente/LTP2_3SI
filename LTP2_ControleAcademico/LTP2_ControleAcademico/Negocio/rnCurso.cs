using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LTP2_ControleAcademico.Entidade;
using System.Data;

namespace LTP2_ControleAcademico.Negocio
{
    public class rnCurso : Curso
    {
        public void inserir()
        {
            string query = "INSERT INTO curso (Codigo_Curso, Nome_Curso, Periodo_Curso, Duracao_Curso, Enade_Curso) VALUES(";
            query = query + "'" + Codigo + "',"
                          + "'" + Nome + "',"
                          + "'" + Periodo + "',"
                          + "'" + Duracao + "',"
                          + "'" + Enade + "')";

            //Chamada a classe de conexao
            Conexao.modificarTabela(query);
        }

        public void alterar()
        {
            string query = "UPDATE curso SET ";
            query = query + "Codigo_Curso='" + Codigo + "',"
                          + "Nome_Curso='" + Nome + "',"
                          + "Periodo_Curso='" + Periodo + "',"
                          + "Duracao_Curso='" + Duracao + "',"
                          + "Enade_Curso='" + Enade + "' "
                          + "WHERE ID_Curso=" + ID_Curso;

            Conexao.modificarTabela(query);
        }

        public void excluir()
        {
            string query = "DELETE FROM curso "
                          + "WHERE ID_Curso=" + ID_Curso;

            Conexao.modificarTabela(query);
        }

        public DataTable recuperarCursos(string filtro)
        {
            string query;
            if (String.IsNullOrEmpty(filtro))
            {
                query = "SELECT * FROM curso";
            } else
            {
                query = "SELECT * FROM curso WHERE " + filtro;
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
            string query = "SELECT * FROM curso WHERE ID_Curso = " + ID_Curso;
            DataTable Dados = new DataTable();
            Dados = Conexao.carregarTabela(query);

            if(Dados!= null)
            {
                DataRow dr = Dados.Rows[0];
                Codigo = dr["Codigo_Curso"].ToString();
                Nome = dr["Nome_Curso"].ToString();
                Periodo = dr["Periodo_Curso"].ToString();
                Duracao = dr["Duracao_Curso"].ToString();
                Enade = dr["Enade_Curso"].ToString();
            }
        }
    }
}