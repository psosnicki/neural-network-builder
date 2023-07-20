using NeuralNetwork.Activation;
using NeuralNetwork.Components;

namespace NeuralNetwork;

internal class NeuralNetwork : INeuralNetwork
{
    private readonly IList<Layer> _layers = new List<Layer>();
    private readonly Random _random = new(1);

    internal void ConnectLayers()
    {
        for (var i = 1; i < _layers.Count; i++)
        {
            var previousLayer = _layers[i - 1];
            var currentLayer = _layers[i];
            foreach (var neuron in currentLayer.Neurons)
            {
                foreach (var previousLayerNeuron in previousLayer.Neurons)
                    neuron.AddSynapse(new Synapse(previousLayerNeuron, neuron));
            }
        }
    }

    internal void AddInputLayer(int numberOfNeurons)
    {
        var layer = new Layer();
        for (var i = 0; i < numberOfNeurons; i++)
        {
            var inputNeuron = new Neuron(new NoActivation());
            inputNeuron.AddSynapse(new InputSynapse());
            layer.AddNeuron(inputNeuron);
        }
        _layers.Add(layer);
    }

    internal void AddLayer(int numberOfNeurons, IActivationFunction activationFunction)
    {
        var layer = new Layer();
        for (var i = 0; i < numberOfNeurons; i++)
        {
            var neuron = new Neuron(activationFunction);
            layer.AddNeuron(neuron);
        }
        _layers.Add(layer);
    }

    public double[] GetOutput(params double[] inputs)
    {
        var inputSynapses = _layers.First().Neurons.SelectMany(x => x.Inputs).ToList();
        if (inputs.Length != inputSynapses.Count)
            throw new ArgumentOutOfRangeException(nameof(inputs), $"Incorrect number of inputs. Network has {inputs.Length} inputs");
        for (var i = 0; i < inputs.Length; i++)
        {
            var inputSynapse = inputSynapses[i] as InputSynapse;
            inputSynapse?.SetInputValue(inputs[i]);
        }
        var outputLayer = _layers.Last();
        return outputLayer.Neurons.Select(x => x.GetOutput()).ToArray();
    }

    public void SetRandomWeights()
    {
        for (var i = 1; i < _layers.Count; i++)
            foreach (var synapse in _layers[i].Neurons.SelectMany(x => x.Inputs))
                synapse.Weight = _random.NextDouble();
    }

    public void SetRandomBiases()
    {
        for (var i = 1; i < _layers.Count; i++)
            foreach (var neuron in _layers[i].Neurons)
                neuron.AddBias(_random.NextDouble());
    }

    public double[][] GetWeights()
    {
        var weights = new double[_layers.Count - 1][];
        for (var i = 1; i < _layers.Count; i++)
            weights[i - 1] = _layers[i].Neurons
                                     .SelectMany(x => x.Inputs.Select(synapse => synapse.Weight))
                                     .ToArray();
        return weights;
    }
    public double[][] GetBiases()
    {
        var biases = new double[_layers.Count - 1][];
        for (var i = 1; i < _layers.Count; i++)
            biases[i - 1] = _layers[i].Neurons
                                      .Select(x => x.Bias)
                                      .ToArray();
        return biases;
    }

    public void SetWeights(double[][] weights)
    {
        for (var i = 1; i < _layers.Count; i++)
            foreach (var (synapse, index) in _layers[i].Neurons.SelectMany(x => x.Inputs).Select((x, idx) => (x, idx)))
                synapse.Weight = weights[i - 1][index];
    }

    public void SetBiases(double[][] biases)
    {
        for (var i = 1; i < _layers.Count; i++)
            foreach (var (neuron, index) in _layers[i].Neurons.Select((x, idx) => (x, idx)))
                neuron.AddBias(biases[i - 1][index]);
    }
}