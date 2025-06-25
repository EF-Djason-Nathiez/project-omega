using UnityEngine;

namespace Utilities
{
    
    public class Cooldown
    {
        private float cooldownTime;
        private float lastUsedTime;

        public Cooldown(float cooldown)
        {
            cooldownTime = cooldown;
            lastUsedTime = -cooldownTime; // Permet d'utiliser immédiatement après la création
        }

        public bool IsReady()
        {
            return Time.time >= lastUsedTime + cooldownTime;
        }

        public void Use()
        {
            if (IsReady())
            {
                lastUsedTime = Time.time;
            }
            else
            {
                Debug.LogWarning("Cooldown not ready yet!");
            }
        }

        public float GetRemainingTime()
        {
            return Mathf.Max(0, (lastUsedTime + cooldownTime) - Time.time);
        }
    }
}

