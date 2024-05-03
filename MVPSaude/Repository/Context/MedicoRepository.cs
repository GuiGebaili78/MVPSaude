using Fiap.Web.MVPSaude.Models;

namespace Fiap.Web.MVPSaude.Repository.Context
{
    public class MedicoRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public MedicoRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }



        public IList<MedicoModel> Listar()
        {
            // Efetuando a listagem (Substituindo o Select *)
            var lista = dataBaseContext.Medico.ToList();

            return lista;
        }

        public MedicoModel? Consultar(int id)
        {
            var medico = dataBaseContext.Medico.Find(id);
            return medico;
        }


        public void Inserir(MedicoModel medico)
        {
            // Adiciona o objeto preenchido pelo usuário
            dataBaseContext.Medico.Add(medico);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }

        public void Alterar(MedicoModel medico)
        {
            dataBaseContext.Medico.Update(medico);

            // Salva as alterações
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var medico = dataBaseContext.Medico.Find(id);

            if (medico != null)
            {
                dataBaseContext.Medico.Remove(medico);
                dataBaseContext.SaveChanges();
            }
        }



    }
}