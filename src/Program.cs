using System.IO;
using System.Text;

using static System.Console;
using static System.IO.Directory;
using static System.IO.File;

namespace RemoveUsing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Starting to remove all regions in your C# project.");
            Write("Path of solution: ");
            var path = ReadLine();
            string[] files = GetFiles(path, "*.cs", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                var file = files[i];
                var lines = ReadAllLines(file);
                var stringBuilder = new StringBuilder();
                for (int j = 0; j < lines.Length; j++)
                {
                    var line = lines[j];
                    if (line.Contains("#region") || line.Contains("#endregion"))
                        continue;
                    stringBuilder.AppendLine(line);
                }
                WriteAllText(file, stringBuilder.ToString());
                WriteLine($"DONE: {file}");
            }
            Read();
        }
    }
}
