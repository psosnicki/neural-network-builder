using NeuralNetwork.Builder;
using NeuralNetwork.Extensions.DependencyInjection;

namespace NeuralNetwork.Extension.Tests
{
    public class NeuralNetworkExtensionsTests
    {
        [Fact]
        public void Should_Register_Neural_Network_Builder_Dependency()
        {
            var servicesCollection = new ServiceCollection();
            servicesCollection.AddNeuralNetworkBuilder();
            var serviceProvider = servicesCollection.BuildServiceProvider();
            serviceProvider.GetRequiredService<INeuralNetworkBuilder>().ShouldNotBeNull();
        }
    }
}