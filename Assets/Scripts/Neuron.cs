using System.Collections.Generic;
using UnityEngine;

public class Neuron
{
    public float Activation;
    public float Bias;
    public List<float> Weights;

    public Neuron(int numberOfWeights, int param)
    {
        Weights = new List<float>();
        for (int i = 0; i < numberOfWeights; i++)
            Weights.Add(Random.Range(-1f, 1f)); // Initialize random weights
        Bias = Random.Range(-1f, 1f); // Initialize random bias
    }

    public float Activate(float input)
    {
        Activation = 1 / (1 + Mathf.Exp(-input + Bias)); // Sigmoid function
        return Activation;
    }
}
