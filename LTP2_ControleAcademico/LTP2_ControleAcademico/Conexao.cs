using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LTP2_ControleAcademico
{
    public class Conexao
    {
        private static string StringConexao = "SERVER=localhost;DATABASE=ltp2_2017;UID=aluno;PASSWORD=123456";
        private static MySqlConnection connection = new MySqlConnection(StringConexao);

        private static string abrirConexao()
        {
            try
            {
                connection.Open();
                return "Sucesso";
            } catch(MySqlException e)
            {
                return e.Message;
            }
        }

        private static string fecharConexao()
        {
            try
            {
                connection.Close();
                return "Sucesso";
            } catch(MySqlException e)
            {
                return e.Message;
            }
        }

        public static void modificarTabela(string query)
        {
            try
            {
                abrirConexao();
                MySqlCommand comando = new MySqlCommand(query , connection);
                comando.ExecuteNonQuery();
                fecharConexao();
            }
            catch(Exception e)
            {
                string erro = e.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        public static DataTable carregarTabela(string query)
        {
            try
            {
                abrirConexao();
                MySqlCommand comando = new MySqlCommand(query , connection);
                MySqlDataReader dataReader = comando.ExecuteReader();
                DataTable resultado = new DataTable();
                resultado.Load(dataReader);
                return resultado;
            }
            catch (Exception e)
            {
                string erro = e.Message;
                return null;
            }
            finally
            {
                fecharConexao();
            }
        }
    }
}