using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes;
using Persistencia.Contexts;

namespace Persistencia.DAL
{
    class TarefaDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Tarefa> ObterTarefasClassificadasPorID()
        {
            return context.Tarefa.OrderBy(b => b.TarefaId);
        }
    }
}
