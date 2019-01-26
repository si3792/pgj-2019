using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public GameObject shockWave;
    public int shockWaveCost = 1;
    public float shockWaveCoolDown = 5.0f;
    public bool canUseShockWave = true;
    public GameObject playeMissile;
    public int missileCost = 1;
    public float missileCoolDown = 5.0f;
    public bool canUseMissile = true;

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
        if (Input.GetButtonDown("Fire2")) {
            SpawnShockWave();
        }
        if (Input.GetButtonDown("Fire3")) {
            SpawnMissile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Attack attack = collision.GetComponent<Attack>();
        if (attack != null && !attack.isPlayerAttack) {
            TakeDamage(attack.damage);
        }
    }

    public virtual void PowerUp(int powerValue, int healthValue) {
        power += powerValue;
        currentHitPoints += healthValue;
        if (currentHitPoints > maxHitPoints) { maxHitPoints += currentHitPoints - maxHitPoints; }
        Debug.Log(power + " " + currentHitPoints + " " + maxHitPoints);
    }

    private void SpawnShockWave() {
        if (currentHitPoints <= shockWaveCost || !canUseShockWave || !canAttack) return;
        shockWave.gameObject.SetActive(true);
        currentHitPoints -= shockWaveCost;
        attacking = true;
        canAttack = false;
        canUseShockWave = false;
        Invoke("ResetAttackingFlag", attackTime);
        Invoke("ResetAttack", attackCoolDown);
        Invoke("ReserShockWave", shockWaveCoolDown);
    }

    private void ReserShockWave() {
        canUseShockWave = true;
        Debug.Log("Can use shock wave " + currentHitPoints);
    }

    private void SpawnMissile() {
        if (currentHitPoints <= missileCost || !canUseMissile || !canAttack) return;
        Debug.Log(canUseMissile);
        Vector3 position = transform.position;
        position.x += facingRight ? 1 : -1;
        GameObject newMissile =  (GameObject)Instantiate(playeMissile, position, Quaternion.identity);
        newMissile.SetActive(true);
        newMissile.GetComponent<PlayerMissile>().SetTarget(position, facingRight, power);
        currentHitPoints -= missileCost;
        attacking = true;
        canAttack = false;
        canUseMissile = false;
        Invoke("ResetAttackingFlag", attackTime);
        Invoke("ResetAttack", attackCoolDown);
        Invoke("ResetMissile", shockWaveCoolDown);

    }


    private void ResetMissile() {
        canUseMissile = true;
        Debug.Log("Can use missile " + currentHitPoints);
    }
}
