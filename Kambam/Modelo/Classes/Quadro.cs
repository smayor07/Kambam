using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes
{
    public class Quadro
    {
        public int? QuadroId { get; set; }
        [Display(Name = "Nome do projeto")]
        public int ProjetoId { get; set; }
        [Display(Name = "Título do Quadro")]
        public string titulo_quadro { get; set; }

        public Projeto Projeto { get; set; }
        public virtual ICollection<Tarefa> Tarefa { get; set; }
    }
}
