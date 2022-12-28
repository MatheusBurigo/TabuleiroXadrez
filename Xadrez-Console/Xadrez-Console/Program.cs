using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tabuleiro = new Table(8, 8);

            Tela.ImprimirTela(tabuleiro);
            Console.ReadLine();
        }
    }
}