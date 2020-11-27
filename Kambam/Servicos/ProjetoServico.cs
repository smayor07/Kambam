using Modelo.Classes;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class ProjetoServico
    {
        private ProjetoDAL ProjDAL = new ProjetoDAL();
        public void CriarProjeto(Projeto proj)
        {
            ProjDAL.CriarProjeto(proj);
        }

        public Projeto ObterProjetoPorId(int? ID)
        {
            return ProjDAL.ObterProjetoPorId(ID);
        }

        public Projeto RemoverProjeto(int? ID)
        {
            return ProjDAL.RemoverProjeto(ID);
        }

        public void EditarProjeto(Projeto projeto)
        {
            ProjDAL.Editar(projeto);
        }

        public IQueryable<Projeto> GetProjetos()
        {
            return ProjDAL.GetProjetos();
        }

        public Projeto DetalhesProjeto(int? ID)
        {
            return ProjDAL.DetalhesProjeto(ID);
        }
    }
}
