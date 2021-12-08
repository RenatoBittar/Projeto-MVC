using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteRift.Models;

namespace TesteRift.Controllers
{
    public class PessoaJuridicaController : Controller
    {
        public ActionResult List()
        {
            using (PessoaJuridicaModel pessoa = new PessoaJuridicaModel())
            {
                List<PessoaJuridica> list = pessoa.Read();
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
            PessoaJuridica pessoa = new PessoaJuridica();
            pessoa.CNPJ = form["CNPJ"];
            pessoa.RazaoSocial = form["Razaosocial"];
            pessoa.NomeFantasia = form["NomeFantasia"];
            pessoa.Endereco = form["Endereco"];
            pessoa.Telefone = form["Telefone"];
            pessoa.Email = form["Email"];

            using (PessoaJuridicaModel model = new PessoaJuridicaModel())
            {
                model.Create(pessoa);
                return RedirectToAction("List");
            }
        }

        [HttpGet]
        public ActionResult Pesquisa()
        {
            PessoaJuridica pessoaJuridica = new PessoaJuridica();
            pessoaJuridica.pessoas = new List<PessoaJuridica>();
            return View(pessoaJuridica);
        }

        [HttpPost]
        public ActionResult Pesquisa(FormCollection form)
        {
            PessoaJuridica pessoa = new PessoaJuridica();
            pessoa.CNPJ = form["CNPJ"];
            pessoa.RazaoSocial = form["Razaosocial"];
            pessoa.NomeFantasia = form["NomeFantasia"];
            pessoa.Endereco = form["Endereco"];
            pessoa.Telefone = form["Telefone"];
            pessoa.Email = form["Email"];

            using (PessoaJuridicaModel model = new PessoaJuridicaModel())
            {
                PessoaJuridica pessoaJuridica = new PessoaJuridica();
                pessoaJuridica.pessoas = model.Get(pessoa);

                return View(pessoaJuridica);
            }
        }
    }
}