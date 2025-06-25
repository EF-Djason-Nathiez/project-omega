using UnityEngine;

public class PlayerAnimationController : PlayerAttribute
{
    public Animator animator; // Référence à l'Animator du joueur

    public override void Initialize(PlayerManager playerManager)
    {
        base.Initialize(playerManager);
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on PlayerAnimationController.");
        }
    }

    public void SetAnimationState(string stateName, bool value)
    {
        if (animator != null)
        {
            animator.SetBool(stateName, value);
        }
        else
        {
            Debug.LogError("Animator is not initialized.");
        }
    }
}
