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
   public class MembroDAL
    {
        private EFContext Context = new EFContext();

        public IQueryable<Membro> ObterMembrosClassificadasPorNome()
        {
            return Context.Membro.OrderBy(b => b.Nome_membro);
        }

        public IQueryable<Membro> GetMembro()
        {
            return Context.Membro.OrderBy(c => c.MembroId);
        }

        public void CriarMembro(Membro membro)
        {
            if (membro.MembroId <= 0)
            {
                Context.Membro.Add(membro);
            } else {
                Context.Entry(membro).State = EntityState.Modified;
                   }
                Context.SaveChanges();
        }

        public Membro ObterMembroPorId(int? id)
        {
            return Context.Membro.Where(p => p.MembroId == id).First();
        }

        public Membro RemoverMembro(int? id)
        {
            Membro membro = ObterMembroPorId(id);
            Context.Membro.Remove(membro);
            Context.SaveChanges();
            return membro;
        }

        public void Editar(Membro membro)
        {
            Context.Entry(membro).State = EntityState.Modified; //avisa ao EF que houve uma modificação nos dados
            Context.SaveChanges();
        }
    }
}
