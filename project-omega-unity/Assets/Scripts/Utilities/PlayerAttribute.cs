using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    protected PlayerManager manager;

    public virtual void Initialize(PlayerManager playerManager)
    {
        manager = playerManager;
    }
}
