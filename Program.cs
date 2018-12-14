using System;

namespace DvejetainisMedis
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            //AddValues(tree);

            Console.WriteLine(Command.Choices());
            string input = Console.ReadLine();
            while ("e" != input)
            {
                if (Command.TryParseCommand(input, out Commands command, out int? value))
                {
                    switch (command)
                    {
                        case Commands.Add:
                            tree.Add((int) value);
                            Console.WriteLine($"Value {value} added");
                            break;
                        case Commands.Find:
                            Console.WriteLine((null != tree.Find((int) value) ? $"Value of {value} found in a tree" : $"Such value({value}) is not found"));
                            break;
                        case Commands.Print:
                            tree.Traverse();
                            break;
                        case Commands.Delete:
                            tree.Delete((int)value);
                            break;
                        default:
                            break;
                    }
                }
                else
                    Console.WriteLine("Invalid command.");

                Console.WriteLine(Command.Choices());
                input = Console.ReadLine();
            }
        }

        private static void AddValues(Tree tree)
        {
            tree.Add(8);
            tree.Add(3);
            tree.Add(11);
            tree.Add(1);
            tree.Add(6);
            tree.Add(9);
            tree.Add(14);
            tree.Add(7);
            tree.Add(10);
            tree.Add(12);
            tree.Add(15);
            tree.Add(13);
        }
    }
}
