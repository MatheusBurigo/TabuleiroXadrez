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
                var tabuleiro = new Table(8, 8);
                tabuleiro.ColocarPeca(new Torre(Cor.Preto, tabuleiro), new Position(0, 0));
                tabuleiro.ColocarPeca(new Torre(Cor.Preto, tabuleiro), new Position(1, 3));
                tabuleiro.ColocarPeca(new Rei(Cor.Preto, tabuleiro), new Position(2, 4));

                Tela.ImprimirTela(tabuleiro);
                Console.ReadLine();
            }
            catch (TabuleiroExceptions ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}