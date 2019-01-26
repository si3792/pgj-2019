using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public int damage = 1;
    public float powerMultiplire;
    public bool goingRight = false;
    public float acceleration;
    public float range;
    private Vector3 targetPosition;
    private bool targetSet = false;
    private bool blockMovement = false;
    public bool isPlayerMissile = false;

    public void SetTarget(Vector3 targetPosition, Vector3 currentPosition, bool facingRight, int power) {
        blockMovement = true;
        SetPosition(currentPosition, facingRight, power);
        this.targetPosition = targetPosition;
        blockMovement = false;
        
    }

    public void SetPosition(Vector3 currentPosition, bool facingRight, int power) {
        targetPosition = currentPosition;
        damage = Mathf.RoundToInt(power * powerMultiplire);
        goingRight = facingRight;
        targetPosition.x += goingRight ? range : -range;
        targetSet = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (!targetSet || blockMovement) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, acceleration);
        if(transform.position == targetPosition) {Debug.Log("Destroying"); Destroy(this.gameObject); }
    }
}
