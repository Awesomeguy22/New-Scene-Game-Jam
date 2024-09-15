using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float cooldown;

    private float cooldownCounting;

    private void Update() {
        if (cooldownCounting > 0) {
            cooldownCounting -= Time.deltaTime;
        }
    }

    public virtual void Attack() {}
    

    protected bool CheckCooldown() {
        if (cooldownCounting > 0) {
            return true;
        }

        cooldownCounting = cooldown;
        return false;
    }

    protected void DamageEnemy(GameObject enemy) {
        Enemy enemyScript = enemy.GetComponentInParent<Enemy>();

        enemyScript.takeDamage(damage);
    }
}