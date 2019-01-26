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
        if (!attacking) {
            if (facingRight) {
                attackRight.gameObject.SetActive(true);

            }
            else { attackLeft.gameObject.SetActive(true); }
            attacking = true;
        }
    }
}
