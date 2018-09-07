using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaExemplo.Entidade
{
    public class eUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string DataNasc { get; set; }
        public string Sexo { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
    }
}