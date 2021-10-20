using System;

namespace dhcpWatchClient
{
    class Program
    {
 
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("* Once SSH * Sweshelo");
                Console.WriteLine("Usage: once-ssh host username password command");
            }
            else
            {
                string host = args[0];
                string user = args[1];
                string pass = args[2];

                string[] commands = new string[(args.Length - 3)];
                Array.Copy(args, 3, commands, 0, (args.Length - 3));

                var sshobj = new SSHConnection(host, user, pass);
                sshobj.Commands = commands;
                Console.WriteLine(sshobj.Run());
            }
        }
    }
}