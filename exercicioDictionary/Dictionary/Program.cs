namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the path of the file: ");
            string path = Console.ReadLine() ?? throw new InvalidOperationException();

            Dictionary<string, int> votes = new Dictionary<string, int>();

            try
            {
                using StreamReader sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine()?.Split(',');
                    string name = line[0];
                    int count = int.Parse(line[1]);

                    if (votes.ContainsKey(name))
                    {
                        votes[name] += count;
                    }
                    else
                    {
                        votes[name] = count;
                    }
                }

                foreach (var vote in votes)
                {
                    Console.WriteLine(vote.Key + ": " + vote.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}