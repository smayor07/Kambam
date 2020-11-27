using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Classes;
using Persistencia.Contexts;
using Persistencia.DAL;

namespace Servicos
{
    public class MembroServico
    {
        private MembroDAL MemDAL = new MembroDAL();
        public void CriarMembro(Membro mem)
        {
            MemDAL.CriarMembro(mem);
        }

        public IQueryable<Membro> GetMembro()
        {
            return MemDAL.GetMembro();
        }

        public Membro ObterMembroPorId(int? ID)
        {
            return MemDAL.ObterMembroPorId(ID);
        }

        public  Membro RemoverMembro(int? ID)
        {
            return MemDAL.RemoverMembro(ID);
        }

        public void EditarMembro(Membro membro)
        {
            MemDAL.Editar(membro);
        }

    }
}
