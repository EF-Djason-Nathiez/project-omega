using UnityEngine;

public class SlashAbility : Ability
{
    public float slashRange = 2f;
    public float slashAngle = 45f;
    public float slashDamage = 10f;
    public LayerMask enemyLayer; // Layer des ennemis

    public void PerformSlash(Vector3 position, Vector3 direction)
    {
        // Vérifier si le cooldown est terminé
        if (cooldownTimer.IsReady() == false)
        {
            return; // Ne pas effectuer l'attaque si le cooldown n'est pas terminé
        }

        // Mettre à jour le temps du dernier coup
        cooldownTimer.Use();

        // Calculer la position de départ de l'attaque
        Vector3 startPosition = position;

        // Définir les limites de l'attaque
        float halfAngle = slashAngle / 2f;
        Vector3 leftBoundary = Quaternion.Euler(0, -halfAngle, 0) * direction * slashRange;
        Vector3 rightBoundary = Quaternion.Euler(0, halfAngle, 0) * direction * slashRange;

        // Vérifier les ennemis dans la zone d'attaque
        Collider[] hitEnemies = Physics.OverlapCapsule(startPosition, startPosition + direction * slashRange, slashRange / 2f, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Vector3 enemyDirection = (enemy.transform.position - startPosition).normalized;
            float angleToEnemy = Vector3.Angle(direction, enemyDirection);

            // Vérifier si l'ennemi est dans l'angle d'attaque
            if (angleToEnemy <= halfAngle)
            {
                // Appliquer les dégâts à l'ennemi
                //EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                //if (enemyHealth != null)
                // {
                //     enemyHealth.TakeDamage(slashDamage);
                // }
            }
        }
    }


}
