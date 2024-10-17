using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Singleton
    private static AudioManager instance;
    

    
    public static AudioManager INSTANCE
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("no audio manager");
            }
           
            return instance;

            
        }
    }



    #endregion
    [Header("audiosourcereferences")]
    public AudioSource musicSource;
    public AudioSource SfxSource;

    [Header("audio clip")]
    public AudioClip[] musicArray;
    public AudioClip[] SfxArray;

    private void Awake()
    {
        //el singeltone se referencia a si mismo 
        instance = this;
    }


    #region Musec Method
    public void PlayMusic(int musicToPlay)
    {
        musicSource.clip = musicArray[musicToPlay];
        musicSource.Play();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
    #endregion

    #region Sfx Method
    public void PlaySFX(int sfxToPlay)
    {
        SfxSource.PlayOneShot(SfxArray[sfxToPlay]);
        
    }
    #endregion

    // Llamada sin referencia AudioManager.INSTANCE.PlayMusic(1);
}
