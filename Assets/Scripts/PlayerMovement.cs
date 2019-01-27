using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float acceleration;
    public Character character;
    private bool dashing = false;
    private bool willDash = false;
    private bool canDash = true;
    public float dashCooldown = 1;
    public float dashLenght = 0.5f;
    public float dashAcceleration = 50;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && canDash) {
            dashing = true;
            willDash = true;
            canDash = false;
            character.canAttack = false;
        }

        if (character.attacking && !dashing) { rigidBody.velocity=Vector3.zero; }
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector2 dirVector = new Vector2(xInput, yInput);
        if (xInput >= 0.1f) {            
            character.facingRight = true;
            character.FlipSprite(!character.facingRight);
        }
        if (xInput <= -0.1f) {           
            character.facingRight = false;
            character.FlipSprite(!character.facingRight);
        }
        if (willDash) {
            Debug.Log("Dashing");
            rigidBody.AddForce(dirVector * acceleration * dashAcceleration, ForceMode2D.Force);
            Invoke("ResetDash", dashCooldown);
            Invoke("StopDash", dashLenght);
            willDash = false;
            return;
        }
        if (!dashing) {
            rigidBody.AddForce(dirVector * acceleration, ForceMode2D.Force);
        }

    }

    private void StopDash() {
        rigidBody.velocity = Vector2.zero;
        character.canAttack = true;
        dashing = false;
    }

    private void ResetDash() {

        canDash = true; }
}
