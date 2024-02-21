namespace Conjuntos.Entities
{
    public class Course(string name)
    {
        public string Name { get; set; } = name;
        public HashSet<Student> Students { get; set; } = [];
    }
}