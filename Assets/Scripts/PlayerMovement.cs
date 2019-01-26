using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float acceleration;
    public Character character;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.attacking) { rigidBody.velocity=Vector3.zero; }
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector2 dirVector = new Vector2(xInput, yInput);
        rigidBody.AddForce(dirVector * acceleration, ForceMode2D.Force);
        if(xInput >= 0.1f) { character.facingRight = true; }
        if(xInput<=-0.1f) { character.facingRight = false; }

    }
}
