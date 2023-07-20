namespace NeuralNetwork;

public interface INeuralNetwork
{
    double[] GetOutput(params double[] inputs);
    void SetRandomWeights();
    void SetRandomBiases();
    double[][] GetWeights();
    double[][] GetBiases();
    void SetBiases(double[][] biases);
    void SetWeights(double[][] weights);
}
