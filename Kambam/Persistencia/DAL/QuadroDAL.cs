using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes;
using Persistencia.Contexts;

namespace Persistencia.DAL
{
    public class QuadroDAL
    {
        private EFContext Context = new EFContext();
        public IQueryable<Quadro> ObterQuadrosClassificadasPorID()
        {
            return Context.Quadro.OrderBy(b => b.QuadroId);
        }

        public IQueryable<Quadro> GetQuadrosPorProjeto(Projeto projeto)
        {
            return Context.Quadro.Where(c => c.ProjetoId == projeto.ProjetoId).OrderBy(q => q.QuadroId);
        }

        public void CriarQuadro(Quadro quadro)
        {
            if (quadro.QuadroId == null)
            {
                Context.Quadro.Add(quadro);
            }
            else
            {
                Context.Entry(quadro).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public Quadro ObterQuadroPorId(int? id)
        {
            return Context.Quadro.Where(p => p.QuadroId == id).First();
        }

        public Quadro RemoverQuadro(int? id)
        {
            Quadro projeto = ObterQuadroPorId(id);
            Context.Quadro.Remove(projeto);
            Context.SaveChanges();
            return projeto;
        }

        public void Editar(Quadro quadro)
        {
            Context.Entry(quadro).State = EntityState.Modified; //avisa ao EF que houve uma modificação nos dados
            Context.SaveChanges();
        }


        //public Quadro DetalhesQuadro(int id)
        //{
        //    Quadro projeto = Context.Quadro.Where(p => p.QuadroId == id).Include
        //        (c => c.Quadros).First();
        //    return projeto;
        //}
    }
}
