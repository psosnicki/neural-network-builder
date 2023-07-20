using NeuralNetwork.Activation;

namespace NeuralNetwork.Builder;

public interface INeuralNetworkBuilder : IAddInputs { }
public interface IAddInputs
{
    IAddLayer AddInputLayer(int numberOfNeurons);
}

public interface IAddLayer
{
    IAddLayer AddHiddenLayer(int numberOfNeurons, IActivationFunction activationFunction);
    IAddLayer AddHiddenLayer(int numberOfNeurons, ActivationFunctions activation = ActivationFunctions.NoActivation);
    IBuildNetwork AddOutputLayer(int numberOfNeurons, IActivationFunction activationFunction);
    IBuildNetwork AddOutputLayer(int numberOfNeurons, ActivationFunctions activation = ActivationFunctions.NoActivation);
}

public interface IBuildNetwork
{
    INeuralNetwork Build();
}
