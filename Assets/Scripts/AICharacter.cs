using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : Character {
    public bool inAggroRange;
    public float speed;
    public bool inAttackRange;
    Rigidbody2D rigidBody;
    private Vector3 targetDirection;
    public float attackDelay = 0.2f;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (inAggroRange && !inAttackRange) {
            SetTartgetDirection();
            MoveTowardsTarget();
        }
        if (inAttackRange && canAttack) {
            rigidBody.velocity = Vector2.zero;
            Invoke("Attack", attackDelay);
        }
    }

    

    private void SetTartgetDirection() {
        GameObject player = GameObject.Find("Player");
        if (player == null) return;

        if (player.transform.position.x > transform.position.x && facingRight)
            facingRight = false;
        else if (player.transform.position.x < transform.position.x && !facingRight)
            facingRight = true;


        targetDirection = player.transform.position;
    }

    private void MoveTowardsTarget() {
        Vector3 direction = targetDirection - transform.position;
        direction.Normalize();
        rigidBody.AddForce(direction * speed, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Attack attack = collision.GetComponent<Attack>();
        if (attack != null && attack.isPlayerAttack) {
            TakeDamage();
            Debug.Log("Getting Hit");
        }
    }
}
