using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject attackLeft;
    public bool attacking = false;
    public GameObject attackRight;
    public bool facingRight = true;
    public float attackTime = 0.1f;
    public float attackCoolDown = 0.5f;
    public bool canAttack = true;
    public int maxHitPoints = 3;
    public int currentHitPoints = 3;
    public int power = 1;
    private HealthBar healthBar;

    // Start is called before the first frame update
    protected void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    protected virtual void Attack() {
        if (!attacking && canAttack) {
            if (facingRight) {
                attackRight.gameObject.SetActive(true);

            }
            else { attackLeft.gameObject.SetActive(true); }
            SetAttackTriggers();
        }
    }

    public virtual void PowerUp(int powerValue, int healthValue) {
        healthBar.HealthChange();
    }

    protected void SetAttackTriggers() {
        attacking = true;
        canAttack = false;
        GetComponent<Animator>().SetTrigger("Attack");
        Invoke("ResetAttackingFlag", attackTime);
        Invoke("ResetAttack", attackCoolDown);
    }

    private void ResetAttackingFlag() { attacking = false; }
    private void ResetAttack() { canAttack = true; }


    protected virtual void TakeDamage(int damage) {
        currentHitPoints-=damage;
        healthBar.HealthChange();
        if (currentHitPoints <= 0) { Die(); }
    }

    protected virtual void Die() {
        gameObject.SetActive(false);
    }

    public virtual void FlipSprite(bool shouldFlip) {       
        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;

        spriteRenderer.flipX = shouldFlip;
    }
}
