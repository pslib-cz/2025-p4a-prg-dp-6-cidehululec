using server_app;

// Konfigurace pro Staging
var stagingConfig = new ServerConfig.Builder("staging.server.internal", 5000)
    .WithMaxConnections(200)
    .WithTimeout(60)
    .EnableLogging()
    .Build();

// Konfigurace pro Produkci
var prodConfig = new ServerConfig.Builder("api.production.com", 443)
    .WithEncryption()
    .Build();

Console.WriteLine($"Staging: Server started on {stagingConfig.Host}:{stagingConfig.Port} (SSL: {stagingConfig.UseEncryption})");
Console.WriteLine($"Produkce: Server started on {prodConfig.Host}:{prodConfig.Port} (SSL: {prodConfig.UseEncryption})");