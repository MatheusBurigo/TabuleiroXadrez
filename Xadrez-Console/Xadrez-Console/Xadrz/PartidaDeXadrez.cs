using System.Collections.Generic;
using System.Reflection;
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
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;


        public PartidaDeXadrez()
        {
            tabuleiro = new Table(8, 8);
            turno = 1;
            jogador = Cor.Branco;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.ColocarPeca(peca, new PositionXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            //Retira as peças selecionadas do conjunto
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branco, tabuleiro));

            ColocarNovaPeca('c', 7, new Torre(Cor.Preto, tabuleiro));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preto, tabuleiro));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preto, tabuleiro));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preto, tabuleiro));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preto, tabuleiro));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preto, tabuleiro));
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
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
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
