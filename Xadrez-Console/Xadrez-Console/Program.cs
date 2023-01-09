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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origem = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTela(partida.tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destino = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidaPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch(TabuleiroExceptions ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.ImprimirPartida(partida);
            }
            catch (TabuleiroExceptions ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}