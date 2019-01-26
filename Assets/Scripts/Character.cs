using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject attackLeft;
    public bool attacking = false;
    public GameObject attackRight;
    public bool facingRight;
    public float attackTime = 0.1f;
    public float attackCoolDown = 0.5f;
    public bool canAttack = true;
    public int maxHitPoints = 3;
    public int currentHitPoints = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Attack();
        }
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


    private void OnTriggerEnter2D(Collider2D collision) {
        Attack attack = collision.GetComponent<Attack>();
        if (attack!=null && !attack.isPlayerAttack) {
            TakeDamage();
        }
    }

    protected void TakeDamage() {
        currentHitPoints--;
        if (currentHitPoints == 0) { Die(); }
    }

    protected void Die() {
        gameObject.SetActive(false);
    }
}
