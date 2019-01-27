﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AICharacter
{
    public GameObject missle;

    protected override void Attack()
    {
        if (!canAttack || attacking) return;
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            return;
        }
        Debug.Log("Attacking");
        Vector3 position = transform.position;
        Vector3 target = player.transform.position;
        GameObject newMissile = (GameObject)Instantiate(missle, position, Quaternion.identity);
        newMissile.SetActive(true);
        newMissile.GetComponent<Missile>().SetTarget(target, position, facingRight, power);
        SetAttackTriggers();
    }
}
