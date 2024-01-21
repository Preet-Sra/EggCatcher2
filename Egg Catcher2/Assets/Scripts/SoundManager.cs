using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource _SFXaudio,_backgroundAudio;
    [SerializeField] AudioClip EggsCollected, EggsMissed;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayAudio( AudioClip clip)
    {
        _SFXaudio.PlayOneShot(clip);       
    }
  
    public void PlayEggsColected()
    {
        _SFXaudio.PlayOneShot(EggsCollected);
    }
    public void PlayEggsMissed()
    {
        _SFXaudio.PlayOneShot(EggsMissed);
    }
}
