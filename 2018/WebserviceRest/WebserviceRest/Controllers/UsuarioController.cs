using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebserviceRest.Models;

namespace WebserviceRest.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private static List<Usuario> listaUsuarios = new List<Usuario>();

        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(Usuario usuario)
        {
            listaUsuarios.Add(usuario);
            return "Usuário cadastrado com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string AlterarUsuario(Usuario usuario)
        {
            listaUsuarios.Where(n => n.codigo == usuario.codigo)
                         .Select(s =>
                         {
                             s.codigo = usuario.codigo;
                             s.login = usuario.login;
                             s.nome = usuario.nome;

                             return s;

                         }).ToList();

            return "Usuário alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {
            Usuario usuario = listaUsuarios.Where(n => n.codigo == codigo)
                                                .Select(n => n)
                                                .First();

            listaUsuarios.Remove(usuario);

            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCodigo/{codigo}")]
        public Usuario ConsultarUsuarioPorCodigo(int codigo)
        {
            Usuario usuario = listaUsuarios
                .Where(n => n.codigo == codigo)
                .Select(n => n)
                .FirstOrDefault();

            return usuario;
        }

        
        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorNome/{nome}")]
        public List<Usuario> ConsultarUsuarioPorNome(string nome)
        {
            List<Usuario> usuarios = listaUsuarios
                .Where(n => n.nome.Contains(nome))
                .Select(n => n)
                .ToList();
            return usuarios;
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]
        public List<Usuario> ConsultarUsuarios()
        {
            return listaUsuarios;
        }
    }
}
