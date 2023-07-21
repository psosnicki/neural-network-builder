
# neural-network-builder 
![build](https://github.com/psosnicki/neural-network-builder/actions/workflows/dotnet.yml/badge.svg)

Simple neural network builder implementation in C#
## Usage

Register in IoC
```
builder.Services.AddNeuralNetworkBuilder();
```

Use [```INeuralNetworkBuilder```](https://github.com/psosnicki/neural-network-builder/blob/master/src/NeuralNetwork/Builder/INeuralNetworkBuilder.cs)
```
  var neuralNetwork = neuralNetworkBuilder.AddInputLayer(3)
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
```
or
```
 var neuralNetwork = NeuralNetworkBuilder.Create()
                                         .AddInputLayer(4)
                                         .AddHiddenLayer(3, ActivationFunctions.Sigmoid)
                                         .AddOutputLayer(1, ActivationFunctions.Tanh)
                                         .Build();
```
