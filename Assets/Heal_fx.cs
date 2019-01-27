using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_fx : MonoBehaviour {

    Vector3 targetPos;
    // Use this for initialization
    void Start () {
        targetPos = transform.position + Vector3.up * Random.Range (4, 10);
    }
    
    // Update is called once per frame
    void Update () {
        transform.position = Vector3.Lerp (transform.position, targetPos, 1 * Time.deltaTime);
    }
}
