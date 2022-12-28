namespace Xadrez_Console.Tabuleiro
{
    public class Table
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        //Matriz de Peças do tabuleiro
        private Peca[,] pecas;

        public Table(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            // Criando Matriz de dados dentro do Tabuleiro
            pecas = new Peca[Linhas, Colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
    }
}