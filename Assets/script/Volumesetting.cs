using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volumesetting : MonoBehaviour
{
    private AudioSource audiosetting;
    private float musicVolume = 0.33f;

    private static Volumesetting sound = null;

    void Start()
    {
        playsound();
    }

    void playsound() {
        audiosetting = GetComponent<AudioSource>();
    }

    void Update()
    {
        audiosetting.volume = musicVolume;
    }

    public void Setting(float vol)
    {
        musicVolume = vol;
    }

    public static Volumesetting Sound
    {
        get { return sound; }

    }
    void Awake()
    {
        if (sound != null && sound != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            sound = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
