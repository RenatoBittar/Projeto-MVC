using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteRift.Models;

namespace TesteRift.Controllers
{
    public class PessoaFisicaController : Controller
    {
        //Get:Lista de pessoas
        public ActionResult List()
        {
            using (PessoaFisicaModel pessoa = new PessoaFisicaModel())
            {
                List<PessoaFisica> list = pessoa.Read();
                return View(list);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            PessoaFisica pessoa = new PessoaFisica();
            pessoa.Nome = form["Nome"];
            pessoa.CPF = form["CPF"];
            pessoa.RG = form["RG"];
            pessoa.Endereco = form["Endereco"];
            pessoa.Telefone = form["Telefone"];
            pessoa.Email = form["Email"];

            using (PessoaFisicaModel model = new PessoaFisicaModel())
            {
                model.Create(pessoa);
                return RedirectToAction("List");
            }
            
        }
        [HttpGet]
        
        public ActionResult Pesquisa()
        {
            PessoaFisica pessoaFisica = new PessoaFisica();
            pessoaFisica.pessoas = new List<PessoaFisica>();
            return View(pessoaFisica);
        }
        [HttpPost]
        public ActionResult Pesquisa(FormCollection form)
        {
            PessoaFisica pessoa = new PessoaFisica();
            pessoa.Nome = form["Nome"];
            pessoa.CPF = form["CPF"];
            pessoa.RG = form["RG"];
            pessoa.Endereco = form["Endereco"];
            pessoa.Telefone = form["Telefone"];
            pessoa.Email = form["Email"];

            using (PessoaFisicaModel model = new PessoaFisicaModel())
            {
                PessoaFisica pessoaFisica = new PessoaFisica();
                pessoaFisica.pessoas = model.Get(pessoa);
                
                return View(pessoaFisica);
            }
        }

    }
}