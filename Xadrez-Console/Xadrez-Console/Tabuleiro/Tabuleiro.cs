using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_Console.Tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        //Matriz de Peças do tabuleiro
        private Peca[,] Peca;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            // Criando Matriz de dados dentro do Tabuleiro
            Peca = new Peca[Linhas, Colunas];
        }
    }
}
