using System;
using System.Collections.Generic;

namespace AWS.NetUtils
{
    public class CommandLineArguments
    {
        Dictionary<string, string> _args = new Dictionary<string, string>();

        public CommandLineArguments(string[] args)
        {
            foreach (var arg in args)
            {
                // params are expected as: --{name}=["|']{value}["|']
                string[] tokens = arg.Split('=');
                if (tokens.Length != 2)
                {
                    continue;
                }
                string name = tokens[0];
                string value = tokens[1];
                if (!name.StartsWith("--"))
                {
                    continue;
                }
                name = name.Replace("--", string.Empty);
                value = value.Trim(new char[] { '\'', '\"' });
                _args.Add(name, value);
            }
        }
        public string this[string param]
        {
            get
            {
                return (_args[param]);
            }
        }
    }
}
