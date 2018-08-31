using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SistemaExemplo.Util
{
    public static class Conexao
    {
        private static readonly string stringConexao = "SERVER=localhost;DATABASE=2018_01;UID=ltp2;PASSWORD=ltp2;";
        private static readonly MySqlConnection connection = new MySqlConnection(stringConexao);

        /// <summary>
        /// Método privado para abrir a conexão com o banco de dados
        /// </summary>
        /// <returns>retona a mensagem de erro caso não consiga abrir a conexão, retorna vazio caso contrário</returns>
        private static string AbrirConexao()
        {
            string retorno = "";
            try
            {
                connection.Open();
            }
            catch (Exception exp)
            {
                retorno = exp.Message;
            }
            return retorno;
        }

        /// <summary>
        /// Método privado para fechar a conexão com o banco de dados
        /// </summary>
        /// <returns>retona a mensagem de erro caso não consiga fechar a conexão, retorna vazio caso contrário</returns>
        private static string FecharConexao()
        {
            string retorno = "";
            try
            {
                connection.Close();
            }
            catch (Exception exp)
            {
                retorno = exp.Message;
            }
            return retorno;
        }

        /// <summary>
        /// Método que modifica uma tabela do banco de dados.
        /// Pode ser usada para inserir, alterar e excluir registros
        /// </summary>
        /// <param name="query">consulta sq a ser executada no banco de dados</param>
        /// <returns>vazio se sucesso, mensagem de erro caso contrário</returns>
        public static string ModificarTabela(string query)
        {
            string retorno = "";
            try
            {
                AbrirConexao();
                MySqlCommand comando = new MySqlCommand(query, connection);
                comando.ExecuteNonQuery();
                FecharConexao();
            }
            catch (Exception exp)
            {
                retorno = exp.Message;
            }
            return retorno;
        }

        /// <summary>
        /// Método que recupera dados de uma tabela
        /// Pode ser usada para a visualização e pesquisa de dados
        /// </summary>
        /// <param name="query">consulta select a ser enviada ao banco de dados</param>
        /// <param name="dados">DataTable que armazenará os dados que forem carregados do banco de dados (saída)</param>
        /// <returns>Retorna vazio se sucesso, mensagem de erro, caso contrário.</returns>
        public static string CarregarTabela(string query, DataTable dados)
        {
            string retorno = "";
            try
            {
                AbrirConexao();
                MySqlCommand comando = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = comando.ExecuteReader();
                dados.Load(dataReader);
                FecharConexao();
            }
            catch (Exception exp)
            {
                retorno = exp.Message;
            }
            return retorno;
        }
    }

}