using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{//I have written vfx in place but meant sfx. not changing as it will be time consuming

	public static SFXManager instance;

	public AudioMixerGroup mixerGroup;
    public AudioMixer mixer;
    public float defaultMixerVol;
    

	public Sound[] sounds;

	void Awake()
	{
		
        if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
           
        }
	}
    public void Mute()
    {
        mixer.SetFloat("SFXVol", Mathf.Log10(0.0001f) * 20);
    }
    
    public void UpdateVolume()
    {
        //this is to update musci voulume by uning mixer voulume that this scrit is using
        mixer.SetFloat("SFXVol", Mathf.Log10(1) * 20);
    }
    
    private void Start()
    {
        if (PlayerPrefs.GetInt("SoundStatus", 0) == -1)
        {
            Mute();
        }
        else if (PlayerPrefs.GetInt("SoundStatus", 0)==0)
        {
            UpdateVolume();
        }
        //Play("bgMusic");
        //UpdateVolume();
    }

    public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();

	}
    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop(); 
    }
    public void Pause(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

}
