using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public int damage = 1;
    public float powerMultiplire;
    public bool goingRight = false;
    public float acceleration;
    public float range;
    private Vector3 targetPosition;
    private bool targetSet = false;

    /*
    public void OnEnable() {
        Debug.Log("spawing");
        Character player = GameObject.Find("Player").GetComponent<Character>();
        damage = Mathf.RoundToInt(player.power * powerMultiplire);
        goingRight = player.facingRight;
        targetPosition = transform.position;
        targetPosition.x += goingRight ? range : -range;
        Debug.Log(targetPosition);
    }
    */
    public void SetTarget(Vector3 currentPosition, bool facingRight, int power) {
        targetPosition = currentPosition;
        damage = Mathf.RoundToInt(power * powerMultiplire);
        goingRight = facingRight;
        targetPosition.x += goingRight ? range : -range;
        targetSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetSet) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, acceleration);
        if(transform.position == targetPosition) { Destroy(this.gameObject); }
    }
}
