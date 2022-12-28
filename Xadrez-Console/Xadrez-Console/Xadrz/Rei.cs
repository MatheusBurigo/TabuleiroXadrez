using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Xadrz
{
    public class Rei : Peca
    {
        public Rei(Cor cor, Table tabuleiro) : base(cor, tabuleiro)
        {  
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
