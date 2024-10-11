using System.Collections.Generic;

public class NeuralNetwork
{
    public List<Layer> Layers;

    public NeuralNetwork(int[] layerSizes)
    {
        Layers = new List<Layer>();

        for (int i = 0; i < layerSizes.Length; i++)
        {
            // Only add weights if there is a next layer to connect to
            int numberOfWeights = i < layerSizes.Length - 1 ? layerSizes[i + 1] : 0;
            Layers.Add(new Layer(layerSizes[i], numberOfWeights));
        }
    }

    public List<float> Forward(List<float> inputs)
    {
        List<float> outputs = inputs;

        for (int i = 0; i < Layers.Count - 1; i++)
        {
            Layer layer = Layers[i];
            List<float> newOutputs = new List<float>();
            
            foreach (Neuron neuron in layer.Neurons)
            {
                float sum = 0;
                for (int j = 0; j < outputs.Count; j++)
                {
                    sum += outputs[j] * neuron.Weights[j];
                }
                newOutputs.Add(neuron.Activate(sum));
            }
            
            outputs = newOutputs;
        }

        return outputs;
    }
}