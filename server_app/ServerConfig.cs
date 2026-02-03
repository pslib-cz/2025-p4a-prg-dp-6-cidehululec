using System;
using System.Collections.Generic;
using System.Text;

namespace server_app
{
    public class ServerConfig
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public bool UseEncryption { get; init; }
        public int MaxConnections { get; init; }
        public int TimeoutSeconds { get; init; }
        public bool LoggingEnabled { get; init; }

        private ServerConfig() { }

        public class Builder
        {
            private string _host;
            private int _port;
            private bool _useEncryption = false;
            private int _maxConnections = 100;
            private int _timeoutSeconds = 30;
            private bool _loggingEnabled = false;

            public Builder(string host, int port)
            {
                _host = host ?? throw new ArgumentNullException(nameof(host));
                _port = port;
            }

            public Builder WithEncryption()
            {
                _useEncryption = true;
                return this;
            }

            public Builder WithMaxConnections(int max)
            {
                _maxConnections = max;
                return this;
            }

            public Builder WithTimeout(int seconds)
            {
                _timeoutSeconds = seconds;
                return this;
            }

            public Builder EnableLogging()
            {
                _loggingEnabled = true;
                return this;
            }

            public ServerConfig Build()
            {
                if (_useEncryption && _port == 80)
                {
                    throw new InvalidOperationException("Šifrování není povoleno na portu 80.");
                }

                return new ServerConfig
                {
                    Host = _host,
                    Port = _port,
                    UseEncryption = _useEncryption,
                    MaxConnections = _maxConnections,
                    TimeoutSeconds = _timeoutSeconds,
                    LoggingEnabled = _loggingEnabled
                };
            }
        }
    }
}
