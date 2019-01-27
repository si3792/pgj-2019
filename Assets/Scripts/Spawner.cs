using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[0];


    // Start is called before the first frame update
    public void Spawn()
    {
        int randomNumber = Random.RandomRange(0, enemies.Length);
        Instantiate(enemies[randomNumber], transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }


}
