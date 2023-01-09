using System.Runtime.ConstrainedExecution;
using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Xadrz
{
    public class Cavalo : Peca
    {
        public Cavalo(Table tabuleiro, Cor cor) : base(cor, tabuleiro)
        { 
        }

        public override string ToString()
        {
            return "C";
        }

        private bool podeMover(Position pos)
        {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Position pos = new Position(0, 0);

            pos.DefinirValores(Position.Linha - 1, Position.Coluna - 2);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha - 2, Position.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha - 2, Position.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha - 1, Position.Coluna + 2);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha + 1, Position.Coluna + 2);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position .Linha + 2, Position.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position .Linha + 2, Position.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Position.Linha + 1, Position.Coluna - 2);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
