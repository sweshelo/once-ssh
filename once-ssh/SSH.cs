using System;
using Renci.SshNet;

namespace dhcpWatchClient
{
    public class SSHConnection
    {
        private string Host { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        public string[] Commands { get; set; }

        public SSHConnection(string host, string username, string password)
        {
            Host = host;
            UserName = username;
            Password = password;
        }

        public string Run()
        {
            string str = "";

            using (var client = new SshClient(Host, UserName, Password))
            {
                client.Connect();
                if (!client.IsConnected) throw new System.Security.Authentication.AuthenticationException();
                Array.ForEach(Commands, x => str += client.CreateCommand(x).Execute());
                client.Disconnect();
            }

            return str;
        }
    }

}