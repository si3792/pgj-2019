using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isPlayerAttack;
    public int damage = 1;

    // Start is called before the first frame update
    void OnEnable()
    {
        damage = GetComponentInParent<Character>().power;
        float attackTime = GetComponentInParent<Character>().attackTime;
        Invoke("ExecuteSelf", attackTime);
    }

    private void ExecuteSelf() {
        gameObject.SetActive(false);
    }
}
