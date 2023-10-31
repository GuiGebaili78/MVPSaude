using Fiap.Web.MVPSaude.Controllers.Filters;
using Fiap.Web.MVPSaude.Models;
using Fiap.Web.MVPSaude.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Fiap.Web.MVPSaude.Controllers
{
    public class UsuarioController : Controller
    {

        private UsuarioRepository usuarioRepository;

        // O parametro enviado no construtor do Controller é gerenciado pelo próprio framework .NET
        // Esse recurso é chamada de Injeção de Dependência
        public UsuarioController(DataBaseContext dataBaseContext)
        {

            usuarioRepository = new UsuarioRepository(dataBaseContext);
        }

        [LogFilter]
        public IActionResult Index()
        {
            // Retornando para View a lista de Usuários
            var lista = usuarioRepository.Listar();

            return View(lista);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public IActionResult Cadastrar()
        {
            // Retorna para a View Cadastrar um 
            // objeto modelo com as propriedades em branco 
            return View(new UsuarioModel());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioRepository.Inserir(usuario);

                    TempData["mensagem"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    return View(usuario);
                }
            }
            catch (Exception ex)
            {
                // Exiba a mensagem de erro para o usuário
                TempData["erro"] = ex.Message;
                return View(usuario);
            }
        }




        [HttpGet]
        public IActionResult Editar([FromRoute] int id)
        {
            var usuario = usuarioRepository.Consultar(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioRepository.Alterar(usuario);

                TempData["mensagem"] = "Usuário alterado com sucesso";
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View(usuario);
            }

        }


        [HttpGet]
        public IActionResult Consultar(int id)
        {
            var usuario = usuarioRepository.Consultar(id);
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            usuarioRepository.Excluir(id);

            TempData["mensagem"] = "Usuário excluído com sucesso";
            return RedirectToAction("Index", "Usuario");
        }



    }
}