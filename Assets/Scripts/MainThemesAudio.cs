using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainThemesAudio : MonoBehaviour
{
    private AudioManager audioManager;

    private bool isPlaying = false;
    public int randomSpookyPlayerInSeconds = 0;
    System.Collections.Generic.List<Sound> spookySounds;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("mainTheme");
        spookySounds = audioManager.getSpookySounds();
    }


    private string spookieSoundName = "";
    private bool flagIsPlayingSpookie = false;
    // Update is called once per frame
    void Update()
    {
        if(!isPlayingSpooky() && !flagIsPlayingSpookie)
        {
            int num = Random.Range(1, spookySounds.Count + 1);
            int secMargin = Random.Range(5, randomSpookyPlayerInSeconds + 1);
            spookieSoundName = "Spooky" + num;
            flagIsPlayingSpookie = true;
            Invoke("playSpookie", secMargin);
        }
    }

    void playSpookie()
    {
        flagIsPlayingSpookie = false;
        audioManager.Play(this.spookieSoundName);
    }

    private bool isPlayingSpooky()
    {
        bool playing = false;
        foreach (Sound s in spookySounds)
        {
            if (s.source.isPlaying) return true;
        }
        return playing;
    }
}
