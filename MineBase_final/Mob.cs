using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineBase_final
{
    internal class Mob
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Personalidade { get; set; }
        public int ID_Bioma { get; set; }
        public int Dano_Facil { get; set; }
        public int Dano_Normal { get; set; }
        public int Dano_Dificil { get; set; }
        public int ID_TipoItem { get; set; }
        public int MortoPor_ID_Personagem { get; set; }
    }
}
