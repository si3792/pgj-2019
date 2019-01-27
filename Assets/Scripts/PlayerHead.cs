using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    SpriteRenderer head;

    // Start is called before the first frame update
    void Start()
    {
        head = GetComponent<SpriteRenderer>();
    }

    public void Flip(bool direction) {
        head.flipX = direction;
    }

}
