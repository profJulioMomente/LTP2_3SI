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

        public List<conectCurso> visualizarCursos()
        {
            List<conectCurso> L = new List<conectCurso>();

            string query = "SELECT * FROM curso";

            try
            {
                abrirConexao();

                //Cria o comando associado à conexão
                MySqlCommand comando = new MySqlCommand(query , connection);

                //Cria e preenche com dados uma estrutura de reader com o retorno do select do sql
                MySqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        conectCurso curso = new conectCurso();
                        curso.ID_Curso = Convert.ToInt32(dataReader["ID_Curso"].ToString());
                        curso.Codigo_Curso = dataReader["Codigo_Curso"].ToString();
                        curso.Nome_Curso = dataReader["Nome_Curso"].ToString();
                        curso.Periodo_Curso = dataReader["Periodo_Curso"].ToString();
                        curso.Duracao_Curso = dataReader["Duracao_Curso"].ToString();
                        curso.Enade_Curso = dataReader["Enade_Curso"].ToString();

                        L.Add(curso);
                    }
                }
                else
                {
                    throw new Exception("Não trouxe resultados.");
                }

                //fechando a estrutura dataReader
                dataReader.Close();

                fecharConexao();

            }
            catch (MySqlException ex)
            {
                Erro = "Erro ao buscar usuarios: " + ex.Message;
                L = null;
            }

            return L;
        }

        public conectCurso retornarItem(int id)
        {

            string query = "SELECT * FROM curso WHERE ID_CURSO = "+id;
            conectCurso C = new conectCurso();

            try
            {
                abrirConexao();

                //Cria o comando associado à conexão
                MySqlCommand comando = new MySqlCommand(query , connection);

                //Cria e preenche com dados uma estrutura de reader com o retorno do select do sql
                MySqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        C.ID_Curso = Convert.ToInt32(dataReader["ID_Curso"].ToString());
                        C.Codigo_Curso = dataReader["Codigo_Curso"].ToString();
                        C.Nome_Curso = dataReader["Nome_Curso"].ToString();
                        C.Periodo_Curso = dataReader["Periodo_Curso"].ToString();
                        C.Duracao_Curso = dataReader["Duracao_Curso"].ToString();
                        C.Enade_Curso = dataReader["Enade_Curso"].ToString();
                    }
                }
                else
                {
                    throw new Exception("Não trouxe resultados.");
                }

                //fechando a estrutura dataReader
                dataReader.Close();

                fecharConexao();

            }
            catch (MySqlException ex)
            {
                Erro = "Erro ao buscar usuarios: " + ex.Message;
                C = null;
            }

            return C;
        }

        public void alterarItem()
        {
            abrirConexao(); //Abrindo a conexão

            //String que armazena a consulta que será realizada
            string query = "UPDATE curso SET ";
            query = query + "Codigo_Curso='" + Codigo_Curso + "',"
                          + "Nome_Curso='" + Nome_Curso + "',"
                          + "Periodo_Curso='" + Periodo_Curso + "',"
                          + "Duracao_Curso='" + Duracao_Curso + "',"
                          + "Enade_Curso='" + Enade_Curso + "' " 
                          + "WHERE ID_Curso=" + ID_Curso;

            //Cria o comando associado à conexão
            MySqlCommand comando = new MySqlCommand(query , connection);

            //Executa o comando na base de dados
            comando.ExecuteNonQuery();

            fecharConexao();
        }

        public void excluirItem()
        {
            abrirConexao(); //Abrindo a conexão

            //String que armazena a consulta que será realizada
            string query = "DELETE FROM curso "
                          + "WHERE ID_Curso=" + ID_Curso;

            //Cria o comando associado à conexão
            MySqlCommand comando = new MySqlCommand(query , connection);

            //Executa o comando na base de dados
            comando.ExecuteNonQuery();

            fecharConexao();
        }

    }
}