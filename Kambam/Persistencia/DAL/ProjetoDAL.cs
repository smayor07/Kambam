using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes;
using Persistencia.Contexts;
using System.Data.Entity;

namespace Persistencia.DAL
{
   public class ProjetoDAL
    {
        private EFContext Context = new EFContext();
        public IQueryable<Projeto> ObterProjetosClassificadasPorID()
        {
            return Context.Projeto.OrderBy(b => b.ProjetoId);
        }

        public IQueryable<Projeto> GetProjetos()
        {
            return Context.Projeto.OrderBy(c => c.ProjetoId);
        }

        public void CriarProjeto(Projeto projeto)
        {
            if (projeto.ProjetoId <= 0)
            {
                Context.Projeto.Add(projeto);
            }else{ Context.Entry(projeto).State = EntityState.Modified; }
            Context.SaveChanges();
        }
        public Projeto ObterProjetoPorId(int? id)
        {
            return Context.Projeto.Where(p => p.ProjetoId == id).First();
        }
        public Projeto RemoverProjeto(int? id)
        {
            Projeto projeto = ObterProjetoPorId(id);
            Context.Projeto.Remove(projeto);
            Context.SaveChanges();
            return projeto;
        }
        public void Editar(Projeto projeto)
        {
            Context.Entry(projeto).State = EntityState.Modified; //avisa ao EF que houve uma modificação nos dados
            Context.SaveChanges();
        }
        public Projeto DetalhesProjeto(int? id)
        {
            Projeto projeto = Context.Projeto.Where(p => p.ProjetoId == id).Include
                (c => c.Quadros).First();
            return projeto;
        }
    }
}
