using System.Runtime.ConstrainedExecution;
using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Xadrz
{
    public class Peao : Peca
    {
        public Peao(Table tabuleiro, Cor cor) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Position pos)
        {
            Peca p = Tabuleiro.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Position pos)
        {
            return Tabuleiro.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Position pos = new Position(0, 0);

            if (Cor == Cor.Branco)
            {
                pos.DefinirValores(Position.Linha - 1, Position.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha - 2, Position.Coluna);
                Position p2 = new Position(Position.Linha - 1, Position.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && livre(p2) && Tabuleiro.PosicaoValida(pos) && livre(pos) && MovimentosRealizados == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha - 1, Position.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha - 1, Position.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(Position.Linha + 1, Position.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha + 2, Position.Coluna);
                Position p2 = new Position(Position.Linha + 1, Position.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && livre(p2) && Tabuleiro.PosicaoValida(pos) && livre(pos) && MovimentosRealizados == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha + 1, Position.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Position.Linha + 1, Position.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            return mat;
        }
    }
}
