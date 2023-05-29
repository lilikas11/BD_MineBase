using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineBase_final
{
    internal class Bloco
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public float Dureza { get; set; }
        public int ID_Bioma { get; set; }
        public int ID_Personagem { get; set; }
    }
}
