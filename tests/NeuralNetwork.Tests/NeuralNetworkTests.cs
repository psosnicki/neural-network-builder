using NeuralNetwork.Activation;
using NeuralNetwork.Builder;

namespace NeuralNetwork.Tests;

public class NeuralNetworkTests
{
    [Fact]
    public void Should_Calculate_Output_Sigmoid_Activation()
    {
        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(4)
            .AddHiddenLayer(3, ActivationFunctions.Sigmoid)
            .AddOutputLayer(1, ActivationFunctions.Sigmoid)
            .Build();

        neuralNetwork.SetWeights(new[]
        {
                new[]{3,1,5,-4,-1.5,-3,7.1,5.2,2,1,-6,2.9},
                new double[]{-2,5,1}
            });

        neuralNetwork.SetBiases(new[]
        {
                new double[]{-2,-2,-2},
                new[]{0.6}
            });

        var output = neuralNetwork.GetOutput(0.5, 2.8, 0, -0.1);
        Math.Round(output.First(), 4).ShouldBe(0.3882);
    }

    [Fact]
    public void Should_Calculate_Output_Different_Layer_Activations()
    {
        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(3)
            .AddHiddenLayer(4, ActivationFunctions.Tanh)
            .AddOutputLayer(2, ActivationFunctions.Sigmoid)
            .Build();

        neuralNetwork.SetWeights(new[]
        {
                new[]{0.01,0.05,0.09,0.02,0.06,0.10,0.03,0.07,0.11,0.04,0.08,0.12},
                new[]{0.17,0.19,0.19,0.21,0.23,0.18,0.20,0.22,0.24}
            });

        neuralNetwork.SetBiases(new[]
        {
                new[]{0.13,0.14,0.15,0.16},
                new[]{0.25,0.26}
            });

        var output = neuralNetwork.GetOutput(1, 2, 3);
        output.Length.ShouldBe(2);
        Math.Round(output[0], 2).ShouldBe(0.66);
        Math.Round(output[1], 2).ShouldBe(0.67);
    }

    [Fact]
    public void Should_Calculate_Output_No_Activation()
    {
        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(3)
            .AddHiddenLayer(2)
            .AddOutputLayer(2)
            .Build();

        var output = neuralNetwork.GetOutput(1f, 2f, 3f);
        output.ShouldBe(new double[] { 12, 12 });
    }

    [Fact]
    public void Should_Get_Synapses_Weights()
    {
        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(3)
            .AddHiddenLayer(2, ActivationFunctions.Sigmoid)
            .AddOutputLayer(2, ActivationFunctions.Sigmoid)
            .Build();

        neuralNetwork.GetWeights().ShouldBe(new[]
        {
                new double[]{1,1,1,1,1,1},
                new double[]{1,1,1,1}
            });
    }

    [Fact]
    public void Should_Set_Synapses_Weights()
    {
        var weights = new[]
        {
                new double[] { 1, 2, 3, 4, 5, 6 },
                new double[] { 7, 8, 9, 10 }
            };

        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(3)
            .AddHiddenLayer(2, ActivationFunctions.Sigmoid)
            .AddOutputLayer(2, ActivationFunctions.Sigmoid)
            .Build();

        neuralNetwork.SetWeights(weights);
        neuralNetwork.GetWeights().ShouldBe(weights);
    }

    [Fact]
    public void Should_Set_Biases()
    {
        var biases = new[]
        {
            new double[] { 1, 2 },
            new double[] { 3, 4 }
        };

        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(3)
            .AddHiddenLayer(2, ActivationFunctions.Sigmoid)
            .AddOutputLayer(2, ActivationFunctions.Sigmoid)
            .Build();

        neuralNetwork.SetBiases(biases);
        neuralNetwork.GetBiases().ShouldBe(biases);
    }

    [Fact]
    public void Should_Get_Initial_Biases()
    {

        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(3)
            .AddHiddenLayer(2, ActivationFunctions.Sigmoid)
            .AddOutputLayer(2, ActivationFunctions.Sigmoid)
            .Build();

        neuralNetwork.GetBiases().ShouldBe(new[] {
                new double[] { 0, 0 },
                new double[] { 0, 0 }
            });
    }

    [Fact]
    public void Should_Throw_OutOfRange_Exception_When_Weights_Input_Is_Not_Correct()
    {
        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(3)
            .AddHiddenLayer(2, ActivationFunctions.Sigmoid)
            .AddOutputLayer(2, ActivationFunctions.Sigmoid)
            .Build();

        Should.Throw<IndexOutOfRangeException>(() =>
        {
            neuralNetwork.SetWeights(new[]
            {
                    new double[] { 1, 2, 3, 4 },
                    new double[] { 1, 2, 3, 4 }
                });
            }
        );
    }

    [Fact]
    public void Should_Throw_OutOfRange_Exception_When_Biases_Input_Is_Not_Correct()
    {
        var neuralNetwork = NeuralNetworkBuilder.Create()
            .AddInputLayer(3)
            .AddHiddenLayer(2, ActivationFunctions.Sigmoid)
            .AddOutputLayer(2, ActivationFunctions.Sigmoid)
            .Build();

        Should.Throw<IndexOutOfRangeException>(() =>
            {
                neuralNetwork.SetBiases(new[]
                {
                        new double[] { 1, 2, 3}
                });
            }
        );
    }
}

