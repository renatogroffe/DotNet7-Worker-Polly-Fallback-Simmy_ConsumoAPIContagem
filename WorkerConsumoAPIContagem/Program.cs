using WorkerConsumoAPIContagem;
using WorkerConsumoAPIContagem.Resilience;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton(
            FallbackContagem.CreateFallbackPolicy().WrapAsync(
                MonkeyPolicyContagem.CreateMonkeyPolicy(
                    Convert.ToBoolean(hostContext.Configuration["MonkeyPolicyEnabled"]))));
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
