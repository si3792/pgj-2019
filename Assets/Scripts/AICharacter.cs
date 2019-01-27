using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : Character {
    public bool inAggroRange;
    public float speed;
    public bool inAttackRange;
    Rigidbody2D rigidBody;
    protected Vector3 targetDirection;
    public float attackDelay = 0.2f;
    public int powerValue = 1;
    public int healthValue = 1;
    public bool looksAtRight;
    protected Animator animator;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        if(animator == null)
        {
            Debug.Log("deiba");
        }
        rigidBody = GetComponent<Rigidbody2D>();
        base.Start();
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
            animator.SetTrigger("Attack");
        }
    }    

    protected virtual void SetTartgetDirection() {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        if (player.transform.position.x > transform.position.x && !facingRight)
            facingRight = true;
        else if (player.transform.position.x < transform.position.x && facingRight)
            facingRight = false;


        targetDirection = player.transform.position;
        CheckForSpriteFlip();
    }

    protected void MoveTowardsTarget() {
        Vector3 direction = targetDirection - transform.position;
        direction.Normalize();
        rigidBody.AddForce(direction * speed, ForceMode2D.Force);

    }

    public void CheckForSpriteFlip()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;
        bool shouldFlipByX = false;
        float playerAxisX = player.transform.position.x;
        float NPCAxisX = this.transform.position.x;
        if (looksAtRight)
        {
            if (!(playerAxisX > NPCAxisX))
            {
                shouldFlipByX = true;
            } else
            {
                shouldFlipByX = false;
            }
        } else
        {
            if (!(playerAxisX < NPCAxisX))
            {
                shouldFlipByX = true;
            } else
            {
                shouldFlipByX = false;
            }
        }
        base.FlipSprite(shouldFlipByX);
    }

    protected override void Die() {
        base.Die();
        GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>().PowerUp(powerValue,healthValue);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Attack attack = collision.GetComponent<Attack>();
        if (attack != null && attack.isPlayerAttack) {
            TakeDamage(attack.damage);
        }
        Missile missle = collision.GetComponent<Missile>();
        if(missle!=null && missle.isPlayerMissile) {
            TakeDamage(missle.damage);
        }
    }

    
}
