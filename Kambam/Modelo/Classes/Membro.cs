using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Classes
{
    public class Membro
    {
        public int MembroId { get; set; }
          [Display(Name = "Nome do membro")]
        public string Nome_membro { get; set; }
        [Display(Name = "Cor do membro")]
        public string Cor_membro { get; set; }

        public Projeto Projeto { get; set; }
        public virtual ICollection<MemTar> MemTar { get; set; }
    }
}
