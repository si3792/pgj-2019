using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isPlayerAttack;

    // Start is called before the first frame update
    void OnEnable()
    {
        float attackTime = GetComponentInParent<Character>().attackTime;
        Invoke("ExecuteSelf", attackTime);
    }

    private void ExecuteSelf() {
        gameObject.SetActive(false);
    }
}
