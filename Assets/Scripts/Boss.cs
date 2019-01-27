using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AICharacter
{
    private System.Boolean canUseShockWave = true;
    public float shockWaveCoolDown = 2f;
    public int playerLevel = 1;
    public int aggroCap = 1;
    public GameObject missle;
    public GameObject shockWave;
    public GameObject ImpolsionAnimation;


    void Update() {
        if(playerLevel>=aggroCap && !inAttackRange) {
            Debug.Log("Chasing");
            SetTartgetDirection();
            MoveTowardsTarget();
        }
        if (inAttackRange && canAttack && !attacking && canUseShockWave) {
            rigidBody.velocity = Vector2.zero;
            canUseShockWave = false;
            Invoke("SpawnShockWave", attackDelay);
            SetAttackTriggers();
        }    
        if (inAggroRange && canAttack && !attacking) {
            Invoke("Attack", attackDelay);
            animator.SetTrigger("Attack");
            SetAttackTriggers();
        }
    }

    private void SpawnShockWave() {
        shockWave.SetActive(true);
        ImpolsionAnimation.SetActive(true);

        GetComponent<Animator>().SetTrigger("Attack");

        Invoke("ResetAttackingFlag", attackTime);
        Invoke("ResetAttack", attackCoolDown);
        Invoke("ReserShockWave", shockWaveCoolDown);
    }

    private void ReserShockWave() {
        canUseShockWave = true;
        Debug.Log("Can use shock wave " + currentHitPoints);
    }

    protected override void Attack() {
        if (!canAttack || attacking) return;
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) {
            return;
        }
        Vector3 position = transform.position;
        Vector3 target = player.transform.position;
        GameObject newMissile = (GameObject)Instantiate(missle, position, Quaternion.identity);
        newMissile.SetActive(true);
        newMissile.GetComponent<Missile>().SetTarget(target, position, facingRight, power);
    }
}
