namespace NeuralNetwork.Activation;
public class TanhActivation : IActivationFunction
{
    public double Calculate(double value) => (double)Math.Tanh(value);
}
