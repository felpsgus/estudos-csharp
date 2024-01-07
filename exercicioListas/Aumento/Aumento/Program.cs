namespace Aumento
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quantos funcionarios vão ser registrados? ");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine();

            List<Funcionario> funcionarios = new List<Funcionario>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Funcionario #{i + 1}:");

                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Salario: ");
                double salario = double.Parse(Console.ReadLine());

                funcionarios.Add(new Funcionario(id, nome, salario));
                Console.WriteLine();
            }

            Console.Write("Entre com o id do funcionario que terá aumento: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            Console.Write("Entre com a porcentagem: ");
            double porcentagem = double.Parse(Console.ReadLine());

            Console.WriteLine();

            Funcionario funcionario = funcionarios.Find(x => x.Id == idFuncionario);
            funcionario.AumentarSalario(porcentagem);

            Console.WriteLine("Lista atualizada de funcionarios:");
            foreach (Funcionario obj in funcionarios)
            {
                Console.WriteLine(obj);
            }
        }
    }
};

