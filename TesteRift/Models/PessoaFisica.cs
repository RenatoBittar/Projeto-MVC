using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteRift.Models
{
    public class PessoaFisica
    {
        public int IdPessoaFisica { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
       
        

        public List<PessoaFisica> pessoas { get ; set;}


    }
}