using System.Collections.Generic;
using UnityEngine;

public class NeuralNetworkVisualizer : MonoBehaviour
{
    public GameObject neuronPrefab;
    public GameObject connectionPrefab;
    public Material activeMaterial;
    public Material inactiveMaterial;

    private List<List<GameObject>> neuronObjects = new List<List<GameObject>>();
    private NeuralNetwork neuralNetwork;

    public int[] layerSizes;

    void Start()
    {
        neuralNetwork = new NeuralNetwork(layerSizes);
        CreateNeurons();
        CreateConnections();
    }

    void CreateNeurons()
    {
        float xSpacing = 2.5f;
        float ySpacing = 1.5f;

        for (int i = 0; i < layerSizes.Length; i++)
        {
            List<GameObject> layerObjects = new List<GameObject>();
            for (int j = 0; j < layerSizes[i]; j++)
            {
                Vector3 position = new Vector3(i * xSpacing, j * ySpacing - ((layerSizes[i] - 1) * ySpacing / 2), 0);
                GameObject neuronObj = Instantiate(neuronPrefab, position, Quaternion.identity);
                layerObjects.Add(neuronObj);

                Debug.Log($"Created Neuron at {position} in Layer {i}");
            }
            neuronObjects.Add(layerObjects);
        }
    }

    void CreateConnections()
    {
        for (int i = 0; i < neuronObjects.Count - 1; i++)
        {
            for (int j = 0; j < neuronObjects[i].Count; j++)
            {
                for (int k = 0; k < neuronObjects[i + 1].Count; k++)
                {
                    GameObject connection = Instantiate(connectionPrefab);
                    LineRenderer lr = connection.GetComponent<LineRenderer>();
                    lr.SetPosition(0, neuronObjects[i][j].transform.position);
                    lr.SetPosition(1, neuronObjects[i + 1][k].transform.position);

                    Debug.Log($"Created Connection from Layer {i}, Neuron {j} to Layer {i + 1}, Neuron {k}");
                }
            }
        }
    }

    void Update()
    {
        List<float> outputs = neuralNetwork.Forward(new List<float> { 1f, 0.5f, 0.8f });
        UpdateNeuronVisuals(outputs);
    }

    void UpdateNeuronVisuals(List<float> activations)
    {
        int index = 0;
        foreach (var layer in neuronObjects)
        {
            foreach (var neuronObj in layer)
            {
                Renderer renderer = neuronObj.GetComponent<Renderer>();
                float activationValue = activations[index];
                renderer.material.color = Color.Lerp(inactiveMaterial.color, activeMaterial.color, activationValue);
                index++;
            }
        }
    }
}
