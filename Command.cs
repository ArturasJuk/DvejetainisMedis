using System;
using System.Collections.Generic;
using System.Text;

namespace DvejetainisMedis
{
    enum Commands
    {
        Add,
        Find,
        Print,
        Delete,
        Invalid
    }

    class Command
    {
        public static bool TryParseCommand(string input, out Commands command, out int? value)
        {
            command = Commands.Invalid;
            input = input.ToLower();
            value = null;

            string[] cols = input.Split(' ');
            if (1 == cols.Length)
            {
                if (cols[0] == "print")
                {
                    command = Commands.Print;
                    return true;
                }
            }
            else if ((2 == cols.Length) && (int.TryParse(cols[1], out int i)))
            {
                value = i;
                if (cols[0] == "add")
                {
                    command = Commands.Add;
                    return true;
                }
                else if (cols[0] == "find")
                {
                    command = Commands.Find;
                    return true;
                }
                else if (cols[0] == "del")
                {
                    command = Commands.Delete;
                    return true;
                }
            }

            return false;
        }

        public static string Choices()
        {
            var r = "";
            r += "\nBin tree program, choose command:";
            r += "\nAdd value - adds new value";
            r += "\nFind value - searches tree for given value";
            r += "\nPrint - outputs tree values";
            r += "\nDel value - deletes given value";
            r += "\ne - exits program";
            r += "\n";
            return r;
        }
    }
}
