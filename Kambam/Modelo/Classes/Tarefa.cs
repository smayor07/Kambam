using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public int QuadroId { get; set; }
        public int Ordem_tarefa { get; set; }
        public string Descricao_tarefa { get; set; }

        public Projeto Projeto { get; set; }
        public virtual ICollection<MemTar> MemTar { get; set; }
    }
}
