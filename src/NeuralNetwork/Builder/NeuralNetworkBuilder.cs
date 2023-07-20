using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NeuralNetwork.Activation;

namespace NeuralNetwork.Builder;

public class NeuralNetworkBuilder : INeuralNetworkBuilder, IAddLayer, IBuildNetwork
{
    public static INeuralNetworkBuilder Create(ILogger<NeuralNetworkBuilder>? logger = null) => new NeuralNetworkBuilder(logger);
    private readonly NeuralNetwork _neuralNetwork;
    private readonly ILogger<NeuralNetworkBuilder> _logger;

    internal NeuralNetworkBuilder(ILogger<NeuralNetworkBuilder>? logger = null)
    {
        _neuralNetwork = new NeuralNetwork();
        _logger = logger ?? NullLogger<NeuralNetworkBuilder>.Instance;
    }

    public IAddLayer AddInputLayer(int numberOfNeurons)
    {
        _neuralNetwork.AddInputLayer(numberOfNeurons);
        _logger.LogInformation("Created input layer ({numberOfNeurons})", numberOfNeurons);
        return this;
    }

    public IAddLayer AddHiddenLayer(int numberOfNeurons, IActivationFunction activationFunction)
    {
        _neuralNetwork.AddLayer(numberOfNeurons, activationFunction);
        _logger.LogInformation("Created hidden layer ({numberOfNeurons}) {activation}", numberOfNeurons, activationFunction.GetType().Name );
        return this;
    }

    public IAddLayer AddHiddenLayer(int numberOfNeurons, ActivationFunctions activation)
    {
        _neuralNetwork.AddLayer(numberOfNeurons, ActivationFunction.Create(activation));
        _logger.LogInformation("Created hidden layer ({numberOfNeurons}) {activation}", numberOfNeurons, Enum.GetName(typeof(ActivationFunctions), activation));
        return this;
    }

    public IBuildNetwork AddOutputLayer(int numberOfNeurons, ActivationFunctions activation)
    {
        _neuralNetwork.AddLayer(numberOfNeurons, ActivationFunction.Create(activation));
        _logger.LogInformation("Created output layer ({numberOfNeurons}) {activation}", numberOfNeurons, Enum.GetName(typeof(ActivationFunctions), activation));
        return this;
    }

    public IBuildNetwork AddOutputLayer(int numberOfNeurons, IActivationFunction activationFunction)
    {
        _neuralNetwork.AddLayer(numberOfNeurons, activationFunction);
        _logger.LogInformation("Created output layer ({numberOfNeurons}) {activation}", numberOfNeurons, activationFunction.GetType().Name);
        return this;
    }

    public INeuralNetwork Build()
    {
        _neuralNetwork.ConnectLayers();
        _logger.LogInformation("Connected network layers");
        return _neuralNetwork;
    }
}
