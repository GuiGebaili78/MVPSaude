using Microsoft.AspNetCore.Mvc;
using Fiap.Web.MVPSaude.Models; // Suponha que o namespace para sua entidade Usuario seja Fiap.Web.MVPSaude.Models
using System.Linq;
using Fiap.Web.MVPSaude.Repository.Context;

namespace Fiap.Web.MVPSaude.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataBaseContext _context; // Substitua SeuDbContext pelo nome do seu contexto do Entity Framework

        public LoginController(DataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            // Verifica se o usuário e senha correspondem a um registro válido no banco de dados
            var usuario = _context.Usuario.FirstOrDefault(u => u.NomeUsuario == username && u.SenhaUsuario == password);


            if (usuario != null)
            {
                // Autenticação bem-sucedida, redireciona para a página inicial do aplicativo
                // Aqui você pode adicionar lógica para armazenar informações de autenticação na sessão
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Autenticação falhou, exibe uma mensagem de erro na view
                ViewBag.ErrorMessage = "Usuário ou senha inválidos";
                return View();
            }
        }
    }
}
