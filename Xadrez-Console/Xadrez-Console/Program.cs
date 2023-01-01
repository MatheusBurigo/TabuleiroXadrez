using Xadrez_Console.Tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.Tabuleiro.Exceptions;
using Xadrez_Console.Xadrz;

namespace Xadrez_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                Tela.ImprimirTela(partida.tabuleiro);
            }
            catch (TabuleiroExceptions ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}