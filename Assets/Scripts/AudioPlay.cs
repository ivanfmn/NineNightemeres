using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private AudioSource sound;
    private bool playing;
    public List<AudioClip> audioClips;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        playing = false;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !playing)
        {
            playing = true;
            playMusic();
        }
    }

    protected void playMusic()
    {
        try
        {
            sound.Play();
            Debug.Log("Music");
        }
        catch
        {
            Debug.LogError("Error music");
        }
        
    }
}
