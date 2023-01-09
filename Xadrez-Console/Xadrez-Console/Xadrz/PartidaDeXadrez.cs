using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Text.RegularExpressions;
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
        public bool Xeque { get; private set; }


        public PartidaDeXadrez()
        {
            tabuleiro = new Table(8, 8);
            turno = 1;
            jogador = Cor.Branco;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        private Cor Adversario(Cor cor)
        {
            if (cor == Cor.Branco)
            {
                return Cor.Preto;
            }
            else
            {
                return Cor.Branco;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca r = rei(cor);
            if (r == null)
            {
                throw new TabuleiroExceptions("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in PecasEmJogo(Adversario(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[r.Position.Linha, r.Position.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool XequeMate(Cor cor)
        {
            if (EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < tabuleiro.Colunas; j++)
                    {
                        if (mat[i,j])
                        {
                            Position origem = x.Position;
                            Position destino = new Position(i, j);
                            Peca pecaCapturada = ExecutaMovimento(x.Position, new Position(i, j));
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
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
            ColocarNovaPeca('a', 1, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('b', 1, new Cavalo(tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 1, new Bispo(tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 1, new Dama(tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 1, new Rei(Cor.Branco, tabuleiro, this));
            ColocarNovaPeca('f', 1, new Bispo(tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 1, new Cavalo(tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 1, new Torre(Cor.Branco, tabuleiro));
            ColocarNovaPeca('a', 2, new Peao(tabuleiro, Cor.Branco));
            ColocarNovaPeca('b', 2, new Peao(tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 2, new Peao(tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 2, new Peao(tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 2, new Peao(tabuleiro, Cor.Branco));
            ColocarNovaPeca('f', 2, new Peao(tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 2, new Peao(tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 2, new Peao(tabuleiro, Cor.Branco));
            
            ColocarNovaPeca('a', 8, new Torre(Cor.Preto, tabuleiro));
            ColocarNovaPeca('b', 8, new Cavalo(tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 8, new Bispo(tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 8, new Dama(tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 8, new Rei(Cor.Preto, tabuleiro, this));
            ColocarNovaPeca('f', 8, new Bispo(tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 8, new Cavalo(tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 8, new Torre(Cor.Preto, tabuleiro));
            ColocarNovaPeca('a', 7, new Peao(tabuleiro, Cor.Preto));
            ColocarNovaPeca('b', 7, new Peao(tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 7, new Peao(tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 7, new Peao(tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 7, new Peao(tabuleiro, Cor.Preto));
            ColocarNovaPeca('f', 7, new Peao(tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 7, new Peao(tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 7, new Peao(tabuleiro, Cor.Preto));
        }

        public void RealizaJogada(Position origem, Position destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(jogador))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroExceptions("Você não pode se por em Xeque");
            }
            if (EstaEmXeque(Adversario(jogador)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (XequeMate(Adversario(jogador)))
            {
                Terminar = true;
            }

            turno++;
            MudaJogador();
        }

        public void DesfazMovimento(Position origem, Position destino, Peca pecaCapturada)
        {
            Peca p = tabuleiro.RetirarPeca(destino);
            p.decrementarQtdMovimentos();
            if (PecasCapturadas != null)
            {
                tabuleiro.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            tabuleiro.ColocarPeca(p, origem);
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

        public Peca ExecutaMovimento(Position origem, Position destino)
        {
            var p = tabuleiro.RetirarPeca(origem);
            p.incrementarQtdMovimentos();
            var pecaCapturada = tabuleiro.RetirarPeca(destino);
            tabuleiro.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }

            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Position origemT = new Position(origem.Linha, origem.Coluna + 3);
                Position destinoT = new Position(origem.Linha, origem.Coluna + 1);
                Peca T = tabuleiro.RetirarPeca(origemT);
                T.incrementarQtdMovimentos();
                tabuleiro.ColocarPeca(T, destinoT);
            }

            // #jogadaespecial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Position origemT = new Position(origem.Linha, origem.Coluna - 4);
                Position destinoT = new Position(origem.Linha, origem.Coluna - 1);
                Peca T = tabuleiro.RetirarPeca(origemT);
                T.incrementarQtdMovimentos();
                tabuleiro.ColocarPeca(T, destinoT);
            }

            return pecaCapturada;
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
