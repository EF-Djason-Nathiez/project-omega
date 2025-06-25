using UnityEngine;

public class PlayerController : PlayerAttribute
{
    public PlayerInputs playerInputs; // Référence aux entrées du joueur

    public float playerSpeed = 5f; //Vitesse du joueur
    public float playerRotationSpeed = 360f; //Vitesse de rotation du joueur

    public Vector3 inputDirection; //Direction du stick de mouvement

    protected void Awake()
    {
        playerInputs = new PlayerInputs();
    }
    void OnEnable()
    {
        playerInputs.Enable();
    }
    void OnDisable()
    {
        playerInputs.Disable();
    }


    public void Update()
    {
        // Lire les entrées du joueur
        inputDirection = playerInputs.Main.MoveInput.ReadValue<Vector2>();

        // Convertir les entrées en direction 3D
        Vector3 direction = new Vector3(inputDirection.x, 0f, inputDirection.y);

        // Appeler la méthode de mouvement du joueur
        MovePlayer(direction);

        if(direction.magnitude > 0.1f)
        {
            // Mettre à jour l'animation de marche
            PlayerManager.Instance.playerAnimationController.SetAnimationState("IsRunning", true);
        }
        else
        {
            // Mettre à jour l'animation d'arrêt
            PlayerManager.Instance.playerAnimationController.SetAnimationState("IsRunning", false);
        }
    }

    public void MovePlayer(Vector3 direction)
    {
        // Normaliser la direction pour éviter des mouvements plus rapides en diagonale
        if (direction.magnitude > 1f)
        {
            direction.Normalize();
        }

        // Le joueur marche dans la direction de la caméra
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0; // Ignorer la composante Y pour un mouvement horizontal
        Vector3 cameraRight = Camera.main.transform.right;
        Vector3 moveDirection = (cameraForward * direction.z + cameraRight * direction.x).normalized;
        if (moveDirection.magnitude > 0.1f)
        {
            // Calculer la rotation du joueur vers la direction de mouvement
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, playerRotationSpeed * Time.deltaTime);

            // Déplacer le joueur dans la direction de mouvement
            transform.position += moveDirection * playerSpeed * Time.deltaTime;
        }

    }
    
}
