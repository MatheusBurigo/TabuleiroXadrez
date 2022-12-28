using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console
{
    public class Tela
    {
        public static void ImprimirTela(Table tabuleiro)
        {
            //Percorrer a Matriz de Linhas e colunas
            for (int i =0; i < tabuleiro.Linhas; i++)
            {
                for (int j =0; j < tabuleiro.Colunas; j++)
                {
                    // Validação se não tiver nenhuma peça no tabuleiro
                    if (tabuleiro.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tabuleiro.peca(i,j) + " ");
                    }
                }
                // Representa o final da linha e quebra para uma nova coluna
                Console.WriteLine();
            }
        }
    }
}
