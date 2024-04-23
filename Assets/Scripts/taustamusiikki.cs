using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taustamusiikki : MonoBehaviour
{
    public AudioClip[] audio1;
    public AudioClip[] audio2;

    public AudioSource[] musics;
    public Light pLight;

    public int currentIndex = 0;
    private int nextIndex;

    public float changeMusicTime = 2.0f;

    private float lastChange = 0.0f;
    private float timer = 0.0f;

    public int Trackselector;
    

    void Start()
    {

        if (musics == null || musics.Length < 2)
            Debug.Log("Need to setup colors array in inspector");

        nextIndex = (currentIndex + 1) % musics.Length;
        
    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer > changeMusicTime)
        {
            currentIndex = (currentIndex + 1) % musics.Length;
            nextIndex = (currentIndex + 1) % musics.Length;
            timer = 0.0f;

        }

        
        //AudioClip audioClip = music.Lerp(music[currentIndex], music[nextIndex], timer / changeColourTime);
        //GetComponent<AudioClip>() = audioClip; // MIND! you should store the Renderer reference in a variable rather than getting it once per frame!!!
        //pLight.color = audioClip;
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().volume = 1.0f;
        
    }
}
