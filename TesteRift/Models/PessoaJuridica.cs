using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteRift.Models
{
    public class PessoaJuridica
    {
        public int IdPessoaJuridica { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }


        public List<PessoaJuridica> pessoas { get; set; }

    }
}