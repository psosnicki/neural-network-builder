namespace NeuralNetwork.Components;

internal class InputSynapse : ISynapse
{
    private double _inputValue;
    public double Weight { get; set; } = 1;

    public void SetInputValue(double value)
    {
        _inputValue = value;
    }
    public double GetOutput() => _inputValue;
}
