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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void Attack() {
        if (!attacking && canAttack) {
            if (facingRight) {
                attackRight.gameObject.SetActive(true);

            }
            else { attackLeft.gameObject.SetActive(true); }
            attacking = true;
            canAttack = false;
            Invoke("ResetAttackingFlag", attackTime);
            Invoke("ResetAttack", attackCoolDown);
        }
    }

    private void ResetAttackingFlag() { attacking = false; }
    private void ResetAttack() { canAttack = true; }


    protected void TakeDamage(int damage) {
        currentHitPoints-=damage;
        if (currentHitPoints <= 0) { Die(); }
    }

    protected virtual void Die() {
        gameObject.SetActive(false);
    }
}
