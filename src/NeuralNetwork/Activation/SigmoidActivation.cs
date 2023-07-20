namespace NeuralNetwork.Activation;
public class SigmoidActivation : IActivationFunction
{
    public double Calculate(double value) => (double)(1 / (1 + Math.Exp(-value)));
}
