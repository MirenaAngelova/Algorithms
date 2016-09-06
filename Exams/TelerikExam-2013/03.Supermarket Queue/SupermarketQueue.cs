using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _03.Supermarket_Queue
{
    public class SupermarketQueue
    {
        private const string AppendCommand = "Append";
        private const string InsertCommand = "Insert";
        private const string FindCommand = "Find";
        private const string ServeCommand = "Serve";
        private const string EndCommand = "End";

        private static BigList<string> people = new BigList<string>();
        private static Dictionary<string, int> names = new Dictionary<string, int>();
        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            ProcessInput();
        }

        private static void ProcessInput()
        {
            string commands = Console.ReadLine();
            while (commands != EndCommand)
            {
                string[] commandsParameters = commands.Split();
                string command = commandsParameters[0];

                ExecuteCommand(command, commandsParameters);

                commands = Console.ReadLine();
            }

            Console.WriteLine(output.ToString());
        }

        private static void ExecuteCommand(string command, string[] commandsParameters)
        {
            switch (command)
            {
                case AppendCommand:
                    string name = commandsParameters[1];
                    ExecuteAppendCommand(name);
                    break;

                case InsertCommand:
                    int position = int.Parse(commandsParameters[1]);
                    name = commandsParameters[2];
                    ExecuteInsertCommand(position, name);
                    break;

                case FindCommand:
                    name = commandsParameters[1];
                    ExecuteFindCommand(name);
                    break;

                case ServeCommand:
                    int count = int.Parse(commandsParameters[1]);
                    ExecuteServeCommand(count);
                    break;
                default:
                    throw new InvalidOperationException("Invalid command!");
            }
        }

        private static void ExecuteServeCommand(int count)
        {
            if (count > people.Count)
            {
                output.AppendLine("Error");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    string name = people[i];
                    output.Append(name + " ");
                    names[name]--;
                    if (names[name] < 0)
                    {
                        names[name] = 0;
                    }
                }
                
                people.RemoveRange(0, count);
                output.AppendLine();
            }
        }

        private static void ExecuteFindCommand(string name)
        {
            if (!names.ContainsKey(name))
            {
                output.AppendLine(0.ToString());// "0"
            }
            else
            {
                output.AppendLine(names[name].ToString());
            }
        }

        private static void ExecuteInsertCommand(int position, string name)
        {
            if (position < 0 || position > people.Count)
            {
                output.AppendLine("Error");
            }
            else
            {
                people.Insert(position, name);
                if (!names.ContainsKey(name))
                {
                    names.Add(name, 0);
                }

                names[name]++;
                output.AppendLine("OK");
            }
        }

        private static void ExecuteAppendCommand(string name)
        {
                people.Add(name);

                if (!names.ContainsKey(name))
                {
                    names.Add(name, 0);
                }

                names[name]++;
                output.AppendLine("OK");
        }
    }
}
