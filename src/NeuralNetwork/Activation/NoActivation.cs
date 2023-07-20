namespace NeuralNetwork.Activation;
public class NoActivation : IActivationFunction
{
    public double Calculate(double value) => value;
}
