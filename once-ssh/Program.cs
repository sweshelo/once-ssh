using System;
using CommandLine;

namespace once_ssh
{
    class Program
    {
        public class Options
        {
            [Option('h', "host", Required = true, HelpText = "SSH server address / hostname")]
            public string Host { get; set; }
            [Option('u', "user", Required = true, HelpText = "SSH username")]
            public string User { get; set; }
            [Option('p', "password", Required = true, HelpText = "SSH password")]
            public string Pass { get; set; }
            //[Option('i', "identify", Required = false, HelpText = "SSH identify key location")]
            //public string Identify { get; set; }
            [Option('c', "command", Required = true, HelpText = "Commands to run in the SSH server.")]
            public string Command { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       var sshobj = new SSHConnection(o.Host, o.User, o.Pass);
                       sshobj.Command = o.Command;
                       Console.WriteLine(sshobj.Run());
                   });

        }
    }
}