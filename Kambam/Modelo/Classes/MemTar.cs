using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes
{
    public class MemTar
    {
        public int MemTarId { get; set; }
        public int TarefaId { get; set; }
        public int MembroId { get; set; }

        public Projeto Projeto { get; set; }
        public Membro Membro { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}
