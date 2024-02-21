namespace Conjuntos.Entities
{
    public class Professor(string name)
    {
        public string Name { get; set; } = name;
        public HashSet<Course> Courses { get; set; } = [];
    }
}