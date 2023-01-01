using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.Xadrz;

namespace Xadrez_Console
{
    public class Tela
    {
        public static void ImprimirTela(Table tabuleiro)
        {
            //Percorrer a Matriz de Linhas e colunas
            for (int i =0; i < tabuleiro.Linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    // Validação se não tiver nenhuma peça no tabuleiro
                    if (tabuleiro.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(tabuleiro.peca(i, j));
                        Console.Write(" ");
                    }
                }
                // Representa o final da linha e quebra para uma nova coluna
                Console.WriteLine();
            }
            Console.WriteLine(" a b c d e f g h");
        }
        public static PositionXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PositionXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.Branco)
            {
                Console.Write(peca);
            }
            else
            {
                //Alterando cor da Peça no Console
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
