using Utilities;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName; // Nom de l'aptitude
    public float cooldown; // Temps de recharge de l'aptitude
    public float duration; // Durée de l'aptitude (si applicable)
    public bool isPassive; // Indique si l'aptitude est passive
    public bool isActive; // Indique si l'aptitude est active ou non
    public bool isUnlocked; // Indique si l'aptitude est débloquée
    public Cooldown cooldownTimer; // Timer de cooldown pour l'aptitude
    public Sprite icon; // Icône de l'aptitude

    // Méthode pour activer l'aptitude
    public virtual void Activate()
    {
        Debug.Log($"{abilityName} activated!");
    }

    // Méthode pour désactiver l'aptitude
    public virtual void Deactivate()
    {
        Debug.Log($"{abilityName} deactivated!");
    }
}
