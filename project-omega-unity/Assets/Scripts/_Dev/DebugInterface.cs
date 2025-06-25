using TMPro;
using UnityEngine;

public class DebugInterface : MonoSingleton<DebugInterface>
{
    public TMP_Text debugCameraModeText;

    public static void SetCameraModeText(string mode)
    {
        if (Instance.debugCameraModeText != null)
        {
            Instance.debugCameraModeText.text = "Camera Mode: " + mode;
        }
        else
        {
            Debug.LogWarning("Debug Camera Mode Text is not assigned.");
        }
    }
}
