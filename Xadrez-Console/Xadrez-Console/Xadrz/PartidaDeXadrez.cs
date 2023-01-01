
using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Xadrz
{
    public class PartidaDeXadrez
    {
        public Table tabuleiro { get; private set; }
        private int turno;
        private Cor jogador;
        public bool Terminar { get; set; }


        public PartidaDeXadrez()
        {
            tabuleiro = new Table(8, 8);
            turno = 1;
            jogador = Cor.Branco;
            ColocarPecas();
        }

        private void ColocarPecas()
        {
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PositionXadrez('c', 1).toPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PositionXadrez('c', 2).toPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PositionXadrez('d', 2).toPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PositionXadrez('e', 2).toPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Branco, tabuleiro), new PositionXadrez('e', 1).toPosicao());
            tabuleiro.ColocarPeca(new Rei(Cor.Branco, tabuleiro), new PositionXadrez('d', 1).toPosicao());

            tabuleiro.ColocarPeca(new Torre(Cor.Preto, tabuleiro), new PositionXadrez('c', 7).toPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Preto, tabuleiro), new PositionXadrez('c', 8).toPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Preto, tabuleiro), new PositionXadrez('d', 8).toPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Preto, tabuleiro), new PositionXadrez('e', 8).toPosicao());
            tabuleiro.ColocarPeca(new Torre(Cor.Preto, tabuleiro), new PositionXadrez('e', 7).toPosicao());
            tabuleiro.ColocarPeca(new Rei(Cor.Preto, tabuleiro), new PositionXadrez('d', 7).toPosicao());
        }

        public void ExecutaMovimento(Position origem, Position destino)
        {
            var p = tabuleiro.RetirarPeca(origem);
            p.incrementarQtdMovimentos();
            var pecaCapturada = tabuleiro.RetirarPeca(destino);
            tabuleiro.ColocarPeca(p, destino);
        }
    }
}
