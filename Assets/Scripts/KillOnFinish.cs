using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnFinish : MonoBehaviour
{

    // Use this for initialization
    public float delay = 0f;
    void Start()
    {
        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    // Update is called once per frame
    void Update()
    {

    }
}