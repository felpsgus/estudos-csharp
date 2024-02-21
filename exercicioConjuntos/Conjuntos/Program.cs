using Conjuntos.Entities;

namespace Conjuntos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many professors will be registered?");
            int n = int.Parse(Console.ReadLine());

            HashSet<Professor> professors = new HashSet<Professor>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the professor's name:");
                string name = Console.ReadLine();
                professors.Add(new Professor(name));

                Console.WriteLine("How many courses will be registered for this professor?");
                int m = int.Parse(Console.ReadLine());
                for (int j = 0; j < m; j++)
                {
                    Console.WriteLine("Enter the course name:");
                    string courseName = Console.ReadLine();
                    professors.Last().Courses.Add(new Course(courseName));

                    Console.WriteLine("How many students will be registered for this course?");
                    int p = int.Parse(Console.ReadLine());
                    for (int k = 0; k < p; k++)
                    {
                        Console.WriteLine("Enter the student's id:");
                        string id = Console.ReadLine();
                        professors.Last().Courses.Last().Students.Add(new Student(id));
                    }
                }
            }

            HashSet<Student> users = [];

            foreach (Professor professor in professors)
            {
                foreach (Course course in professor.Courses)
                {
                    users.UnionWith(course.Students);
                }
            }

            Console.WriteLine("Total students: " + users.Count);

        }
    }
}