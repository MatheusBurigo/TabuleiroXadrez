
using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console.Xadrz
{
    public class PositionXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PositionXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Position toPosicao()
        {
            return new Position(8 - Linha, Coluna = 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
