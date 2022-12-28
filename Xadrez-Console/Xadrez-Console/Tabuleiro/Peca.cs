using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Tabuleiro
{
    public class Peca
    {
        public Position Position { get; set; }
        public Cor Cor{ get; protected set; }
        public int MovimentosRealizados { get; protected set; }
        public Tabuleiro Tabuleiro{ get; protected set; }

        public Peca(Position position, Cor cor, Tabuleiro tabuleiro)
        {
            Position = position;
            Cor = cor;
            Tabuleiro = tabuleiro;
            MovimentosRealizados= 0;
        }
    }
}
