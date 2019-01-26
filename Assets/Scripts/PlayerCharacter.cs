using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
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
            Attack();
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
}
