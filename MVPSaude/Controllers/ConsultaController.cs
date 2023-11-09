using Fiap.Web.MVPSaude.Controllers.Filters;
using Fiap.Web.MVPSaude.Models;
using Fiap.Web.MVPSaude.Repository.Context;
using Microsoft.AspNetCore.Mvc;



namespace Fiap.Web.MVPSaude.Controllers
{
    public class ConsultaController : Controller
    {

        private ConsultaRepository consultaRepository;

        // O parametro enviado no construtor do Controller é gerenciado pelo próprio framework .NET
        // Esse recurso é chamada de Injeção de Dependência
        public ConsultaController(DataBaseContext dataBaseContext)
        {

            consultaRepository = new ConsultaRepository(dataBaseContext);
        }

        [LogFilter]
        public IActionResult Index()
        {
            // Retornando para View a lista de Consulta
            var lista = consultaRepository.Listar();

            return View(lista);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Cadastrar()
        {
            // Retorna para a View Cadastrar um 
            // objeto modelo com as propriedades em branco 
            return View(new ConsultaModel());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Cadastrar(ConsultaModel consulta)
        {
            if (ModelState.IsValid)
            {

                consultaRepository.Inserir(consulta);

                TempData["mensagem"] = "Consulta cadastrada com sucesso";
                return RedirectToAction("Index", "Consulta");
            }
            else
            {
                return View(consulta);
            }
        }


        [HttpGet]
        public IActionResult Editar([FromRoute] int id)
        {
            var consulta = consultaRepository.Consultar(id);
            return View(consulta);
        }

        [HttpPost]
        public IActionResult Editar(ConsultaModel consulta)
        {
            if (ModelState.IsValid)
            {
                consultaRepository.Alterar(consulta);

                TempData["mensagem"] = "Consulta alterada com sucesso";
                return RedirectToAction("Index", "Consulta");
            }
            else
            {
                return View(consulta);
            }

        }


        [HttpGet]
        public IActionResult Consultar(int id)
        {
            var consulta = consultaRepository.Consultar(id);
            return View(consulta);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            consultaRepository.Excluir(id);

            TempData["mensagem"] = "Consulta excluída com sucesso";
            return RedirectToAction("Index", "Consulta");
        }



    }
}