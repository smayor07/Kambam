using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Quadro> Quadros { get; set; }
    }
}
