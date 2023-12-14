namespace Pensionato;

public class Estudante
{
    private string Nome { get; set; }
    private string Email { get; set; }
    private int Quarto { get; set; }

    public Estudante(string nome, string email, int quarto)
    {
        Nome = nome;
        Email = email;
        Quarto = quarto;
    }

    public override string ToString()
    {
        return $"{Quarto}: {Nome}, {Email}";
    }
}