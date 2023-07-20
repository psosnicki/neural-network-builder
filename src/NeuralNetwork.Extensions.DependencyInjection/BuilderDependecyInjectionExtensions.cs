using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NeuralNetwork.Builder;

namespace NeuralNetwork.Extensions.DependencyInjection
{
    public static class NeuralNetworokBuilderExtensions
    {
        public static IServiceCollection AddNeuralNetworkBuilder(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddTransient<INeuralNetworkBuilder, NeuralNetworkBuilder>(implementationFactory: (sp) =>
                (NeuralNetworkBuilder)NeuralNetworkBuilder.Create(sp.GetService<ILogger<NeuralNetworkBuilder>>()
            ));
            return servicesCollection;
        }
    }
}