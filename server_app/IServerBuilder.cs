using System;
using System.Collections.Generic;
using System.Text;

namespace server_app
{
    public interface IServerBuilder
    {
        IServerBuilder WithEncryption();
        IServerBuilder WithMaxConnections(int max);
        IServerBuilder WithTimeout(int seconds);
        IServerBuilder EnableLogging();
        ServerConfig Build();
    }
}
