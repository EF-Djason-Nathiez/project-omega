using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public PlayerController playerController; // Référence au contrôleur du joueur
    public PlayerAbilities playerAbilities; // Référence aux entrées du joueur
    public PlayerAnimationController playerAnimationController; // Référence au contrôleur d'animation du joueur
    //public PlayerInterface playerInterface; // Référence à l'interface du joueur (si nécessaire)


    protected override void Awake()
    {
        base.Awake();
        InitializePlayer();
    }

    public void InitializePlayer()
    {
        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }

        playerController.Initialize(this);
        if (playerAbilities == null)
        {
            playerAbilities = GetComponent<PlayerAbilities>();
        }
        playerAbilities.Initialize(this);
        if (playerAnimationController == null)
        {
            playerAnimationController = GetComponent<PlayerAnimationController>();
        }
        playerAnimationController.Initialize(this);
    }

    
}
