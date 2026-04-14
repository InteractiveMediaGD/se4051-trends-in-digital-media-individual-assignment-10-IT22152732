using UnityEngine;
using TMPro;

public class HighContrastMode : MonoBehaviour
{
    public Renderer groundRenderer;
    public Renderer wallBackRenderer;
    public Renderer wallFrontRenderer;
    public Renderer wallLeftRenderer;
    public Renderer wallRightRenderer;

    public TextMeshProUGUI statusText;

    private bool highContrastEnabled = false;

    private Color normalGroundColor = new Color(0.8f, 0.8f, 0.8f);
    private Color normalWallColor = new Color(0.7f, 0.85f, 1f);

    private Color highContrastGroundColor = Color.black;
    private Color highContrastWallColor = Color.yellow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleHighContrast();
        }
    }

    void ToggleHighContrast()
    {
        highContrastEnabled = !highContrastEnabled;

        if (highContrastEnabled)
        {
            if (groundRenderer != null)
                groundRenderer.material.color = highContrastGroundColor;

            if (wallBackRenderer != null)
                wallBackRenderer.material.color = highContrastWallColor;

            if (wallFrontRenderer != null)
                wallFrontRenderer.material.color = highContrastWallColor;

            if (wallLeftRenderer != null)
                wallLeftRenderer.material.color = highContrastWallColor;

            if (wallRightRenderer != null)
                wallRightRenderer.material.color = highContrastWallColor;

            if (statusText != null)
                statusText.text = "High Contrast Mode Enabled";
        }
        else
        {
            if (groundRenderer != null)
                groundRenderer.material.color = normalGroundColor;

            if (wallBackRenderer != null)
                wallBackRenderer.material.color = normalWallColor;

            if (wallFrontRenderer != null)
                wallFrontRenderer.material.color = normalWallColor;

            if (wallLeftRenderer != null)
                wallLeftRenderer.material.color = normalWallColor;

            if (wallRightRenderer != null)
                wallRightRenderer.material.color = normalWallColor;

            if (statusText != null)
                statusText.text = "High Contrast Mode Disabled";
        }
    }
}