using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraUtils : MonoBehaviour
{
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("mainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
