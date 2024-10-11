using System.Collections.Generic;

public class Layer
{
    public List<Neuron> Neurons;

    public Layer(int numberOfNeurons, int numberOfWeights)
    {
        this.Neurons = new List<Neuron>();
        for (int i = 0; i < numberOfNeurons; i++)
            this.Neurons.Add(new Neuron(numberOfWeights, 0)); // Adjust the parameters to match a specific constructor
    }
}
