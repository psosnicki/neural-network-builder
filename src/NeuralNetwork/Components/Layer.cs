namespace NeuralNetwork.Components;

internal class Layer
{
    public IReadOnlyCollection<Neuron> Neurons => _neurons.AsReadOnly();

    private readonly List<Neuron> _neurons = new();

    public void AddNeuron(Neuron neuron)
    {
        _neurons.Add(neuron);
    }
}
