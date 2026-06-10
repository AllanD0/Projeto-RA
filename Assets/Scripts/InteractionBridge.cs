using UnityEngine;

public class InteractionBridge : MonoBehaviour
{
    [Header("Target References")]
    [SerializeField] private Transform targetModel;
    [SerializeField] private MeshRenderer targetRenderer;

    public void SetModelScale(float scaleMultiplier)
    {
    }

    public void ToggleModelVisibility(bool isVisible)
    {
    }

    public void ResetModelTransform()
    {
    }
}