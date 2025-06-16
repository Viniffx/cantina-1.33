using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantina_1._3
{
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public bool ItemCozinha { get; set; } // <<-- Precisa ser 'bool'

        //public string Descricao => $"{Nome} - R$ {Preco:F2}";
        //public string DescricaoCarrinho => $"{Quantidade}x {Nome} - R$ {Preco * Quantidade:F2}";

        public override string ToString()
        {
            if (Quantidade > 0)
            {
                return $"{Quantidade}x {Nome} - R$ {Preco * Quantidade:F2}";
            }
            else
            {
                return $"{Nome} - R$ {Preco:F2}";
            }
        }
    }
}
