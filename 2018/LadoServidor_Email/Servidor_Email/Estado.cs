using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servidor_Email
{
    public class Estado
    {
        //Dados das colunas do BD
        public int Id { get; set; }
        public string Uf { get; set; }
        public string Nome { get; set; }

        Conexao C = new Conexao();

        //String para erros de conexão
        public string Erro { get; set; }

        public List<Estado> BuscarEstados()
        {
            List<Estado> LEstados = new List<Estado>();

            string query = "SELECT * FROM estado";
            try
            {
                if (!C.abrirConexao())
                    throw new Exception("Erro de Abertura da conexão");

                //Cria o comando associado à conexão
                MySqlCommand comando = new MySqlCommand(query , C.connection);

                //Cria e preenche com dados uma estrutura de reader com o retorno do select do sql
                MySqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Estado tmp = new Estado();
                        tmp.Id = Convert.ToInt32(dataReader["id"].ToString());
                        tmp.Uf = dataReader["uf"].ToString();
                        tmp.Nome = dataReader["nome"].ToString();
                        LEstados.Add(tmp);
                    }
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
                Erro = "Erro ao buscar usuarios: " + ex.Message;
                LEstados = null;
            }

            return LEstados;

        }
    }
}