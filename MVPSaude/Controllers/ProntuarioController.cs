using Fiap.Web.MVPSaude.Controllers.Filters;
using Fiap.Web.MVPSaude.Models;
using Fiap.Web.MVPSaude.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.MVPSaude.Controllers
{
    public class ProntuarioController : Controller
    {

        private ProntuarioRepository prontuarioRepository;
        private PacienteRepository pacienteRepository;
        private MedicoRepository medicoRepository;

        // O parametro enviado no construtor do Controller é gerenciado pelo próprio framework .NET
        // Esse recurso é chamada de Injeção de Dependência
        public ProntuarioController(DataBaseContext dataBaseContext)
        {

            prontuarioRepository = new ProntuarioRepository(dataBaseContext);
            medicoRepository = new MedicoRepository(dataBaseContext);
            pacienteRepository = new PacienteRepository(dataBaseContext);
        }

        [LogFilter]
        public IActionResult Index()
        {
            // Retornando para View a lista de Médicos
            var lista = prontuarioRepository.Listar();

            return View(lista);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Cadastrar()
        {
            // Retorna para a View Cadastrar um 
            // objeto modelo com as propriedades em branco 
            ComboPacientes();
            ComboMedicos();
             
            return View(new ProntuarioModel());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Cadastrar(ProntuarioModel prontuario
            )
        {
            if (ModelState.IsValid)
            {

                prontuarioRepository.Inserir(prontuario);

                TempData["mensagem"] = "Prontuario cadastrado com sucesso";
                return RedirectToAction("Index", "Prontuario");
            }
            else
            {
                ComboPacientes();
                ComboMedicos();
                return View(prontuario);
            }
        }


        [HttpGet]
        public IActionResult Editar([FromRoute] int id)
        {
            var prontuario = prontuarioRepository.Consultar(id);
            ComboPacientes();
            ComboMedicos();
            return View(prontuario);
        }

        [HttpPost]
        public IActionResult Editar(ProntuarioModel prontuario)
        {
            if (ModelState.IsValid)
            {
                prontuarioRepository.Alterar(prontuario);

                TempData["mensagem"] = "Prontuário alterado com sucesso";
                return RedirectToAction("Index", "Prontuario");
            }
            else
            {
                ComboPacientes();
                ComboMedicos();
                return View(prontuario);
            }

        }


        [HttpGet]
        public IActionResult Consultar(int id)
        {
            var prontuario = prontuarioRepository.Consultar(id);
            ComboPacientes();
            ComboMedicos();
            return View(prontuario);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            prontuarioRepository.Excluir(id);

            TempData["mensagem"] = "Prontuário excluído com sucesso";
            return RedirectToAction("Index", "Prontuario");
        }

        private void ComboPacientes()
        {
            var listaPacientes = pacienteRepository.Listar();
            var selectListPacientes = new SelectList(listaPacientes, "PacienteId", "NomePaciente");
            ViewBag.pacientes = selectListPacientes;
        }

        private void ComboMedicos()
        {
            var listaMedicos = medicoRepository.Listar();
            var selectListMedicos = new SelectList(listaMedicos, "MedicoId", "NomeMedico");
            ViewBag.medicos = selectListMedicos;
        }



    }
}