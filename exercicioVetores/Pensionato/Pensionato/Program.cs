namespace Pensionato
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quantos quartos serão alugados? ");
            int n = int.Parse(Console.ReadLine());

            Estudante[] estudantes = new Estudante[10];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Quarto:");
                int quarto = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                estudantes[quarto] = new Estudante(nome, email, quarto);
                Console.WriteLine();
            }

            Console.WriteLine("Quartos ocupados: ");
            for (int i = 0; i < estudantes.Length; i++)
            {
                if (estudantes[i] != null)
                {
                    Console.WriteLine(estudantes[i]);
                }
            }
        }
    }
};

