using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servidor_Email
{
    public class Cidade
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public string Uf { get; set; }
        public string Nome { get; set; }

        private Conexao C = new Conexao();
        //String para erros de conexão
        public string Erro { get; set; }

        /// <summary>
        /// Método que retorna a lista de cidades do estado específico no banco de dados
        /// </summary>
        /// <returns></returns>
        public List<Cidade> BuscarCidades(int estado)
        {
            List<Cidade> LCidades = new List<Cidade>();

            string query = "SELECT c.id, c.nome, c.estado, e.uf "+
                "FROM cidade c INNER JOIN estado e ON c.estado = e.id WHERE e.id =" +
                estado;
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
                        Cidade tmp = new Cidade();
                        tmp.Id = Convert.ToInt32(dataReader["id"].ToString());
                        tmp.Estado = Convert.ToInt32(dataReader["estado"].ToString());
                        tmp.Uf = dataReader["uf"].ToString();
                        tmp.Nome = dataReader["nome"].ToString();
                        LCidades.Add(tmp);
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
                LCidades = null;
            }

            return LCidades;

        }
    }
}