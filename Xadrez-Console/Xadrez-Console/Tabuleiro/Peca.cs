using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.Tabuleiro
{
    abstract public class Peca
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

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Position pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();

    }
}
