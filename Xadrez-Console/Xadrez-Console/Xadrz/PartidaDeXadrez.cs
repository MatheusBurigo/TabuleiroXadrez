
using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.Tabuleiro.Exceptions;

namespace Xadrez_Console.Xadrz
{
    public class PartidaDeXadrez
    {
        public Table tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogador { get; private set; }
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

        public void RealizaJogada(Position origem, Position destino)
        {
            ExecutaMovimento(origem, destino);
            turno++;
            MudaJogador();
        }
        private void MudaJogador()
        {
            if (jogador == Cor.Branco)
            {
                jogador = Cor.Preto;
            }
            else
            {
                jogador = Cor.Branco;
            }
        }

        public void ExecutaMovimento(Position origem, Position destino)
        {
            var p = tabuleiro.RetirarPeca(origem);
            p.incrementarQtdMovimentos();
            var pecaCapturada = tabuleiro.RetirarPeca(destino);
            tabuleiro.ColocarPeca(p, destino);
        }

        public void ValidaPosicaoDestino(Position origem, Position destino)
        {
            if (!tabuleiro.peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroExceptions("Posição de destino não é válida");
            }
        }

        public void ValidarPosicaoOrigem(Position pos)
        {
            if (tabuleiro.peca(pos) == null)
            {
                throw new TabuleiroExceptions("Não existe peça na posição escolhida!");
            }
            if (jogador != tabuleiro.peca(pos).Cor)
            {
                throw new TabuleiroExceptions("A peça de origem escolhida não é sua!");
            }
            if (!tabuleiro.peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroExceptions("Não há movimentos possíveis para esta peça!");
            }
        }
    }
}
