using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text activationText;

    public void UpdateActivationText(float activation)
    {
        activationText.text = $"Activation: {activation:F2}";
    }
}
