namespace NeuralNetwork.Components;

public interface ISynapse
{
    double GetOutput();
    double Weight { get; set; }
}

internal class Synapse : ISynapse
{
    private readonly Neuron _input;
    private readonly Neuron _output;
    public double Weight { get; set; } = 1;

    public Synapse(Neuron input, Neuron output)
    {
        _input = input;
        _output = output;
    }
    public double GetOutput() => _input.GetOutput();
}
