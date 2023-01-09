using System.Runtime.ConstrainedExecution;
using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Xadrz
{
    public class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Cor cor, Table tabuleiro, PartidaDeXadrez partida) : base(cor, tabuleiro)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Position pos)
        {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool TesteTorreParaRoque(Position pos)
        {
            Peca p = Tabuleiro.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && MovimentosRealizados == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Position pos = new Position(0, 0);

            // acima
            pos.DefinirValores(Position.Linha - 1, Position.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // ne
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // direita
            pos.DefinirValores(Position.Linha, Position.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // se
            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // abaixo
            pos.DefinirValores(Position.Linha + 1, Position.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // so
            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // esquerda
            pos.DefinirValores(Position.Linha, Position.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            // no
            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Jogada Especial Roque
            if (MovimentosRealizados == 0 && !partida.Xeque)
            {
                Position postT1 = new Position(Position.Linha, Position.Coluna + 3);
                if (TesteTorreParaRoque(postT1))
                {
                    Position p1 = new Position(Position.Linha, Position.Coluna);
                    Position p2 = new Position(Position.Linha, Position.Coluna);
                    if (Tabuleiro.peca(p1) == null && Tabuleiro.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[Position.Linha, Position.Coluna - 2] = true;
                    }
                }
            }

            // Joga especial Roque Grande
            Position posT2 = new Position(Position.Linha, Position.Linha - 4);
            if (TesteTorreParaRoque(posT2))
            {
                Position p1 = new Position(Position.Linha, Position.Linha - 1);
                Position p2 = new Position(Position.Linha, Position.Linha - 2);
                Position p3 = new Position(Position.Linha, Position.Linha - 3);
                if (Tabuleiro.peca(p1) == null && Tabuleiro.peca(p2) == null && Tabuleiro.peca(p3) == null)
                {
                    mat[Position.Linha, Position.Coluna - 2] = true;
                }
            }

            return mat;
        }
    }
}