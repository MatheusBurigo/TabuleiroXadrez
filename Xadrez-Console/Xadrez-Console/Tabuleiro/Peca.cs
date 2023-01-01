using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Tabuleiro
{
    public class Peca
    {
        public Position Position { get; set; }
        public Cor Cor{ get; protected set; }
        public int MovimentosRealizados { get; protected set; }
        public Table Tabuleiro{ get; protected set; }

        public Peca(Cor cor, Table tabuleiro)
        {
            Position = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            MovimentosRealizados= 0;
        }

        public void incrementarQtdMovimentos()
        {
            MovimentosRealizados++;
        }
    }
}
