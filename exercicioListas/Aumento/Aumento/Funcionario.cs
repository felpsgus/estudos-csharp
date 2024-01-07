namespace Aumento;

public class Funcionario
{
    public int Id { get; }
    private string Nome { get; set; }
    private double Salario { get; set; }

    public Funcionario(int id, string nome, double salario)
    {
        Id = id;
        Nome = nome;
        Salario = salario;
    }

    public void AumentarSalario(double porcentagem)
    {
        Salario += Salario * porcentagem / 100.0;
    }

    public override string ToString()
    {
        return $"{Id}, {Nome}, {Salario.ToString("C")}";
    }
}