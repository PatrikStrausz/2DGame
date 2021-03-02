using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    public AudioMixerGroup mixer;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
           

            s.source.outputAudioMixerGroup = mixer;
            
        }

    }



    private void Start()
    {
        Play("ThemeSong");

    }
    public void Play(string name)
    {
       Sound s =  Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }


  

 /*   public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.GetComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = volume;
            s.volume = volume;

            Debug.Log(s.name + "  "+s.volume);
            if (s.name.Equals("ThemeSong"))
            {
                s.volume = 0;
                s.source.volume = 0;
            }
           
        }
    }
  */
}
