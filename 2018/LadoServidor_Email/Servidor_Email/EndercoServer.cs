using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servidor_Email
{
    public class EndercoServer
    {
        public int id { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        private Conexao C = new Conexao();

        public bool Inserir()
        {
            if (C.abrirConexao())
            {
                //String que armazena a consulta que será realizada
                string query = "INSERT INTO endereco (logradouro, numero,"+
                    "cidade, estado) VALUES(";
                query = query + "'" + logradouro + "',"
                              + "'" + numero + "',"
                              + "'" + cidade + "',"
                              + "'" + estado + "'); ";
                
                //Cria o comando associado à conexão
                MySqlCommand comando = new MySqlCommand(query , C.connection);

                //Executa o comando na base de dados
                comando.ExecuteNonQuery();

                if (!C.fecharConexao()) //Fechando a conexão
                    return false;

                return true;
            }
            else
            {
                return false;

            }
        }
    }
}