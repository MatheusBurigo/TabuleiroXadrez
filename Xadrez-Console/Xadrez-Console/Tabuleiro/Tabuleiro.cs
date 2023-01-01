using Xadrez_Console.Tabuleiro.Exceptions;

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

        public Peca peca(Position pos)
        {
            return pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca p, Position pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroExceptions("Já existe uma peça nessa posição!");
            }
            //Coloco minha peça na matriz de Peças
            pecas[pos.Linha, pos.Coluna] = p;
            // Informa a nova posição da peça
            p.Position = pos;
        }
        public Peca RetirarPeca(Position pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.Position = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool ExistePeca(Position pos)
        {
            // Valido se a posição é válida
            validarPosicao(pos);
            // valido se está vazio o local da peça
            return peca(pos) != null;
        }

        public bool PosicaoValida(Position pos)
        {
            // Validon a posição que está sendo adicionada a Peça
            if(pos.Linha < 0|| pos.Linha >= Linhas || pos.Coluna <  0|| pos.Coluna>=Colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Position pos)
        {
            // Lanço exceção se a posição for inválida
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroExceptions("Posição inválida!");
            }
        }
    }
}