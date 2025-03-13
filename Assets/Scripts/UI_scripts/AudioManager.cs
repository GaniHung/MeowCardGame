using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance { get; private set; }

    
    [SerializeField] private AudioSource backgroundMusicSource;
    
    [SerializeField] private AudioSource soundEffectSource;
    public AudioClip gamebgm;
    public AudioClip menubgm;
    public AudioClip button_1;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ȷ��AudioManager��������Ϸ�����г�������
        }
    }
    public void playbgm(AudioClip clip)
    {
        backgroundMusicSource.Stop();
        backgroundMusicSource.clip= clip;
        backgroundMusicSource.Play();
    }
    public void playsfx(AudioClip clip)
    {
        if (soundEffectSource == null) Debug.Log("false");
        soundEffectSource.PlayOneShot(clip);
    }
    
   
}

