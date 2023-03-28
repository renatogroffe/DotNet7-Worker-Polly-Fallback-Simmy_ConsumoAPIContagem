using Polly.Contrib.Simmy;
using Polly.Contrib.Simmy.Outcomes;

namespace WorkerConsumoAPIContagem.Resilience;

public static class MonkeyPolicyContagem
{
    public static AsyncInjectOutcomePolicy CreateMonkeyPolicy(bool enabled)
    {
        // Criação da Chaos Policy com uma probabilidade
        // de 30% de erro
        return MonkeyPolicy.InjectExceptionAsync(
            with => with.Fault(new Exception("Erro gerado em simulação de caos com Simmy..."))
                .InjectionRate(0.30).Enabled(enabled));
    }
}