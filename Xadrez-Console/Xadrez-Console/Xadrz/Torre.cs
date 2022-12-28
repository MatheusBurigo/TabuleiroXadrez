using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Xadrz
{
    public class Torre : Peca
    {
        public Torre(Cor cor, Table tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
