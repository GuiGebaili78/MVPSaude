using Fiap.Web.MVPSaude.Controllers.Filters;
using Fiap.Web.MVPSaude.Models;
using Fiap.Web.MVPSaude.Repository.Context;
using Microsoft.AspNetCore.Mvc;



namespace Fiap.Web.MVPSaude.Controllers
{
    public class MedicoController : Controller
    {

        private MedicoRepository medicoRepository;

        // O parametro enviado no construtor do Controller é gerenciado pelo próprio framework .NET
        // Esse recurso é chamada de Injeção de Dependência
        public MedicoController(DataBaseContext dataBaseContext)
        {

            medicoRepository = new MedicoRepository(dataBaseContext);
        }

        [LogFilter]
        public IActionResult Index()
        {
            // Retornando para View a lista de Médicos
            var lista = medicoRepository.Listar();

            return View(lista);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Cadastrar()
        {
            // Retorna para a View Cadastrar um 
            // objeto modelo com as propriedades em branco 
            return View(new MedicoModel());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Cadastrar(MedicoModel medico)
        {
            if (ModelState.IsValid)
            {

                medicoRepository.Inserir(medico);

                TempData["mensagem"] = "Médico cadastrado com sucesso";
                return RedirectToAction("Index", "Medico");
            }
            else
            {
                return View(medico);
            }
        }


        [HttpGet]
        public IActionResult Editar([FromRoute] int id)
        {
            var medico = medicoRepository.Consultar(id);
            return View(medico);
        }

        [HttpPost]
        public IActionResult Editar(MedicoModel medico)
        {
            if (ModelState.IsValid)
            {
                medicoRepository.Alterar(medico);

                TempData["mensagem"] = "Médico alterado com sucesso";
                return RedirectToAction("Index", "Medico");
            }
            else
            {
                return View(medico);
            }

        }


        [HttpGet]
        public IActionResult Consultar(int id)
        {
            var medico = medicoRepository.Consultar(id);
            return View(medico);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            medicoRepository.Excluir(id);

            TempData["mensagem"] = "Médico excluído com sucesso";
            return RedirectToAction("Index", "Medico");
        }



    }
}