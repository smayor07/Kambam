using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistencia.DAL;
using Modelo.Classes;

namespace Servicos
{
   public class QuadroServico
    {
        private QuadroDAL QuadroDAL = new QuadroDAL();
        public void CriarQuadro(Quadro quadro)
        {
            QuadroDAL.CriarQuadro(quadro);
        }

        public Quadro ObterQuadroPorId(int? ID)
        {
            return QuadroDAL.ObterQuadroPorId(ID);
        }

        public Quadro RemoverQuadro(int? ID)
        {
            return QuadroDAL.RemoverQuadro(ID);
        }

        public void EditarQuadro(Quadro quadro)
        {
            QuadroDAL.Editar(quadro);
        }

        public IQueryable<Quadro> GetQuadrosPorProjeto(Projeto projeto)
        {
            return QuadroDAL.GetQuadrosPorProjeto(projeto);
        }

        //public Quadro DetalhesQuadro(int ID)
        //{
        //    return QuadroDAL.DetalhesQuadro(ID);
        //}
    }
}
