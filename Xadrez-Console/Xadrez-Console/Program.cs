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

                while (!partida.Terminar)
                {
                    Console.Clear();
                    Tela.ImprimirTela(partida.tabuleiro);

                    Console.Write("Origem: ");
                    Position origem = Tela.LerPosicaoXadrez().toPosicao();

                    bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTela(partida.tabuleiro, posicoesPossiveis);

                    Console.WriteLine();

                    Console.Write("Destino: ");
                    Position destino = Tela.LerPosicaoXadrez().toPosicao();

                    partida.ExecutaMovimento(origem, destino);                

                }
            }
            catch (TabuleiroExceptions ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}