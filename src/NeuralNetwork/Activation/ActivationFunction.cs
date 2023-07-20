// ReSharper disable IdentifierTypo
namespace NeuralNetwork.Activation;

public interface IActivationFunction
{
    double Calculate(double value);
}

internal static class ActivationFunction
{
    public static IActivationFunction Create(ActivationFunctions activation) =>
        activation switch
        {
            ActivationFunctions.Sigmoid => new SigmoidActivation(),
            ActivationFunctions.Tanh => new TanhActivation(),
            ActivationFunctions.NoActivation => new NoActivation(),
            _ => throw new ArgumentOutOfRangeException(
                nameof(activation),
                activation,
                $"Unsupported activation type. Implement {nameof(IActivationFunction)} interface to use custom activation function")
        };
}

public enum ActivationFunctions
{
    Sigmoid,
    Tanh,
    NoActivation
}
