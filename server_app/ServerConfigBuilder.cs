using System;
using System.Collections.Generic;
using System.Text;

namespace server_app
{
    internal class ServerConfigBuilder : IServerBuilder
    {
        private readonly string _address;
        private readonly int _port;

        private bool _useEncryption = false;
        private int _maxConnections = 100;
        private int _timeoutSeconds = 30;
        private bool _loggingEnabled = false;

        public ServerConfigBuilder(string address, int port)
        {
            _address = address;
            _port = port;
        }

        public IServerBuilder WithEncryption()
        {
            _useEncryption = true;
            return this;
        }

        public IServerBuilder WithMaxConnections(int max)
        {
            _maxConnections = max;
            return this;
        }

        public IServerBuilder WithTimeout(int seconds)
        {
            _timeoutSeconds = seconds;
            return this;
        }

        public IServerBuilder EnableLogging()
        {
            _loggingEnabled = true;
            return this;
        }

        public ServerConfig Build()
        {
            if (_useEncryption && _port == 80)
            {
                throw new InvalidOperationException(
                    "Bezpečnostní riziko: Šifrování nelze vynutit na portu 80 (HTTP).");
            }

            return new ServerConfig(
                _address,
                _port,
                _useEncryption,
                _maxConnections,
                _timeoutSeconds,
                _loggingEnabled);
        }
    }
}
