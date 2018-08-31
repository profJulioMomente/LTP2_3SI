using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable BuscarDados()
        {
            DataTable enderecos = new DataTable();

            string query = "SELECT end.id, end.logradouro As Logradouro, end.numero As Número, cid.nome As Cidade, est.uf As Estado " +
                "FROM endereco end INNER JOIN cidade cid ON cid.id = end.cidade INNER JOIN estado est ON end.estado = est.id";
            try
            {
                if (!C.abrirConexao())
                    throw new Exception("Erro de Abertura da conexão");

                //Cria o comando associado à conexão
                MySqlCommand comando = new MySqlCommand(query, C.connection);

                //Cria e preenche com dados uma estrutura de reader com o retorno do select do sql
                MySqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    enderecos.Load(dataReader);
                }
                else
                    throw new Exception("Não trouxe resultados.");

                //fechando a estrutura dataReader
                dataReader.Close();

                if (!C.fecharConexao())
                    throw new Exception("Fechamento da conexão");

            }
            catch (MySqlException ex)
            {
                return null;
            }

            return enderecos;



        }
    }
}