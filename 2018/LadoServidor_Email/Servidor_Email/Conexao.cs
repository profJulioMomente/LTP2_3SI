
using MySql.Data.MySqlClient;

namespace Servidor_Email
{
    public class Conexao
    {
        //Parametros de conexão
        public MySqlConnection connection;
        private string server = "localhost"; //ip
        private string database = "2018_01"; //schema
        private string uid = "ltp2"; //usuario
        private string password = "ltp2"; //senha

        /// <summary>
        /// Construtor da classe de conexão que já faz a criação da string de conexão
        /// </summary>
        public Conexao()
        {
            string StringConexao = "SERVER=" + server + ";DATABASE=" + database
                + ";UID=" + uid + ";PASSWORD=" + password + ";SslMode=none;";

            connection = new MySqlConnection(StringConexao);
        }

        /// <summary>
        /// Método para abrir a conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public bool abrirConexao()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Método para fechar a conexão com o banco de dados
        /// </summary>
        /// <returns></returns>
        public bool fecharConexao()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}