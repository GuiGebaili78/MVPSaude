using Fiap.Web.MVPSaude.Controllers.Filters;
using Fiap.Web.MVPSaude.Models;
using Fiap.Web.MVPSaude.Repository.Context;
using Microsoft.AspNetCore.Mvc;



namespace Fiap.Web.MVPSaude.Controllers
{
    public class PacienteController : Controller
    {

        private PacienteRepository pacienteRepository;

        // O parametro enviado no construtor do Controller é gerenciado pelo próprio framework .NET
        // Esse recurso é chamada de Injeção de Dependência
        public PacienteController(DataBaseContext dataBaseContext)
        {

            pacienteRepository = new PacienteRepository(dataBaseContext);
        }

        [LogFilter]
        public IActionResult Index()
        {
            // Retornando para View a lista de Pacientes
            var lista = pacienteRepository.Listar();

            return View(lista);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Cadastrar()
        {
            // Retorna para a View Cadastrar um 
            // objeto modelo com as propriedades em branco 
            return View(new PacienteModel());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Cadastrar(PacienteModel paciente)
        {
            if (ModelState.IsValid)
            {

                pacienteRepository.Inserir(paciente);

                TempData["mensagem"] = "Paciente cadastrado com sucesso";
                return RedirectToAction("Index", "Paciente");
            }
            else
            {
                return View(paciente);
            }
        }


        [HttpGet]
        public IActionResult Editar([FromRoute] int id)
        {
            var paciente = pacienteRepository.Consultar(id);
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Editar(PacienteModel paciente)
        {
            if (ModelState.IsValid)
            {
                pacienteRepository.Alterar(paciente);

                TempData["mensagem"] = "Paciente alterado com sucesso";
                return RedirectToAction("Index", "Paciente");
            }
            else
            {
                return View(paciente);
            }

        }


        [HttpGet]
        public IActionResult Consultar(int id)
        {
            var paciente = pacienteRepository.Consultar(id);
            return View(paciente);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            pacienteRepository.Excluir(id);

            TempData["mensagem"] = "Paciente excluído com sucesso";
            return RedirectToAction("Index", "Paciente");
        }



    }
}