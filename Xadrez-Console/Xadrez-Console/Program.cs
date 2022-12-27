using Xadrez_Console.Tabuleiro;

namespace Xadrez_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Position position;

            position = new Position(3, 4);

            Console.WriteLine("Posição " + position);

            Console.ReadLine();
        }
    }
}