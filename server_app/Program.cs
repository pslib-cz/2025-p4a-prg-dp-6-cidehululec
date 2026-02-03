using server_app;

// Konfigurace pro produkci
ServerConfig productionConfig = ServerConfig.Create("api.produkce.cz", 443)
                .WithEncryption()
                .WithMaxConnections(1000)
                .WithTimeout(10)
                .EnableLogging()
                .Build();

// Konfigurace pro lokální vývoj
ServerConfig localConfig = ServerConfig.Create("localhost", 8080)
    .Build();

Console.WriteLine("Konfigurace pro produkci:");
Console.WriteLine(productionConfig);

Console.WriteLine("");

Console.WriteLine("Konfigurace pro lokální vývoj:");
Console.WriteLine(localConfig);