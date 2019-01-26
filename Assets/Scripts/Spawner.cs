using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;



    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.RandomRange(0, enemies.Leght);
        Instantiate(enemies[randomNumber], transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
