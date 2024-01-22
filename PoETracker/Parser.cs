namespace Parser
{

    public class TxtParser
    {
        public void readDoc()
        {

            Console.WriteLine(
                "Hello, please enter the absolute path to your Client.txt file: \n");
            string? path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"No Client.txt file found at {path}");
            }
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            using (StreamReader sr = File.OpenText(path!))
            {
                string? s;
                while ((s = sr.ReadLine()) != null)
                {
                    s.Split(' ');

                    // TODO: if the resulting string matches current date, then check if
                    // there's fun information read the BLUEPRINT.md for tips on fun
                    // information to gather.
                }
            }
        }
    }
}
