﻿using Fiap.Web.MVPSaude.Models;

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
            var lista = new List<MedicoModel>();

            // Efetuando a listagem (Substituindo o Select *)
            lista = dataBaseContext.Medico.ToList();

            return lista;
        }

        public MedicoModel Consultar(int id)
        {
            // Recuperando o objeto Médico de um determinado Id
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
            var medico = new MedicoModel(id, "");

            dataBaseContext.Medico.Remove(medico);

            // Salva as alterações
            dataBaseContext.SaveChanges();

        }


    }
}