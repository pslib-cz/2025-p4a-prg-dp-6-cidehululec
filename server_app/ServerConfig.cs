using System;
using System.Collections.Generic;
using System.Text;

namespace server_app
{
    public sealed class ServerConfig
    {
        public string Address { get; }
        public int Port { get; }
        public bool UseEncryption { get; }
        public int MaxConnections { get; }
        public int TimeoutSeconds { get; }
        public bool LoggingEnabled { get; }

        internal ServerConfig(
            string address,
            int port,
            bool useEncryption,
            int maxConnections,
            int timeoutSeconds,
            bool loggingEnabled)
        {
            Address = address;
            Port = port;
            UseEncryption = useEncryption;
            MaxConnections = maxConnections;
            TimeoutSeconds = timeoutSeconds;
            LoggingEnabled = loggingEnabled;
        }

        public override string ToString()
        {
            return $"--- Server Configuration ---\n" +
                   $"Address:  {Address}:{Port}\n" +
                   $"SSL:      {(UseEncryption ? "Enabled" : "Disabled")}\n" +
                   $"Max Conn: {MaxConnections}\n" +
                   $"Timeout:  {TimeoutSeconds}s\n" +
                   $"Logging:  {(LoggingEnabled ? "ON" : "OFF")}\n" +
                   $"---------------------------";
        }

        public static IServerBuilder Create(string address, int port)
        {
            return new ServerConfigBuilder(address, port);
        }
    }
}
