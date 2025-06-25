using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public PlayerController playerController; // Référence au contrôleur du joueur
    public PlayerAbilities playerAbilities; // Référence aux entrées du joueur
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
    }

    
}
