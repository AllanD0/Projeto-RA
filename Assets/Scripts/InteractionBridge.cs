using UnityEngine;

public class InteractionBridge : MonoBehaviour
{
    [Header("Target References")]
    [SerializeField] private Transform targetModel;
    [SerializeField] private MeshRenderer targetRenderer;

    [Header("Test Controls (Editor Only)")]
    [Range(0.1f, 5f)] public float testScale = 1f;
    [Range(0f, 360f)] public float testRotationY = 0f;
    public Color testColor = Color.white;

    private void OnValidate()
    {
        if (targetModel == null || targetRenderer == null) return;

        SetModelScale(testScale);
        SetModelRotationY(testRotationY);
        SetModelColor(testColor);
    }

    public void SetModelScale(float scaleMultiplier)
    {
        float safeScale = Mathf.Clamp(scaleMultiplier, 0.1f, 5.0f);
        if (targetModel != null)
        {
            targetModel.localScale = Vector3.one * safeScale;
        }
    }

    public void SetModelRotationY(float angle)
    {
        if (targetModel != null)
        {
            Vector3 currentRotation = targetModel.localEulerAngles;
            targetModel.localRotation = Quaternion.Euler(currentRotation.x, angle, currentRotation.z);
        }
    }

    public void SetModelColor(Color newColor)
    {
        if (targetRenderer == null) return;

        if (Application.isPlaying)
        {
            targetRenderer.material.SetColor("_BaseColor", newColor);
        }
        else if (targetRenderer.sharedMaterial != null)
        {
            targetRenderer.sharedMaterial.SetColor("_BaseColor", newColor);
        }
    }

    public void ToggleModelVisibility(bool isVisible)
    {
        if (targetRenderer != null)
        {
            targetRenderer.enabled = isVisible;
        }
    }

    [ContextMenu("Test: Reset Transform")]
    public void ResetModelTransform()
    {
        if (targetModel != null)
        {
            targetModel.localPosition = Vector3.zero;
            targetModel.localRotation = Quaternion.identity;
            targetModel.localScale = Vector3.one;

            testScale = 1f;
            testRotationY = 0f;
            testColor = Color.white;
            SetModelColor(Color.white);
        }
    }
}