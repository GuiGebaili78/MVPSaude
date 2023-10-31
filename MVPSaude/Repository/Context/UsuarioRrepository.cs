using Fiap.Web.MVPSaude.Models;
using Oracle.ManagedDataAccess.Client;

namespace Fiap.Web.MVPSaude.Repository.Context
{
    public class UsuarioRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public UsuarioRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }



        public IList<UsuarioModel> Listar()
        {
            var lista = new List<UsuarioModel>();

            // Efetuando a listagem (Substituindo o Select *)
            lista = dataBaseContext.Usuario.ToList();

            return lista;
        }

        public UsuarioModel Consultar(int id)
        {
            // Recuperando o objeto Usuario de um determinado Id
            var usuario = dataBaseContext.Usuario.Find(id);

            return usuario;
        }

        public void Inserir(UsuarioModel usuario)
        {
            try
            {
                // Adiciona o objeto preenchido pelo usuário
                dataBaseContext.Usuario.Add(usuario);

                // Salva as alterações
                dataBaseContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("A senha não atende aos critérios.");
            }

        }

        public void Alterar(UsuarioModel usuario)
        {
            dataBaseContext.Usuario.Update(usuario);

            // Salva as alterações
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var usuario = new UsuarioModel { UsuarioId = id };

            dataBaseContext.Usuario.Remove(usuario);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }



    }
}