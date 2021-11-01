using System;
using Renci.SshNet;

namespace once_ssh
{
    public class SSHConnection
    {
        private string Host { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        public string Command { get; set; }

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
                client.ConnectionInfo.Timeout = new TimeSpan(0, 0, 5);
                client.Connect();
                if (!client.IsConnected) throw new System.Security.Authentication.AuthenticationException();
                str = client.CreateCommand(Command).Execute();
                client.Disconnect();
            }

            return str;
        }
    }

}