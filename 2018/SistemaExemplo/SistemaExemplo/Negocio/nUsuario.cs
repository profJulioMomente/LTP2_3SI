using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaExemplo.Util;
using SistemaExemplo.Entidade;
using System.Data;

namespace SistemaExemplo.Negocio
{
    public class nUsuario : eUsuario
    {
        /// <summary>
        /// Método que adiciona um novo usuário
        /// </summary>
        /// <returns>Retorna vazio se concluído com sucesso, caso contrário, retorna o erro</returns>
        public string AdicionarUsuario()
        {
            string erro = "";
            try
            {
                Senha = Encriptacao.Encriptar(Senha);

                string query = "INSERT INTO usuario (nome,email,cpf,sexo,dataNasc,senha,status) " +
                                    "VALUES ('{Nome}','{Email}','{Cpf}','{Sexo}','{DataNasc}','{Senha}',1)";
                erro = Conexao.ModificarTabela(query);

            }
            catch (Exception exp)
            {
                erro = exp.Message;
            }

            return erro;
        }

        /// <summary>
        /// Método que altera os dados de um usuário
        /// Se a nova senha não for informada, mantém-se a senha atual
        /// </summary>
        /// <returns>>Retorna vazio se concluído com sucesso, caso contrário, retorna o erro</returns>
        public string AlterarUsuario()
        {
            string erro = "";
            try
            {
                Senha = (!String.IsNullOrEmpty(Senha)) ? Encriptacao.Encriptar(Senha) : "";

                string query = "UPDATE usuario " +
                                "SET nome= {Nome}'," +
                                    "email='{Email}'," +
                                    "cpf='{Cpf}'," +
                                    "sexo='{Sexo}'," +
                                    "dataNasc='{DataNasc}'," +
                                    "senha=IF('{Senha}'<>'','{Senha}',senha)) " +
                               "WHERE id = {Id}";
                erro = Conexao.ModificarTabela(query);
            }
            catch (Exception exp)
            {
                erro = exp.Message;
            }
            return erro;
        }

        /// <summary>
        /// Método que inativa um usuário
        /// </summary>
        /// <param name="Id">Id do usuário a ser inativado</param>
        /// <returns></returns>
        public static string InativarUsuario(int Id)
        {
            string erro = "";
            try
            {
                string query = "UPDATE usuario Set status = 0 WHERE id = '{Id}'";
                erro = Conexao.ModificarTabela(query);
            }
            catch (Exception exp)
            {
                erro = exp.Message;
            }

            return erro;
        }

        /// <summary>
        /// Método que recupera os usuários da tabela
        /// </summary>
        /// <param name="coluna">coluna do filtro</param>
        /// <param name="valor">valor a ser buscado</param>
        /// <param name="operador">operador de comparacao do filtro</param>
        /// <param name="usuarios">estrutura de retorno dos dados</param>
        /// <returns></returns>
        public static string RecuperarUsuarios(string coluna, string valor, string operador, DataTable usuarios)
        {
            string erro = "";
            try
            {
                string query = "SELECT " +
                                    "id," +
                                    "nome," +
                                    "email," +
                                    "cpf," +
                                    "sexo," +
                                    "(CASE WHEN sexo = 'M' THEN 'Masculino' ELSE 'Feminino' END) As sexoDisplay," +
                                    "dataNasc," +
                                    "DATE_FORMAT(dataNasc, '%d/%m/%Y') As dataNascDisplay " +
                                "FROM usuario "+
                                "WHERE status = 1 ";
                if (coluna != "" && valor != "" && operador!="")
                    query = query+"AND {coluna} {operador} '{valor}'";

                erro = Conexao.CarregarTabela(query, usuarios);
            } catch(Exception exp)
            {
                erro = exp.Message;
            }
            return erro;
        }
    }
}