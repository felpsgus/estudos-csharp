namespace Conjuntos.Entities
{
    public class Student(string id)
    {
        private string Id { get; } = id;

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student other))
            {
                return false;
            }
            return Id.Equals(other.Id);
        }
    }
}