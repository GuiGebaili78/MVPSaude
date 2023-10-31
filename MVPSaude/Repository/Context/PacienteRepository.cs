using Fiap.Web.MVPSaude.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.MVPSaude.Repository.Context
{
    public class PacienteRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public PacienteRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }



        public IList<PacienteModel> Listar()
        {
            var lista = new List<PacienteModel>();

            // Efetuando a listagem (Substituindo o Select *)
            lista = dataBaseContext.Paciente.ToList();

            return lista;
        }

        public PacienteModel Consultar(int id)
        {
            // Recuperando o objeto Paciente de um determinado Id
            var paciente = dataBaseContext.Paciente.Find(id);

            return paciente;
        }

        public void Inserir(PacienteModel paciente)
        {
            // Adiciona o objeto preenchido pelo usuário
            dataBaseContext.Paciente.Add(paciente);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }

        public void Alterar(PacienteModel paciente)
        {
            dataBaseContext.Paciente.Update(paciente);

            // Salva as alterações
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var paciente = new PacienteModel(id, "");

            dataBaseContext.Paciente.Remove(paciente);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }


    }
}