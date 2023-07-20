using NeuralNetwork.Activation;

namespace NeuralNetwork.Components;

internal class Neuron
{
    public IReadOnlyCollection<ISynapse> Inputs => _synapseInputs.AsReadOnly();
    public double Bias { get; private set; }

    private readonly IActivationFunction _activationFunction;
    private readonly List<ISynapse> _synapseInputs = new();

    public Neuron(IActivationFunction activationFunction)
    {
        _activationFunction = activationFunction;
    }

    public double GetOutput() => _activationFunction.Calculate(_synapseInputs.Sum(synapse => synapse.GetOutput() * synapse.Weight) + Bias);

    public void AddSynapse(ISynapse synapse)
    {
        _synapseInputs.Add(synapse);
    }

    public void AddBias(double bias)
    {
        Bias = bias;
    }
}
