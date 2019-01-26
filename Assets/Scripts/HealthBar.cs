using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    Character character;
    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
        character = GetComponentInParent<Character>();
        SetSize(1f);
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void HealthChange()
    {
        float maxHitPoints = character.maxHitPoints;
        float currentHitPoints = character.currentHitPoints;
        float normalizedHitPoints = 1f;

        if(currentHitPoints <= 0)
        {
            normalizedHitPoints = 0;
        }
        else if(currentHitPoints >= maxHitPoints)
        {
            normalizedHitPoints = 1;
        }
        else
        {
            normalizedHitPoints = currentHitPoints / maxHitPoints;
        }
        Debug.Log("normalizedHitPoints = " + normalizedHitPoints);
        SetSize(normalizedHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
