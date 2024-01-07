namespace Matriz;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Quantas linhas tera a matriz? ");
        int l = int.Parse(Console.ReadLine());

        Console.Write("Quantas colunas tera a matriz? ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine();
        int[,] mat = new int[l, c];

        for (int i = 0; i < l; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            for (int j = 0; j < c; j++)
            {
                mat[i, j] = int.Parse(line[j]);
            }
        }
        Console.WriteLine();

        Console.Write("Digite um valor presente na matriz: ");
        int x = int.Parse(Console.ReadLine());

        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (mat[i, j] == x)
                {
                    Console.WriteLine("Posição: " + i + ", " + j);
                    if (j > 0)
                    {
                        Console.WriteLine("Esquerda: " + mat[i, j - 1]);
                    }
                    if (i > 0)
                    {
                        Console.WriteLine("Acima: " + mat[i - 1, j]);
                    }
                    if (j < c - 1)
                    {
                        Console.WriteLine("Direita: " + mat[i, j + 1]);
                    }
                    if (i < l - 1)
                    {
                        Console.WriteLine("Abaixo: " + mat[i + 1, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

