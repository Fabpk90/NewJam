using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public QuestionMainScript question;
    public PlayerController player;

    public Spawner spawner;
    
    public AudioClip[] musicLow;
    public AudioClip[] musicMedium;
    public AudioClip musicHigh;


    public AudioClip loopLow;
    public AudioClip loopMedium;
    public AudioClip loopHigh;

    public int musicIndex; // 0->2->1
    public int intensity;

    private AudioSource sourcePlaying;
    private AudioSource sourcePlayingBuffer;

    private AudioSource actualSource;
    
    private AudioSource sourceLoop;

    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            Instance = this;

            musicIndex = 0;
            intensity = 0;
            
            sourcePlaying = new AudioSource();
            sourceLoop = new AudioSource();

            player.QuestionStarted(question);
            Spawn(spawner.amount, spawner.toSpawn, spawner.position, spawner.radius);

            sourcePlaying.clip = musicLow[intensity];
            sourcePlaying.Play();

            actualSource = sourcePlaying;
            
            sourceLoop.clip = loopLow;
            sourceLoop.Play();
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Spawn(uint amount, GameObject toSpawn, Vector3 position, float radius)
    {
        for (uint i = 0; i < amount; i++)
        {
            Vector2 v = (Random.insideUnitCircle * radius);
            Instantiate(toSpawn, new Vector3(v.x + position.x, position.y, v.y + position.z), Quaternion.identity);
        }
    }

    public void ChangeMusicIndex(int index)
    {
        musicIndex = index;

        StartCoroutine(CrossFade());
    }

    IEnumerator CrossFade()
    {
        AudioSource previousSource = null;
        if (actualSource == sourcePlaying)
        {
            previousSource = sourcePlaying;
            actualSource = sourcePlayingBuffer;
        }
            
        else if (actualSource == sourcePlayingBuffer)
        {
            previousSource = sourcePlayingBuffer;
            actualSource = sourcePlaying;
        }
            
        if(!sourceLoop.isPlaying)
            sourceLoop.Play();
        
        
        //TODO: crossfade music
        if (intensity == 0)
        {
            actualSource.clip = musicLow[musicIndex];
        }
        else if(intensity == 1)
        {
            actualSource.clip = musicMedium[musicIndex];
        }
        else if(intensity == 2)
        {
            actualSource.clip = musicHigh;
            sourceLoop.Stop();
        }
        
        for (int i = 0; i < 10; i++)
        {
            previousSource.volume = 1 - i / 10;
            actualSource.volume = i/10;
            yield return new WaitForSeconds(0.1f);
        }
        
        actualSource.Play();
    }
}
