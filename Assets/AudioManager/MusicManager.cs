using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

	public static MusicManager instance;

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
        mixer.SetFloat("MusicVol", Mathf.Log10(0.0001f) * 20);
    }
    
    public void UpdateVolume()
    {
        //this is to update musci voulume by uning mixer voulume that this scrit is using
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("MusicVol",defaultMixerVol)) * 20);
    }
    
    private void Start()
    {
        // if (PlayerPrefs.GetInt("musicStatus", 1) == 0)
        // {
        //     Mute(); 
        // }
        // else
        // {
        //     UpdateVolume();
        // }
        Play("bgMusic");
        //Mute();
        UpdateVolume();
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
