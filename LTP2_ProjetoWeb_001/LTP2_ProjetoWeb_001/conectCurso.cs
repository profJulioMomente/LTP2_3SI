using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTP2_ProjetoWeb_001
{
    public class conectCurso
    {
        //Propriedade de dados do Curso
        public int ID_Curso { get; set; }
        public string Codigo_Curso { get; set; }
        public string Nome_Curso { get; set; }
        public string Periodo_Curso { get; set; }
        public string Duracao_Curso { get; set; }
        public string Enade_Curso { get; set; }

        public MySqlConnection connection;
        public string Erro;

        public conectCurso()
        {

        }

        public void configurarConexao()
        {
            string StringConexao = "SERVER=localhost;" +
                                   "DATABASE=ltp2_2017;" +
                                   "UID=aluno;" +
                                   "PASSWORD=123456";

            connection = new MySqlConnection(StringConexao);
        }

        public void abrirConexao()
        {
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Erro = e.Message;
            }
        }

        public void fecharConexao()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                Erro = e.Message;
            }
        }

        public void InserirCurso()
        {
            abrirConexao(); //Abrindo a conexão

            //String que armazena a consulta que será realizada
            string query = "INSERT INTO curso (Codigo_Curso, Nome_Curso, Periodo_Curso, Duracao_Curso, Enade_Curso) VALUES(";
            query = query + "'" + Codigo_Curso + "',"
                          + "'" + Nome_Curso + "',"
                          + "'" + Periodo_Curso + "',"
                          + "'" + Duracao_Curso + "',"
                          + "'" + Enade_Curso + "')";

            //Cria o comando associado à conexão
            MySqlCommand comando = new MySqlCommand(query , connection);

            //Executa o comando na base de dados
            comando.ExecuteNonQuery();

            fecharConexao();
        }


    }
}