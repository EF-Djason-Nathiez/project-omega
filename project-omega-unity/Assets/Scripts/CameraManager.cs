using System.Collections;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    public CameraMode cameraMode = CameraMode.Navigation; // Mode de la caméra
    public Transform playerTransform; // Référence au transform du joueur
    public float navHeight = 2f; // Hauteur de suivi de la caméra
    public float combatHeight = 9f; // Hauteur de suivi de la caméra en mode combat
    public float rotationSpeed = 5f; // Vitesse de rotation de la caméra
    public float cameraRotationSpeed = 100f; // Vitesse de rotation de la caméra
    public Vector3 offset; // Décalage de la caméra par rapport au joueur


    private void Start()
    {
        playerTransform = PlayerManager.Instance.transform; // Assigner le transform du joueur depuis PlayerManager
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is null in CameraManager.");
        }

        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is not assigned in CameraManager.");
        }

        SetMode(cameraMode); // Initialiser la caméra avec le mode par défaut
    }

    public void RotateAroundPlayer(float horizontalInput, float verticalInput)
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is null, cannot rotate camera.");
            return;
        }

        // Calculer la rotation de la caméra autour du joueur
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        if (direction.magnitude > 1f)
        {
            direction.Normalize(); // Normaliser la direction si nécessaire
        }


        Quaternion rotation = Quaternion.Euler(0, horizontalInput * cameraRotationSpeed * Time.deltaTime, 0);
        offset = rotation * offset; // Appliquer la rotation à l'offset

        // Positionner la caméra
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = targetPosition;

        // Regarder le joueur
        transform.LookAt(playerTransform.position);
    }

    public void SetMode(CameraMode mode)
    {
        cameraMode = mode;

        switch (cameraMode)
        {
            case CameraMode.Navigation:
                LerpToNewOffest(new Vector3(0, navHeight, -10), 0.5f, TransitionType.Slide); // Position de la caméra en mode navigation
                break;
            case CameraMode.Combat:
                LerpToNewOffest(new Vector3(0, combatHeight, -10), 0.5f, TransitionType.Slide); // Position de la caméra en mode combat
                break;
            case CameraMode.Cutscene:
                LerpToNewOffest(new Vector3(0, 5, -10), 0.5f, TransitionType.Slide); // Position de la caméra en mode cutscene
                break;
        }

        // Mettre à jour la position de la caméra après avoir changé de mode
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + offset;
            transform.LookAt(playerTransform.position);
        }
        
        DebugInterface.SetCameraModeText(cameraMode.ToString()); // Mettre à jour l'interface de débogage
    }

    public void LerpToNewOffest(Vector3 newOffset, float duration, TransitionType transitionType = TransitionType.Instant)
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is null, cannot lerp camera offset.");
            return;
        }

        switch (transitionType)
        {
            case TransitionType.Instant:
                offset = newOffset;
                transform.position = playerTransform.position + offset;
                transform.LookAt(playerTransform.position);
                break;

            case TransitionType.Fade:
                StartCoroutine(FadeToNewOffset(newOffset, duration));
                break;

            case TransitionType.Slide:
                StartCoroutine(SlideToNewOffset(newOffset, duration));
                break;
        }
    }

    public IEnumerator FadeToNewOffset(Vector3 newOffset, float duration)
    {
        Vector3 startOffset = offset;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            offset = Vector3.Lerp(startOffset, newOffset, t);
            transform.position = playerTransform.position + offset;
            transform.LookAt(playerTransform.position);
            yield return null;
        }

        offset = newOffset; // Assurer que l'offset final est correct
        transform.position = playerTransform.position + offset;
        transform.LookAt(playerTransform.position);
    }

    public IEnumerator SlideToNewOffset(Vector3 newOffset, float duration)
    {
        Vector3 startOffset = offset;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            offset = Vector3.Lerp(startOffset, newOffset, t);
            transform.position = playerTransform.position + offset;
            transform.LookAt(playerTransform.position);
            yield return null;
        }

        offset = newOffset; // Assurer que l'offset final est correct
        transform.position = playerTransform.position + offset;
        transform.LookAt(playerTransform.position);
    }

    public void SetCameraMode(string mode)
    {
        if (System.Enum.TryParse(mode, out CameraMode cameraMode))
        {
            SetMode(cameraMode);
        }
        else
        {
            Debug.LogWarning($"Invalid camera mode: {mode}");
        }
    }

}

public enum CameraMode
{
    Navigation,
    Combat,
    Cutscene
}

public enum TransitionType 
{
    Instant,
    Fade,
    Slide
}